namespace StructuralDesign.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Sections;
    using StructuralDesign.Web.ViewModels.Section;

    public class SectionsService : ISectionsService
    {
        private readonly IDeletableEntityRepository<Section> sectionRepository;

        public SectionsService(IDeletableEntityRepository<Section> sectionRepository)
        {
            this.sectionRepository = sectionRepository;
        }

        public async Task<int> CreateAsync(CreateSectionInputModel input)
        {
            var section = new Section
            {
                Type = (StructuralDesign.Data.Models.SectionType)input.SectionType,
                Name = input.SectionName,
                Height = input.Height,
                Width = input.Width,
                WebThickness = input.WebThickness,
                FlangeThickness = input.FlangeThickness,
                Area = 0,
                InertialMomentY = 0,
                InertialMomentZ = 0,
                InertialRadiusY = 0,
                InertialRadiusZ = 0,
                ResistanceMomentY = 0,
                ResistanceMomentZ = 0,
                StaticMomentY = 0,
                StaticMomentZ = 0,
            };
            if (section.Type.ToString() == "Rectangle")
            {
                var rectangle = new Rectangle(section.Height, section.Width);
                section.Area = rectangle.Area();
                section.InertialMomentY = rectangle.InertialMomentY();
                section.InertialMomentZ = rectangle.InertialMomentZ();
                section.InertialRadiusY = rectangle.InertialRadiusY();
                section.InertialRadiusZ = rectangle.InertialRadiusZ();
                section.ResistanceMomentY = rectangle.ResistanceMomentY();
                section.ResistanceMomentZ = rectangle.ResistanceMomentZ();
                section.StaticMomentY = rectangle.StaticMomentY();
                section.StaticMomentZ = rectangle.StaticMomentZ();
            }
            else if (section.Type.ToString() == "IPE")
            {
                var doubleT = new DoubleT(section.Height, section.Width, section.FlangeThickness, section.WebThickness);
                section.Area = doubleT.Area();
                section.InertialMomentY = doubleT.InertialMomentY();
                section.InertialMomentZ = doubleT.InertialMomentZ();
                section.InertialRadiusY = doubleT.InertialRadiusY();
                section.InertialRadiusZ = doubleT.InertialRadiusZ();
                section.ResistanceMomentY = doubleT.ResistanceMomentY();
                section.ResistanceMomentZ = doubleT.ResistanceMomentZ();
                section.StaticMomentY = doubleT.StaticMomentY();
                section.StaticMomentZ = doubleT.StaticMomentZ();
            }

            await this.sectionRepository.AddAsync(section);
            await this.sectionRepository.SaveChangesAsync();

            return section.Id;
        }

        public async Task EditAsync(int id, CreateSectionInputModel input)
        {
            var section = this.sectionRepository.All().Where(x => x.Id == id).FirstOrDefault();
            section.Name = input.SectionName;
            section.Height = input.Height;
            section.Width = input.Width;
            section.WebThickness = input.WebThickness;
            section.FlangeThickness = input.FlangeThickness;

            if (section.Type.ToString() == "Rectangle")
            {
                var rectangle = new Rectangle(section.Height, section.Width);
                section.Area = rectangle.Area();
                section.InertialMomentY = rectangle.InertialMomentY();
                section.InertialMomentZ = rectangle.InertialMomentZ();
                section.InertialRadiusY = rectangle.InertialRadiusY();
                section.InertialRadiusZ = rectangle.InertialRadiusZ();
                section.ResistanceMomentY = rectangle.ResistanceMomentY();
                section.ResistanceMomentZ = rectangle.ResistanceMomentZ();
                section.StaticMomentY = rectangle.StaticMomentY();
                section.StaticMomentZ = rectangle.StaticMomentZ();
            }
            else if (section.Type.ToString() == "IPE")
            {
                var doubleT = new DoubleT(section.Height, section.Width, section.FlangeThickness, section.WebThickness);
                section.Area = doubleT.Area();
                section.InertialMomentY = doubleT.InertialMomentY();
                section.InertialMomentZ = doubleT.InertialMomentZ();
                section.InertialRadiusY = doubleT.InertialRadiusY();
                section.InertialRadiusZ = doubleT.InertialRadiusZ();
                section.ResistanceMomentY = doubleT.ResistanceMomentY();
                section.ResistanceMomentZ = doubleT.ResistanceMomentZ();
                section.StaticMomentY = doubleT.StaticMomentY();
                section.StaticMomentZ = doubleT.StaticMomentZ();
            }

            await this.sectionRepository.SaveChangesAsync();
        }

        public Section GetSectionById(int id)
        {
            return this.sectionRepository.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
