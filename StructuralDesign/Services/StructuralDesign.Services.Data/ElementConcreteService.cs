namespace StructuralDesign.Services.Data
{
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
                ReinforcementBarId = input.ReinforcementBarId
            };

            await this.elementConcreteRepository.AddAsync(concreteElement);
            await this.elementConcreteRepository.SaveChangesAsync();

            return concreteElement.Id;
        }


    }
}
