namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialSteel : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double YieldStrength { get; set; }

        [Required]
        public double UltimateTensile { get; set; }

        [Required]
        public double VolumeWeight { get; set; }

        [Required]
        public double ModulusOfElasticity { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
