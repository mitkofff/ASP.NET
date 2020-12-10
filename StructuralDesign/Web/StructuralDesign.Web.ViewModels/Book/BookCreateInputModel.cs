namespace StructuralDesign.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class BookCreateInputModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        [Required]

        public IFormFile Document { get; set; }

        public string OwnerId { get; set; }
    }
}
