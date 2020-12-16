namespace StructuralDesign.Services.Data
{
    using StructuralDesign.Web.ViewModels.Contact;

    public interface IContactService
    {
        string Message(ContactInputModel input);
    }
}
