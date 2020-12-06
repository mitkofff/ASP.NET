namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;
    using StructuralDesign.Web.ViewModels.Foundation;
    using StructuralDesign.Web.ViewModels.Projects;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projectRepositoy;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<ElementFoundation> foundationRepository;

        public ProjectService(
            IDeletableEntityRepository<Project> projectRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<ElementFoundation> foundationRepository)
        {
            this.projectRepositoy = projectRepository;
            this.userRepository = userRepository;
            this.foundationRepository = foundationRepository;
        }

        public async Task CreateAsync(CreateProjectViewModel input, string ownerId)
        {
            var project = new Project
            {
                Name = input.Name,
                Description = input.Description,
                Location = input.Location,
                OwnerId = ownerId,
                Owner = this.userRepository.All().Where(x => x.Id == ownerId).FirstOrDefault(),
            };

            await this.projectRepositoy.AddAsync(project);
            await this.projectRepositoy.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var project = this.projectRepositoy.All().FirstOrDefault(x => x.Id == id);
            this.projectRepositoy.Delete(project);
            await this.projectRepositoy.SaveChangesAsync();
        }

        public DetailsViewModel Details(string id)
        {
            var project = this.projectRepositoy.All().Where(x => x.Id == id).Select(x => new DetailsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Description = x.Description,
                ConcreteElements = x.ConcreteElements,
                SteelElements = x.SteelElements,
                Foundations = this.foundationRepository.All().Where(x => x.ProjectId == id).Select(x => new FoundationShortInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SectionName = x.Section.Name,
                }).ToList(),
            }).FirstOrDefault();

            return project;
        }

        public IList<T> GetAllProjectOfCurrentUser<T>(int page, int itemsPerPage, string ownerId)
        {
            var projects = this.projectRepositoy.All().Where(x => x.OwnerId == ownerId)
                .OrderByDescending(x => x.ModifiedOn)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return projects;
        }

        public int GetProjectsCountPerUser(string ownerId)
        {
            return this.projectRepositoy.All().Where(x => x.OwnerId == ownerId).Count();
        }
    }
}
/*
                 .Select(x => new ProjectsPerUserViewModel
            {
                Name = x.Name,
                Location = x.Location,
                Description = x.Description,
                NumberOfElements = x.ConcreteElements.Count + x.SteelElements.Count + x.Foundations.Count,
                Id = x.Id,
            }) 
  
  */