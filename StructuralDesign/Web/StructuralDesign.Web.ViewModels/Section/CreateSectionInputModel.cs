namespace StructuralDesign.Web.ViewModels.Section
{
    using System.ComponentModel.DataAnnotations;

    public class CreateSectionInputModel
    {
        [Required]
        public SectionType SectionType { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        [Range(0, 2000)]
        public double Height { get; set; }

        [Required]
        [Range(0, 2000)]
        public double Width { get; set; }

        public double FlangeThickness { get; set; }

        public double WebThickness { get; set; }

    }
}
