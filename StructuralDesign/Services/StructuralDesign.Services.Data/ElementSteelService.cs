namespace StructuralDesign.Services.Data
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.ElementSteel;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public class ElementSteelService : IElementSteelService
    {
        private readonly IRepository<ElementSteel> elementSteelRepository;
        private readonly ILoadService loadService;
        private readonly ISectionsService sectionsService;

        public ElementSteelService(
            IRepository<ElementSteel> elementSteelRepository,
            ILoadService loadService,
            ISectionsService sectionsService)
        {
            this.elementSteelRepository = elementSteelRepository;
            this.loadService = loadService;
            this.sectionsService = sectionsService;
        }

        public async Task<string> CreateAsync(CreateInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId)
        {
            int loadId = this.loadService.CreateAsync(inputLoad).Result;
            int sectionId = this.sectionsService.CreateAsync(inputSection).Result;

            var steelElement = new ElementSteel
            {
                Name = input.Name,
                Length = input.Length,
                LeftBoundaryCondition = input.LeftBoundaryCondition,
                RightBoundaryCondition = input.RightBoundaryCondition,
                ProjectId = projectId,
                SteelId = input.SteelId,
                BoltId = input.BoltId,
                MaterialBoltId = input.MaterialBoltId,
                LoadId = loadId,
                Load = this.loadService.GetSectionById(loadId),
                SectionId = sectionId,
                Section = this.sectionsService.GetSectionById(sectionId),
            };

            await this.elementSteelRepository.AddAsync(steelElement);
            await this.elementSteelRepository.SaveChangesAsync();
            await this.ResultJson(steelElement.Id);

            return steelElement.Id;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var concreteElement = this.elementSteelRepository.All().FirstOrDefault(x => x.Id == id);
            var projectId = concreteElement.ProjectId;

            this.elementSteelRepository.Delete(concreteElement);
            await this.elementSteelRepository.SaveChangesAsync();

            return projectId;
        }

        public EditInputModel GetById(string id)
        {
            var elementConcrete = this.elementSteelRepository.All().Where(x => x.Id == id).Select(x => new EditInputModel
            {
                Name = x.Name,
                Length = x.Length,
                LeftBoundaryCondition = x.LeftBoundaryCondition,
                RightBoundaryCondition = x.RightBoundaryCondition,
                SteelId = x.SteelId,
                BoltId = x.BoltId,
                MaterialBoltId = x.MaterialBoltId,
                ProjectId = x.ProjectId,
                CreateSection = new CreateSectionInputModel
                {
                    SectionName = x.Section.Name,
                    SectionType = (StructuralDesign.Web.ViewModels.Section.SectionType)x.Section.Type,
                    Height = x.Section.Height,
                    Width = x.Section.Width,
                },
                CreatLoad = new CreateLoadInputModel
                {
                    Type = (StructuralDesign.Web.ViewModels.Load.LoadType)x.Load.Type,
                    BendingMomentY = x.Load.BendingMomentY,
                    ShearForceZ = x.Load.ShearForceZ,
                },
            }).FirstOrDefault();
            return elementConcrete;
        }

        public async Task<string> EditAsync(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            var elementSteel = this.elementSteelRepository.All().Where(x => x.Id == id).FirstOrDefault();

            elementSteel.Name = input.Name;
            elementSteel.Length = input.Length;
            elementSteel.LeftBoundaryCondition = input.LeftBoundaryCondition;
            elementSteel.RightBoundaryCondition = input.RightBoundaryCondition;
            elementSteel.SteelId = input.SteelId;
            elementSteel.BoltId = input.BoltId;
            elementSteel.MaterialBoltId = input.MaterialBoltId;

            await this.sectionsService.EditAsync(elementSteel.SectionId, inputSection);
            await this.loadService.EditAsync(elementSteel.LoadId, inputLoad);

            await this.elementSteelRepository.SaveChangesAsync();

            return elementSteel.ProjectId;
        }

        public ResultViewModel ResultObject(string id)
        {
            var element = this.elementSteelRepository.All().Where(x => x.Id == id).Select(x => x.Result).FirstOrDefault();
            return JsonConvert.DeserializeObject<ResultViewModel>(element);
        }

        private async Task<string> ResultJson(string id)
        {
            var element = this.elementSteelRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var result = this.elementSteelRepository.All().Where(x => x.Id == id).Select(x => new ResultViewModel
            {
                Name = x.Name,
                SectionType = x.Section.Type.ToString(),
                Height = x.Section.Height,
                Width = x.Section.Width,
                WebThickness = x.Section.WebThickness,
                InertialMomentY = x.Section.InertialMomentY,
                ResistanceMomentY = x.Section.ResistanceMomentY,
                StaticMomentY = 5,
                YieldStrengthForElement = x.Steel.YieldStrength,
                Length = x.Length,
                LeftBoundaryCondition = x.LeftBoundaryCondition.ToString(),
                RightBoundaryCondition = x.RightBoundaryCondition.ToString(),
                ShearForceZ = x.Load.ShearForceZ,
                BendingMomentY = x.Load.BendingMomentZ,
                BoltDiameter = x.Bolt.NominalDiameter,
                BoltGrossArea = x.Bolt.GrossArea,
                YieldStrengthForBolt = x.MaterialBolt.YieldStrength,
            }).FirstOrDefault();

            var designYieldStrength = this.DesignYieldStrength(result.YieldStrengthForElement);
            result.PreassureBendingMomentY = this.PreassureBendingMomentY(result.BendingMomentY, result.ResistanceMomentY);
            result.PreassureShearForceZ = this.PreassureShearForceZ(
                result.ShearForceZ,
                result.InertialMomentY,
                result.StaticMomentY,
                result.WebThickness == 0 ? result.Width : element.Section.WebThickness);
            result.ResultFactorBendingMomentY = this.ResultFactorBendingMomentY(result.PreassureBendingMomentY, designYieldStrength);
            result.ResultFactorShearForceZ = this.ResultFactorShearForceZ(result.PreassureShearForceZ, designYieldStrength);
            result.ResultConclusion = this.ResultConclusion(result.ResultFactorBendingMomentY, result.ResultFactorShearForceZ);
            result.CountOfBolt = this.CountOfBolt(result.ShearForceZ, result.BoltGrossArea, result.YieldStrengthForBolt);

            var jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
            element.Result = jsonResult;

            await this.elementSteelRepository.SaveChangesAsync();

            return jsonResult;
        }

        private double DesignYieldStrength(double yieldStrength)
        {
            if (yieldStrength <= 31)
            {
                return yieldStrength / 1.1;
            }
            else if (yieldStrength <= 41)
            {
                return yieldStrength / 1.15;
            }
            else if (yieldStrength <= 49)
            {
                return yieldStrength / 1.2;
            }
            else
            {
                return 0;
            }
        }

        private double PreassureBendingMomentY(double bendingMomentY, double resistanceMomentY)
        {
            return bendingMomentY * 100 / resistanceMomentY;
        }

        private double PreassureShearForceZ(double shearForceZ, double inertialMomentY, double staticMomentY, double thickness)
        {
            return (shearForceZ * staticMomentY) / (thickness * inertialMomentY);
        }

        private double ResultFactorBendingMomentY(double preassureBendingMomentY, double designYieldStrength)
        {
            return preassureBendingMomentY / designYieldStrength;
        }

        private double ResultFactorShearForceZ(double preassureShearForceZ, double designYieldStrength)
        {
            return preassureShearForceZ / designYieldStrength;
        }

        private string ResultConclusion(double resultFactorBendingMomentY, double resultFactorShearForceZ)
        {
            var sb = new StringBuilder();
            if (resultFactorBendingMomentY > 1 && resultFactorShearForceZ > 1)
            {

                sb.AppendLine("NO!");
                sb.AppendLine("Change the section! Insufficient bearing capacity for bending moment!");
                sb.AppendLine("Change the section! Insufficient bearing capacity for shear force!");
            }
            else if (resultFactorBendingMomentY <= 1 && resultFactorShearForceZ > 1)
            {
                sb.AppendLine("NO!");
                sb.AppendLine("The bearing capacity of the section is sufficient for bending moment!");
                sb.AppendLine("Change the section! Insufficient bearing capacity for shear force!");
            }
            else if (resultFactorBendingMomentY > 1 && resultFactorShearForceZ <= 1)
            {

                sb.AppendLine("NO!");
                sb.AppendLine("Change the section! Insufficient bearing capacity for bending moment!");
                sb.AppendLine("The bearing capacity of the section is sufficient for shear force!");
            }
            else
            {
                sb.AppendLine("OK!");
                sb.AppendLine("The bearing capacity of the section is sufficient for bending moment and shear force!");
            }

            return sb.ToString().TrimEnd();
        }

        private int CountOfBolt(double shearForceZ, double grossAreaOfBolt, double yieldStrength)
        {
            return (int)Math.Ceiling(shearForceZ / (2 * grossAreaOfBolt * 0.9 * yieldStrength * 0.9));
        }
    }
}
