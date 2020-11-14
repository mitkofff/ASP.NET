namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Section
    {
        public int Id { get; set; }

        [Required]
        public SectionType Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Width { get; set; }

        public decimal? FlangeThickness { get; set; }

        public decimal? WebThickness { get; set; }

        public decimal Area { get; set; }

        public decimal InertialMomentY { get; set; }

        public decimal InertialMomentZ { get; set; }

        public decimal ResistanceMomentY { get; set; }

        public decimal ResistanceMomentZ { get; set; }

        public decimal InertialRadiusY { get; set; }

        public decimal InertialRadiusZ { get; set; }
    }
}
