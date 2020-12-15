namespace StructuralDesign.Web.ViewModels.ElementSteel
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

        public CreateSectionInputModel CreateSection { get; set; }

        public BoundaryCondition LeftBoundaryCondition { get; set; }

        public BoundaryCondition RightBoundaryCondition { get; set; }

        public int LoadId { get; set; }

        public CreateLoadInputModel CreatLoad { get; set; }

        public int SteelId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Steel { get; set; }

        public int BoltId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Bolts { get; set; }

        public int MaterialBoltId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MaterialBolts { get; set; }
    }
}