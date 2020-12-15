
namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class ElementBolt : BaseModel<int>
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int NominalDiameter { get; set; }

        [Required]
        public double NetoDiameter { get; set; }

        [Required]
        public double GrossArea => this.NominalDiameter * this.NominalDiameter * 3.14 / 400;

        [Required]
        public double NetoArea { get; set; }
    }
}
