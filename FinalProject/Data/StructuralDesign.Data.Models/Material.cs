namespace StructuralDesign.Data.Models
{
    using StructuralDesign.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Material : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal YieldStrength { get; set; }

        [Required]
        public decimal UltimateTensile { get; set; }
    }
}
