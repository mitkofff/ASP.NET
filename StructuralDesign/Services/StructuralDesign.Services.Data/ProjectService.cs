namespace StructuralDesign.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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

        public async Task CreateAsync(CreateProjectViewModel input, string ownerId, string avatarPath)
        {
            var allowedExtensions = new[] { "jpg", "png", "gif" };
            var project = new Project
            {
                Name = input.Name,
                Description = input.Description,
                Location = input.Location,
                OwnerId = ownerId,
                Owner = this.userRepository.All().Where(x => x.Id == ownerId).FirstOrDefault(),
            };

            var extension = Path.GetExtension(input.Image.FileName).TrimStart('.');
            if (!allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid file extension {extension}");
            }

            var projectAvatar = new ProjectAvatar
            {
                Project = project,
                Extension = extension,
            };

            Directory.CreateDirectory($"{avatarPath}");
            var physicalPath = $"{avatarPath}/{projectAvatar.Id}.{extension}";
            project.ProjectAvatar = projectAvatar;

            using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
            {
                await input.Image.CopyToAsync(fileStream);
            }

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
                ProjectAvatarUrl = x.ProjectAvatar.RemoteImageUrl != null ?
                        x.ProjectAvatar.RemoteImageUrl :
                        "/images/" + x.ProjectAvatar.Id + "." + x.ProjectAvatar.Extension,
                Foundations = this.foundationRepository.All().Where(x => x.ProjectId == id).Select(x => new FoundationShortInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SectionName = x.Section.Name,
                    Checking = x.Result.Substring(0, 3),
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