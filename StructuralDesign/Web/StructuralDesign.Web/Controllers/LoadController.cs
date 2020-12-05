namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Load;

    [Authorize]
    public class LoadController : Controller
    {
        private readonly ILoadService loadService;

        public LoadController(ILoadService loadService)
        {
            this.loadService = loadService;
        }

        public IActionResult Create()
        {
            return this.View("~/Views/Load/_LoadCreate.cshtml");
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreatLoadInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.loadService.CreateAsync(input);
            return this.Redirect("/");
        }
    }
}
