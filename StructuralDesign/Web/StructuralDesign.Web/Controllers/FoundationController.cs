namespace StructuralDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Foundation;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;
    using System.Threading.Tasks;

    [Authorize]
    public class FoundationController : Controller
    {
        private readonly ISoilService soilService;
        private readonly IConcreteService concreteService;
        private readonly IReinforcementController reinforcementController;
        private readonly IFoundationService foundationService;
        private readonly ILogger logger;

        public FoundationController(
            ISoilService soilService,
            IConcreteService concreteService,
            IReinforcementController reinforcementController,
            IFoundationService foundationService, 
            ILogger<FoundationController> logger)
        {
            this.soilService = soilService;
            this.concreteService = concreteService;
            this.reinforcementController = reinforcementController;
            this.foundationService = foundationService;
            this.logger = logger;
        }

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(CreateFoundationInputModel input, CreatLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id)
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
    }
}
