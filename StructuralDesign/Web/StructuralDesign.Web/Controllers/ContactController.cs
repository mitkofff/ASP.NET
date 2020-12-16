namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Services.Messaging;
    using StructuralDesign.Web.ViewModels.Contact;

    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IEmailSender emailSender;

        public ContactController(
            IContactService contactService, 
            IEmailSender emailSender)
        {
            this.contactService = contactService;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactInputModel input)
        {
            var message = contactService.Message(input);
            await this.emailSender.SendEmailAsync("dimitar_k@mail.bg", "StructuralDesign", "dimitar_k@mail.bg", input.Subject, message);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
