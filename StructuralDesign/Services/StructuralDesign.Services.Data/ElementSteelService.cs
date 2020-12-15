namespace StructuralDesign.Services.Data
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                SectionId = sectionId,
                Section = this.sectionsService.GetSectionById(sectionId),
            };

            await this.elementSteelRepository.AddAsync(steelElement);
            await this.elementSteelRepository.SaveChangesAsync();

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
                    AxialForce = x.Load.AxialForce,
                },
            }).FirstOrDefault();
            return elementConcrete;
        }

        public async Task<string> EditAsync(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            var elementConcrete = this.elementSteelRepository.All().Where(x => x.Id == id).FirstOrDefault();

            elementConcrete.Name = input.Name;
            elementConcrete.Length = input.Length;
            elementConcrete.LeftBoundaryCondition = input.LeftBoundaryCondition;
            elementConcrete.RightBoundaryCondition = input.RightBoundaryCondition;
            elementConcrete.SteelId = input.SteelId;
            elementConcrete.BoltId = input.BoltId;
            elementConcrete.MaterialBoltId = input.MaterialBoltId;

            await this.sectionsService.EditAsync(elementConcrete.SectionId, inputSection);
            await this.loadService.EditAsync(elementConcrete.LoadId, inputLoad);

            await this.elementSteelRepository.SaveChangesAsync();

            return elementConcrete.ProjectId;
        }

        public ResultViewModel Result(string id)
        {
            var result = this.elementSteelRepository.All().Where(x => x.Id == id).Select(x => new ResultViewModel
            {
                Name = x.Name,
                SectionHeight = x.Section.Height,
                SectionWidth = x.Section.Width,
                SectionArea = x.Section.Area,
                Length = x.Length,
                LeftBoundaryCondition = x.LeftBoundaryCondition.ToString(),
                RightBoundaryCondition = x.RightBoundaryCondition.ToString(),
            }).FirstOrDefault();

            return result;
        }
    }
}
