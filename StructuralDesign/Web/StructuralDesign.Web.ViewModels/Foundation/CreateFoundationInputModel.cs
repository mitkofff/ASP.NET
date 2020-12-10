namespace StructuralDesign.Web.ViewModels.Foundation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public class CreateFoundationInputModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        public int SectionId { get; set; }

        [Required]
        [Range(0, 3000)]
        public double HeightOfFoundament { get; set; }

        [Range(0, 3000)]
        public double HeightOfBackFill { get; set; }

        public int LoadId { get; set; }

        public string Result { get; set; }

        public int SoilId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Soils { get; set; }

        public int ConcreteId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Concretes { get; set; }

        public int MaterialRebarId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ReinforcemenrsMaterial { get; set; }

        public string ProjectId { get; set; }

        public CreatLoadInputModel CreatLoad { get; set; }

        public CreateSectionInputModel CreateSection { get; set; }

    }
}
