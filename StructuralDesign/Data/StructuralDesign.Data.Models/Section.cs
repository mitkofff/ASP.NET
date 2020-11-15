namespace StructuralDesign.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class Section : BaseDeletableModel<int>
    {
        public Section()
        {
            this.Foundations = new HashSet<ElementFoundation>();
            this.SteelElements = new HashSet<ElementSteel>();
            this.ConcreteElements = new HashSet<ElementConcrete>();
        }

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

        public virtual ICollection<ElementFoundation> Foundations { get; set; }

        public virtual ICollection<ElementSteel> SteelElements { get; set; }

        public virtual ICollection<ElementConcrete> ConcreteElements { get; set; }
    }
}
