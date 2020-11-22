namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialSoil : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double VolumeWeight { get; set; }

        [Required]
        public double DesignPressure { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
