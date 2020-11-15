namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialConcrete : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal VolumeWeight { get; set; }

        [Required]
        public decimal DesignCompressiveStrength { get; set; }

        [Required]
        public decimal DesignTensionStrength { get; set; }

        [Required]
        public decimal ModulusOfElasticity { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
