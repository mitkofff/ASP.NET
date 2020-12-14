namespace StructuralDesign.Services.Data
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.ElementConcrete;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public class ElementConcreteService : IElementConcreteService
    {
        private readonly IRepository<ElementConcrete> elementConcreteRepository;
        private readonly ILoadService loadService;
        private readonly ISectionsService sectionsService;

        public ElementConcreteService(
            IRepository<ElementConcrete> elementConcreteRepository,
            ILoadService loadService,
            ISectionsService sectionsService)
        {
            this.elementConcreteRepository = elementConcreteRepository;
            this.loadService = loadService;
            this.sectionsService = sectionsService;
        }

        public async Task<string> CreateAsync(CreateConcreteColumnInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId)
        {
            int loadId = this.loadService.CreateAsync(inputLoad).Result;
            int sectionId = this.sectionsService.CreateAsync(inputSection).Result;

            var concreteElement = new ElementConcrete
            {
                Name = input.Name,
                Length = input.Length,
                LeftBoundaryCondition = input.LeftBoundaryCondition,
                RightBoundaryCondition = input.RightBoundaryCondition,
                ProjectId = projectId,
                ConcreteId = input.ConcreteId,
                MaterialRebarId = input.MaterialRebarId,
                LoadId = loadId,
                SectionId = sectionId,
                Section = this.sectionsService.GetSectionById(sectionId),
                ReinforcementBarId = input.ReinforcementBarId,
            };

            await this.elementConcreteRepository.AddAsync(concreteElement);
            await this.elementConcreteRepository.SaveChangesAsync();

            return concreteElement.Id;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var concreteElement = this.elementConcreteRepository.All().FirstOrDefault(x => x.Id == id);
            var projectId = concreteElement.ProjectId;

            this.elementConcreteRepository.Delete(concreteElement);
            await this.elementConcreteRepository.SaveChangesAsync();

            return projectId;
        }

        public EditInputModel GetById(string id)
        {
            var elementConcrete = this.elementConcreteRepository.All().Where(x => x.Id == id).Select(x => new EditInputModel
            {
                Name = x.Name,
                Length = x.Length,
                LeftBoundaryCondition = x.LeftBoundaryCondition,
                RightBoundaryCondition = x.RightBoundaryCondition,
                ConcreteId = x.ConcreteId,
                MaterialRebarId = x.MaterialRebarId,
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
                    AxialForce = x.Load.AxialForce,
                },
            }).FirstOrDefault();
            return elementConcrete;
        }

        public async Task<string> EditAsync(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            var elementConcrete = this.elementConcreteRepository.All().Where(x => x.Id == id).FirstOrDefault();

            elementConcrete.Name = input.Name;
            elementConcrete.Length = input.Length;
            elementConcrete.LeftBoundaryCondition = input.LeftBoundaryCondition;
            elementConcrete.RightBoundaryCondition = input.RightBoundaryCondition;
            elementConcrete.MaterialRebarId = input.MaterialRebarId;
            elementConcrete.ConcreteId = input.ConcreteId;
            elementConcrete.ReinforcementBarId = input.ReinforcementBarId;

            await this.sectionsService.EditAsync(elementConcrete.SectionId, inputSection);
            await this.loadService.EditAsync(elementConcrete.LoadId, inputLoad);

            await this.elementConcreteRepository.SaveChangesAsync();

            return elementConcrete.ProjectId;
        }

        public ResultViewModel Result(string id)
        {
            var result = this.elementConcreteRepository.All().Where(x => x.Id == id).Select(x => new ResultViewModel
            {
                Name = x.Name,
                SectionHeight = x.Section.Height,
                SectionWidth = x.Section.Width,
                SectionArea = x.Section.Area,
                Length = x.Length,
                LeftBoundaryCondition = x.LeftBoundaryCondition.ToString(),
                RightBoundaryCondition = x.RightBoundaryCondition.ToString(),
                AxialForce = x.Load.AxialForce,
                ReinforcementDiameter = x.ReinforcementBar.Diameter,
                ReinforcementBarArea = x.ReinforcementBar.Area,
                ConcreteDesignCompressiveStrength = x.Concrete.DesignCompressiveStrength,
                DesignReinforcementStrength = x.MaterialRebar.YieldStrength / x.MaterialRebar.PartialSafetyFactor,
            }).FirstOrDefault();

            var slendernessCoefficient = this.SlendernessCoefficient(result.Length, result.SectionHeight, result.SectionHeight, result.LeftBoundaryCondition, result.RightBoundaryCondition);
            var bucklingCoefficient = this.BucklingCoefficient(slendernessCoefficient);
            var necessaryReinforcement = this.NecessaryReinforcement(bucklingCoefficient, result.AxialForce, result.AxialForce, result.ConcreteDesignCompressiveStrength, result.DesignReinforcementStrength);
            var countOfReinforcementBars = this.CountOfReinforcementBars(necessaryReinforcement, result.ReinforcementBarArea);

            result.SlendernessCoefficient = Math.Round(slendernessCoefficient, 3);
            result.BucklingCoefficient = Math.Round(bucklingCoefficient, 3);
            result.NecessaryReinforcement = Math.Round(necessaryReinforcement, 1);
            result.CountOfReinforcementBars = countOfReinforcementBars;

            return result;
        }

        private double SlendernessCoefficient(double length, double sectionWidth, double sectionHeight, string leftBoundaryCondition, string rightBoundaryCondition)
        {
            double coefficient;

            if (leftBoundaryCondition == "Free" && rightBoundaryCondition == "Free")
            {
                coefficient = 1000;
            }
            else if (leftBoundaryCondition == "Free" && rightBoundaryCondition == "Pinned")
            {
                coefficient = 1000;
            }
            else if (leftBoundaryCondition == "Pinned" && rightBoundaryCondition == "Free")
            {
                coefficient = 1000;
            }
            else if (leftBoundaryCondition == "Pinned" && rightBoundaryCondition == "Pinned")
            {
                coefficient = 1;
            }
            else if (leftBoundaryCondition == "Free" && rightBoundaryCondition == "Fixed")
            {
                coefficient = 2;
            }
            else if (leftBoundaryCondition == "Fixed" && rightBoundaryCondition == "Free")
            {
                coefficient = 2;
            }
            else if (leftBoundaryCondition == "Pinned" && rightBoundaryCondition == "Fixed")
            {
                coefficient = 0.707;
            }
            else
            {
                coefficient = 0.707;
            }

            var slendernessLength = length * coefficient;
            double slendernessCoefficient = slendernessLength / Math.Min(sectionWidth, sectionHeight);

            return slendernessCoefficient;
        }

        private double BucklingCoefficient(double slendernessCoefficient)
        {
            double bucklingCoefficient = 0;

            if (slendernessCoefficient < 6)
            {
                bucklingCoefficient = 0.92;
            }
            else if (slendernessCoefficient > 6 && slendernessCoefficient < 8)
            {
                bucklingCoefficient = ((0.92 - 0.91) * (8 - slendernessCoefficient) / (8 - 6)) + 0.91;
            }
            else if (slendernessCoefficient > 8 && slendernessCoefficient < 10)
            {
                bucklingCoefficient = ((0.91 - 0.90) * (10 - slendernessCoefficient) / (10 - 8)) + 0.90;
            }
            else if (slendernessCoefficient > 10 && slendernessCoefficient < 12)
            {
                bucklingCoefficient = ((0.90 - 0.88) * (12 - slendernessCoefficient) / (12 - 10)) + 0.88;
            }
            else if (slendernessCoefficient > 12 && slendernessCoefficient < 14)
            {
                bucklingCoefficient = ((0.88 - 0.84) * (14 - slendernessCoefficient) / (14 - 12)) + 0.84;
            }
            else if (slendernessCoefficient > 14 && slendernessCoefficient < 16)
            {
                bucklingCoefficient = ((0.84 - 0.79) * (16 - slendernessCoefficient) / (16 - 14)) + 0.79;
            }
            else if (slendernessCoefficient > 16 && slendernessCoefficient < 18)
            {
                bucklingCoefficient = ((0.79 - 0.74) * (18 - slendernessCoefficient) / (18 - 16)) + 0.74;
            }
            else if (slendernessCoefficient > 18 && slendernessCoefficient < 20)
            {
                bucklingCoefficient = ((0.74 - 0.67) * (20 - slendernessCoefficient) / (20 - 18)) + 0.67;
            }
            else if (slendernessCoefficient > 20 && slendernessCoefficient < 20)
            {
                bucklingCoefficient = 0.01;
            }

            return bucklingCoefficient;
        }

        private double NecessaryReinforcement(double bucklingCoefficient, double sectionArea, double axialForce, double designCompressiveStrength, double designReinforcementStrength)
        {
            double necessaryReinforcement = axialForce < 0 ? ((axialForce / bucklingCoefficient) - (bucklingCoefficient * 0.85 * ( sectionArea / 100 ) * designCompressiveStrength)) / designReinforcementStrength : axialForce / designReinforcementStrength;
            return necessaryReinforcement;
        }

        private string ReinforcementPercent (double necessaryReinforcement, double sectionArea)
        {
            var sb = new StringBuilder();
            var percentOfReinforcement = necessaryReinforcement / sectionArea / 100;

            if (percentOfReinforcement < 0.005)
            {
                sb.AppendLine($"Minimal percetn of reinforcement is 0.5% - {sectionArea * 0.005}cm2");
            }
            else if (percentOfReinforcement >= 0.03)
            {
                sb.AppendLine("Maximum reinforcement rate exceeded! Change the section!");
            }
            else
            {
                sb.AppendLine($"Maximum reinforcement rate is {percentOfReinforcement * 100}! Тhe check is performed");
            }

            return sb.ToString().TrimEnd();
        }

        private int CountOfReinforcementBars (double necessaryReinforcement, double reinforcementBarArea)
        {
            int barsNumber = (int)Math.Ceiling(necessaryReinforcement / (reinforcementBarArea * 0.01));
            return barsNumber;
        }
    }
}
