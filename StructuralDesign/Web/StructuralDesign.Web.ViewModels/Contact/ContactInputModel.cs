using System.ComponentModel.DataAnnotations;

namespace StructuralDesign.Web.ViewModels.Contact
{
    public class ContactInputModel
    {
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [Required]
        public string Email { get; set; }

        [MinLength(3)]
        [Required]
        public string Subject { get; set; }

        [MinLength(10)]
        [Required]
        public string Text { get; set; }
    }
}
