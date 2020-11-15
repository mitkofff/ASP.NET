namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialRebar : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal YieldStrength { get; set; }

        [Required]
        public decimal PartialSafetyFactor { get; set; }

        [Required]
        public decimal VolumeWeight { get; set; }

        [Required]
        public decimal ModulusOfElasticity { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
