namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bolt
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int NominalDiameter { get; set; }

        [Required]
        public decimal NetoDiameter { get; set; }

        [Required]
        public decimal GrossArea { get; set; }

        [Required]
        public decimal NetoArea { get; set; }
    }
}
