namespace StructuralDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Web.ViewModels.Projects;

    public class ProjectController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProjectViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
