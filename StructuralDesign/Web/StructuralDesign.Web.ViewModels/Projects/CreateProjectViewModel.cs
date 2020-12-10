namespace StructuralDesign.Web.ViewModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using StructuralDesign.Data.Models;

    public class CreateProjectViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Location { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public IFormFile Image { get; set; }
    }
}
