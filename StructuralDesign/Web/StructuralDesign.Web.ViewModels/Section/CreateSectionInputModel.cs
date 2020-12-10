namespace StructuralDesign.Web.ViewModels.Section
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class CreateSectionInputModel : IMapFrom<Section>
    {
        [Required]
        public SectionType SectionType { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Height { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Width { get; set; }

        [Range(0, 10000)]
        public double FlangeThickness { get; set; }

        [Range(0, 10000)]
        public double WebThickness { get; set; }
    }
}
