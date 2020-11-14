using System.ComponentModel.DataAnnotations;

namespace StructuralDesign.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        [Required]
        public string FilePath { get; set; }
    }
}
