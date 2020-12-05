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


        public IActionResult All(int id)
        {
            const int projectsPerPage = 10;
            string ownerId = this.userManager.GetUserId(this.User);
            var projects = new ProjectsListViewModel
            {
                Projects = this.projectService.GetAllProjectOfCurrentUser<ProjectsPerUserViewModel>(id, projectsPerPage, ownerId),
                ProjectsCountPerUser = this.projectService.GetProjectsCountPerUser(ownerId),
                ProjectsPerPage = projectsPerPage,
            };
            return this.View(projects);
        }


        public IActionResult Details(string id)
        {
            var project = this.projectService.Details(id);
            return this.View(project);
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
            await this.projectService.CreateAsync(input, ownerId);
            return this.Redirect("/");
        }
    }
}
