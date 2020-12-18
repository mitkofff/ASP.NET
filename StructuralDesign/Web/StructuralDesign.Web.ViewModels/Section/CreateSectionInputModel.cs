namespace StructuralDesign.Web.ViewModels.Section
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class CreateSectionInputModel : IMapFrom<Section>, IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((this.FlangeThickness * 2) >= this.Height)
            {
                yield return new ValidationResult("The Flange thickness should be smaller than half height of the section!");
            }

            if (this.WebThickness >= this.Width)
            {
                yield return new ValidationResult("The Web thickness should be smaller than width of the section!");
            }
        }
    }
}
