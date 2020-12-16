namespace StructuralDesign.Services.Data
{
    using System.Text;

    using StructuralDesign.Web.ViewModels.Contact;

    public class ContactService : IContactService
    {
        public string Message(ContactInputModel input)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<h3>{input.Name}</h3>");
            sb.AppendLine($"<h3>{input.Email}</h3>");
            sb.AppendLine($" {input.Text}");

            return sb.ToString().TrimEnd();
        }
    }
}
