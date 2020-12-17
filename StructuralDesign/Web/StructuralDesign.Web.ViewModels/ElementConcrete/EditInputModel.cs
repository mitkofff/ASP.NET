namespace StructuralDesign.Web.ViewModels.ElementConcrete
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public class EditInputModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(0, 15000)]
        public double Length { get; set; }

        public string ProjectId { get; set; }

        public int SectionId { get; set; }

        public BoundaryCondition LeftBoundaryCondition { get; set; }

        public BoundaryCondition RightBoundaryCondition { get; set; }

        public CreateSectionInputModel CreateSection { get; set; }

        public string SectionTypeString => this.CreateSection.SectionType.ToString();

        public int LoadId { get; set; }

        public CreateLoadInputModel CreatLoad { get; set; }

        public string Result { get; set; }

        public int ConcreteId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Concretes { get; set; }

        public int MaterialRebarId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ReinforcemenrsMaterial { get; set; }

        public int ReinforcementBarId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ReinforcementBar { get; set; }
    }
}
