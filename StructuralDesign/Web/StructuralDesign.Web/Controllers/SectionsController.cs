namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Section;

    [Authorize]
    public class SectionsController : Controller
    {
        private readonly ISectionsService sectionService;

        public SectionsController(ISectionsService sectionService)
        {
            this.sectionService = sectionService;
        }

        public IActionResult Create()
        {

            return this.View("~/Views/Section/_SectionCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSectionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.sectionService.CreateAsync(input);
            return this.Redirect("/");
        }
    }
}
