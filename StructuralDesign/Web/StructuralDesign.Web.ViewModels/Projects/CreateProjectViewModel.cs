using System.ComponentModel.DataAnnotations;

namespace StructuralDesign.Web.ViewModels.Projects
{
    public class CreateProjectViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        [MinLength(2)]
        public string Location { get; set; }
    }
}
