namespace StructuralDesign.Services.Data
{
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Sections;
    using StructuralDesign.Web.ViewModels.Section;
    using System.Threading.Tasks;

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
            }

            await this.sectionRepository.AddAsync(section);
            await this.sectionRepository.SaveChangesAsync();

            return section.Id;
        }
    }
}
