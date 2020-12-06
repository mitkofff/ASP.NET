namespace StructuralDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Projects;
    using StructuralDesign.Data.Models;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectController(
            IProjectService projectService,
            UserManager<ApplicationUser> userManager)
        {
            this.projectService = projectService;
            this.userManager = userManager;
        }


        public IActionResult All(int id = 1)
        {
            if (id < 0)
            {
                return this.NotFound();
            }

            const int projectsPerPage = 10;
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
            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            string ownerId = this.userManager.GetUserId(this.User);
            await this.projectService.CreateAsync(input, ownerId);
            return this.Redirect("/");
        }
    }
}
