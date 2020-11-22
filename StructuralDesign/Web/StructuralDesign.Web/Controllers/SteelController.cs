namespace StructuralDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SteelController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

    }
}
