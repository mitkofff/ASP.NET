namespace StructuralDesign.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Projects;

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectController(
            IProjectService projectService,
            IWebHostEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            this.projectService = projectService;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            if (id < 0)
            {
                return this.NotFound();
            }

            const int projectsPerPage = 5;
            string ownerId = this.userManager.GetUserId(this.User);
            var projects = new ProjectsListViewModel
            {
                ProjectsPerPage = projectsPerPage,
                PageNumber = id,
                ProjectsCountPerUser = this.projectService.GetProjectsCountPerUser(ownerId),
                Projects = this.projectService.GetAllProjectOfCurrentUser<ProjectsPerUserViewModel>(id, projectsPerPage, ownerId),
            };

            return this.View(projects);
        }

        public IActionResult Details(string id)
        {
            var project = this.projectService.Details(id);
            return this.View(project);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.projectService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            string ownerId = this.userManager.GetUserId(this.User);
            string avatarPath = $"{this.hostingEnvironment.WebRootPath}/images";

            try
            {
                await this.projectService.CreateAsync(input, ownerId, avatarPath);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.All), 1);
        }
    }
}
