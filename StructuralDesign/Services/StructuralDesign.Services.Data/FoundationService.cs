namespace StructuralDesign.Services.Data
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StructuralDesign.Common;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Foundation;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public class FoundationService : IFoundationService
    {
        private readonly IRepository<ElementFoundation> foundationRepository;
        private readonly IRepository<MaterialSoil> soilRepository;
        private readonly ILoadService loadService;
        private readonly ISectionsService sectionsService;

        public FoundationService(
            IRepository<ElementFoundation> foundationRepository,
            IRepository<MaterialSoil> soilRepository,
            ILoadService loadService,
            ISectionsService sectionsService)
        {
            this.foundationRepository = foundationRepository;
            this.soilRepository = soilRepository;
            this.loadService = loadService;
            this.sectionsService = sectionsService;
        }

        public EditFoundationInputModel GetById(string id)
        {
            var foundament = this.foundationRepository.All().Where(x => x.Id == id).Select(x => new EditFoundationInputModel
            {
                Name = x.Name,
                HeightOfFoundament = x.Height,
                HeightOfBackFill = x.HeightOfBackFill,
                SoilId = x.SoilId,
                ConcreteId = x.ConcreteId,
                MaterialRebarId = x.MaterialRebarId,
                CreateSection = new CreateSectionInputModel
                {
                    SectionName = x.Section.Name,
                    SectionType = (StructuralDesign.Web.ViewModels.Section.SectionType)x.Section.Type,
                    Height = x.Section.Height,
                    Width = x.Section.Width,
                    WebThickness = x.Section.WebThickness,
                    FlangeThickness = x.Section.FlangeThickness,
                },
                CreatLoad = new CreateLoadInputModel
                {
                    Type = (StructuralDesign.Web.ViewModels.Load.LoadType)x.Load.Type,
                    AxialForce = x.Load.AxialForce,
                    BendingMomentY = x.Load.BendingMomentY,
                    BendingMomentZ = x.Load.BendingMomentZ,
                    ShearForceY = x.Load.ShearForceY,
                    ShearForceZ = x.Load.ShearForceZ,
                },
            }).FirstOrDefault();
            return foundament;
        }

        public async Task<string> CreateAsync(CreateFoundationInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId)
        {
            int loadId = this.loadService.CreateAsync(inputLoad).Result;
            int sectionId = this.sectionsService.CreateAsync(inputSection).Result;
            var foundation = new ElementFoundation
            {
                Name = input.Name,
                Height = input.HeightOfFoundament,
                HeightOfBackFill = input.HeightOfBackFill,
                MaterialRebarId = input.MaterialRebarId,
                ConcreteId = input.ConcreteId,
                SoilId = input.SoilId,
                Soil = this.soilRepository.All().Where(x => x.Id == input.SoilId).FirstOrDefault(),
                LoadId = loadId,
                SectionId = sectionId,
                ProjectId = projectId,
            };

            await this.foundationRepository.AddAsync(foundation);
            await this.foundationRepository.SaveChangesAsync();
            return foundation.Id;
        }

        public async Task AddResultAsync(string foundamentId)
        {
            ElementFoundation foundation = this.foundationRepository.All().FirstOrDefault(x => x.Id == foundamentId);
            var loadsReduction = this.LoadsReduction(foundation.Load.AxialForce, foundation.Load.BendingMomentY, foundation.Load.BendingMomentZ, foundation.Load.ShearForceY, foundation.Load.ShearForceZ, foundation.Height, foundation.Section.Width, foundation.Section.Height, foundation.HeightOfBackFill);
            var loadEccentricity = this.Eccentricity(loadsReduction);
            var pressureArray = this.Pressure(foundation.Section, loadsReduction);
            var check = this.Check(foundation.Section, pressureArray, loadEccentricity, foundation.Soil.DesignPressure, foundation.Load.Type.ToString());
            foundation.Result = check;
            await this.foundationRepository.SaveChangesAsync();
        }

        public FoundationResultViewModel Result(string id)
        {
            var foundation = this.foundationRepository.All().Where(x => x.Id == id).Select(x => new FoundationResultViewModel
            {
                Name = x.Name,
                HeightOfFoundament = x.Height,
                HeightOfBackFill = x.HeightOfBackFill,
                Width = x.Section.Width,
                Length = x.Section.Height,
                SoilName = x.Soil.Name + " - " + x.Soil.DesignPressure,
                ConcreteName = x.Concrete.Name,
                MaterialRebarName = x.MaterialRebar.Name,
                LoadType = x.Load.Type.ToString(),
                AxialForce = x.Load.AxialForce,
                BendingMomentY = x.Load.BendingMomentY,
                BendingMomentZ = x.Load.BendingMomentZ,
                ShearForceY = x.Load.ShearForceY,
                ShearForceZ = x.Load.ShearForceZ,
                AveragePressure = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[0]), 1),
                PressureEdge = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[1]), 1),
                PressureVertex1 = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[2]), 1),
                PressureVertex2 = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[3]), 1),
                PressureVertex3 = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[4]), 1),
                PressureVertex4 = Math.Round(double.Parse(x.Result.Split("PRESSURES: ", StringSplitOptions.RemoveEmptyEntries)[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)[5]), 1),
            }).FirstOrDefault();

            return foundation;
        }

        public async Task<string> EditAsync(EditFoundationInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id)
        {
            var foundation = this.foundationRepository.All().FirstOrDefault(x => x.Id == id);

            int loadId = this.loadService.CreateAsync(inputLoad).Result;
            int sectionId = this.sectionsService.CreateAsync(inputSection).Result;
            foundation.Name = input.Name;
            foundation.Height = input.HeightOfFoundament;
            foundation.HeightOfBackFill = input.HeightOfBackFill;
            foundation.MaterialRebarId = input.MaterialRebarId;
            foundation.ConcreteId = input.ConcreteId;
            foundation.SoilId = input.SoilId;
            foundation.Soil = this.soilRepository.All().Where(x => x.Id == input.SoilId).FirstOrDefault();
            foundation.LoadId = loadId;
            foundation.SectionId = sectionId;

            await this.foundationRepository.SaveChangesAsync();
            return foundation.ProjectId;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var foundation = this.foundationRepository.All().FirstOrDefault(x => x.Id == id);
            var projectId = foundation.ProjectId;

            this.foundationRepository.Delete(foundation);
            await this.foundationRepository.SaveChangesAsync();

            return projectId;
        }

        private double[] LoadsReduction(double axialForce, double bendingMomentY, double bendingMomentZ, double shearForceY, double shearForceZ, double foundationHeight, double foundationWidth, double foundationLength, double backfillHeight)
        {
            double totalAxialForce = axialForce + (foundationHeight * foundationLength * foundationWidth * 25 / 1000000000) + (backfillHeight * foundationLength * foundationWidth * 18 / 1000000000);
            double totalBendingMomentY = bendingMomentY + (shearForceZ * foundationHeight / 1000);
            double totalBendingMomentZ = bendingMomentZ + (shearForceY * foundationHeight / 1000);

            double[] loadsArray = { totalAxialForce, totalBendingMomentY, totalBendingMomentZ };

            return loadsArray;
        }

        private double[] Eccentricity(double[] loadsArray)
        {
            double ey = loadsArray[2] / loadsArray[0];
            double ez = loadsArray[1] / loadsArray[0];
            double[] eccentricitiesArray = { ey, ez };
            return eccentricitiesArray;
        }

        private double[] Pressure(Section section, double[] loadsArray)
        {
            var eccentricitiesArray = this.Eccentricity(loadsArray);
            double pressureM = loadsArray[0] / (section.Area * GlobalConstants.mm2ToM2);
            double pressureY1;
            double pressureY2;
            double pressureZ1;
            double pressureZ2;

            if (eccentricitiesArray[0] <= (section.Width / 6))
            {
                pressureY1 = pressureM - (loadsArray[2] / (section.ResistanceMomentY * GlobalConstants.mm3ToM3));
                pressureY2 = pressureM + (loadsArray[2] / (section.ResistanceMomentY * GlobalConstants.mm3ToM3));
            }
            else
            {
                pressureY1 = 2 * loadsArray[0] / (section.Height * GlobalConstants.mmToM * 3 * ((section.Width * GlobalConstants.mmToM / 2) - eccentricitiesArray[0]));
                pressureY2 = 0;
            }

            if (eccentricitiesArray[1] <= (section.Height / 6))
            {
                pressureZ1 = pressureM - (loadsArray[1] / (section.ResistanceMomentZ * GlobalConstants.mm3ToM3));
                pressureZ2 = pressureM + (loadsArray[1] / (section.ResistanceMomentZ * GlobalConstants.mm3ToM3));
            }
            else
            {
                pressureZ1 = 2 * loadsArray[0] / (section.Height * GlobalConstants.mmToM * 3 * ((section.Width * GlobalConstants.mmToM / 2) - eccentricitiesArray[0]));
                pressureZ2 = 0;
            }

            double pressurePoint1 = pressureY2 + pressureZ1 - pressureM;
            double pressurePoint2 = pressureY2 + pressureZ2 - pressureM;
            double pressurePoint3 = pressureY1 + pressureZ2 - pressureM;
            double pressurePoint4 = pressureY1 + pressureZ1 - pressureM;

            var preasureEdge = Math.Max(Math.Max(pressureY1, pressureY2), Math.Max(pressureZ1, pressureZ2));

            double[] pressureArray = { pressureM, preasureEdge, pressurePoint1, pressurePoint2, pressurePoint3, pressurePoint4 };
            return pressureArray;
        }

        private string Check(Section section, double[] pressureArray, double[] loadEccentricity, double designPressure, string loadType)
        {
            var sb = new StringBuilder();
            var pressureEdgeFactor = 1.3;
            var pressureVertexFactor = 1.5;
            if (loadType == "DesigLoad")
            {
                return sb.ToString();
            }
            else if (loadType == "SeismicLoad")
            {
                pressureEdgeFactor = 4;
                pressureVertexFactor = 8;
                this.PressureCheck(pressureArray, designPressure, sb, pressureEdgeFactor, pressureVertexFactor);
                this.EccentricityCheck(section, loadEccentricity, sb, 4);
            }
            else
            {
                this.PressureCheck(pressureArray, designPressure, sb, pressureEdgeFactor, pressureVertexFactor);
                this.EccentricityCheck(section, loadEccentricity, sb, 6);
            }

            sb.AppendLine("PRESSURES: ");
            sb.Append(string.Join(", ", pressureArray));

            return sb.ToString().TrimEnd();
        }

        private void EccentricityCheck(Section section, double[] loadEccentricity, StringBuilder sb, int eccentricityFactor)
        {
            if (loadEccentricity[0] > (section.Width * GlobalConstants.mmToM / eccentricityFactor))
            {
                sb.AppendLine($"The eccentricity ey is greater than B/{eccentricityFactor}!");
            }

            if (loadEccentricity[1] > (section.Height * GlobalConstants.mmToM / eccentricityFactor))
            {
                sb.AppendLine($"The eccentricity ez is greater than L/{eccentricityFactor}!");
            }
        }

        private void PressureCheck(double[] pressureArray, double designPressure, StringBuilder sb, double pressureEdgeFactor, double pressureVertexFactor)
        {
            if (pressureArray[0] > designPressure)
            {
                sb.Append("Average pressure is biger than the bearing capacity.");
            }

            if (pressureArray[1] > designPressure * pressureEdgeFactor)
            {
                sb.AppendLine("The bearing capacity is lower than the EDGE pressure");
            }

            if (Math.Max(Math.Max(pressureArray[2], pressureArray[3]), Math.Max(pressureArray[4], pressureArray[5])) > (designPressure * pressureVertexFactor))
            {
                sb.AppendLine("The bearing capacity is lower than the VERTEX pressure");
            }

            if (sb.Length == 0)
            {
                sb.AppendLine("OK! The bearing capacity is greater than the pressure beneath");
            }
            else
            {
                sb.Insert(0, "NO!");
                sb.Insert(3, Environment.NewLine);
            }
        }
    }
}