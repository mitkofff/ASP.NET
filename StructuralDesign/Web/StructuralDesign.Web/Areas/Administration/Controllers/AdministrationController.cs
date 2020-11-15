namespace StructuralDesign.Web.Areas.Administration.Controllers
{
    using StructuralDesign.Common;
    using StructuralDesign.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
