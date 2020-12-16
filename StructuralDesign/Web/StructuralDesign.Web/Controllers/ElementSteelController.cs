namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.ElementSteel;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    [Authorize]
    public class ElementSteelController : Controller
    {
        private readonly ISteelService steelService;
        private readonly IBoltService boltService;
        private readonly IElementSteelService elementSteelService;

        public ElementSteelController(
            ISteelService steelService,
            IBoltService boltService,
            IElementSteelService elementSteelService
            )
        {
            this.steelService = steelService;
            this.boltService = boltService;
            this.elementSteelService = elementSteelService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateInputModel();
            viewModel.Steel = this.steelService.GetAllAsKeyValuePairs();
            viewModel.Bolts = this.boltService.GetAllAsKeyValuePairs();
            viewModel.MaterialBolts = this.steelService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id)
        {
            if (!this.ModelState.IsValid)
            {
                input.Steel = this.steelService.GetAllAsKeyValuePairs();
                input.Bolts = this.boltService.GetAllAsKeyValuePairs();
                input.MaterialBolts = this.steelService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            string elementSteelId = await this.elementSteelService.CreateAsync(input, inputLoad, inputSection, id);
            // await this.elementConcreteService.AddResultAsync(elementConcreteId);

            return this.RedirectToAction("Details", "Project", new { id = id });
        }

        public IActionResult Edit(string id)
        {
            var viewModel = this.elementSteelService.GetById(id);
            viewModel.Steel = this.steelService.GetAllAsKeyValuePairs();
            viewModel.Bolts = this.boltService.GetAllAsKeyValuePairs();
            viewModel.MaterialBolts = this.steelService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            if (!this.ModelState.IsValid)
            {
                input.Steel = this.steelService.GetAllAsKeyValuePairs();
                input.Bolts = this.boltService.GetAllAsKeyValuePairs();
                input.MaterialBolts = this.steelService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var projectId = await this.elementSteelService.EditAsync(id, input, inputLoad, inputSection);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }

        public IActionResult Result(string id)
        {
            var viewModel = this.elementSteelService.ResultObject(id);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var projectId = await this.elementSteelService.DeleteAsync(id);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }
    }
}
