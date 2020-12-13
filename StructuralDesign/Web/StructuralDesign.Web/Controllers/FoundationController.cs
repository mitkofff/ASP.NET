namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Foundation;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    [Authorize]
    public class FoundationController : Controller
    {
        private readonly ISoilService soilService;
        private readonly IConcreteService concreteService;
        private readonly IReinforcementService reinforcementController;
        private readonly IFoundationService foundationService;
        private readonly ILogger logger;

        public FoundationController(
            ISoilService soilService,
            IConcreteService concreteService,
            IReinforcementService reinforcementController,
            IFoundationService foundationService, 
            ILogger<FoundationController> logger)
        {
            this.soilService = soilService;
            this.concreteService = concreteService;
            this.reinforcementController = reinforcementController;
            this.foundationService = foundationService;
            this.logger = logger;
        }

        public IActionResult Create()
        {
            this.logger.LogInformation(1579, "User try to create foundation");
            var viewModel = new CreateFoundationInputModel();
            viewModel.Soils = this.soilService.GetAllAsKeyValuePairs();
            viewModel.Concretes = this.concreteService.GetAllAsKeyValuePairs();
            viewModel.ReinforcemenrsMaterial = this.reinforcementController.GetAllElementsAsKeyValue();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoundationInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id)
        {
            if (!this.ModelState.IsValid)
            {
                input.Soils = this.soilService.GetAllAsKeyValuePairs();
                input.Concretes = this.concreteService.GetAllAsKeyValuePairs();
                input.ReinforcemenrsMaterial = this.reinforcementController.GetAllElementsAsKeyValue();
                return this.View(input);
            }

            string foundationId = await this.foundationService.CreateAsync(input, inputLoad, inputSection, id);
            await this.foundationService.AddResultAsync(foundationId);

            return this.RedirectToAction("Details", "Project", new { id = id });
        }

        public IActionResult Edit(string id)
        {
            var inputModel = this.foundationService.GetById(id);
            inputModel.Soils = this.soilService.GetAllAsKeyValuePairs();
            inputModel.Concretes = this.concreteService.GetAllAsKeyValuePairs();
            inputModel.ReinforcemenrsMaterial = this.reinforcementController.GetAllElementsAsKeyValue();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditFoundationInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            if (!this.ModelState.IsValid)
            {
                input.Soils = this.soilService.GetAllAsKeyValuePairs();
                input.Concretes = this.concreteService.GetAllAsKeyValuePairs();
                input.ReinforcemenrsMaterial = this.reinforcementController.GetAllElementsAsKeyValue();
                return this.View(input);
            }

            var projectId = await this.foundationService.EditAsync(input, inputLoad, inputSection, id);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }

        public IActionResult Result(string id)
        {
            var viewModel = this.foundationService.Result(id);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            string projectId = await this.foundationService.DeleteAsync(id);
            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }
    }
}
