namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.ElementConcrete;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    [Authorize]
    public class ElementConcreteController : Controller
    {
        private readonly IConcreteService concreteService;
        private readonly IReinforcementService reinforcementService;
        private readonly IReinforcementBarService reinforcementBarService;
        private readonly IElementConcreteService elementConcreteService;

        public ElementConcreteController(
            IConcreteService concreteService,
            IReinforcementService reinforcementService,
            IReinforcementBarService reinforcementBarService,
            IElementConcreteService elementConcreteService)
        {
            this.concreteService = concreteService;
            this.reinforcementService = reinforcementService;
            this.reinforcementBarService = reinforcementBarService;
            this.elementConcreteService = elementConcreteService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateConcreteColumnInputModel();
            viewModel.Concretes = this.concreteService.GetAllAsKeyValuePairs();
            viewModel.ReinforcemenrsMaterial = this.reinforcementService.GetAllElementsAsKeyValue();
            viewModel.ReinforcementBar = this.reinforcementBarService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConcreteColumnInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id)
        {
            if (!this.ModelState.IsValid)
            {
                input.Concretes = this.concreteService.GetAllAsKeyValuePairs();
                input.ReinforcemenrsMaterial = this.reinforcementService.GetAllElementsAsKeyValue();
                input.ReinforcementBar = this.reinforcementBarService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            string elementConcreteId = await this.elementConcreteService.CreateAsync(input, inputLoad, inputSection, id);

            return this.RedirectToAction("Details", "Project", new { id = id });
        }

        public IActionResult Edit(string id)
        {
            var viewModel = this.elementConcreteService.GetById(id);
            viewModel.Concretes = this.concreteService.GetAllAsKeyValuePairs();
            viewModel.ReinforcemenrsMaterial = this.reinforcementService.GetAllElementsAsKeyValue();
            viewModel.ReinforcementBar = this.reinforcementBarService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection)
        {
            if (!this.ModelState.IsValid)
            {
                input.Concretes = this.concreteService.GetAllAsKeyValuePairs();
                input.ReinforcemenrsMaterial = this.reinforcementService.GetAllElementsAsKeyValue();
                input.ReinforcementBar = this.reinforcementBarService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var projectId = await this.elementConcreteService.EditAsync(id, input, inputLoad, inputSection);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }

        public IActionResult Result(string id)
        {
            var viewModel = this.elementConcreteService.Result(id);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var projectId = await this.elementConcreteService.DeleteAsync(id);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }
    }
}
