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
        public double Height { get; set; }

        [Required]
        public double Width { get; set; }

        public double FlangeThickness { get; set; }

        public double WebThickness { get; set; }

        public double Area { get; set; }

        public double InertialMomentY { get; set; }

        public double InertialMomentZ { get; set; }

        public double ResistanceMomentY { get; set; }

        public double ResistanceMomentZ { get; set; }

        public double InertialRadiusY { get; set; }

        public double InertialRadiusZ { get; set; }

        public virtual ICollection<ElementFoundation> Foundations { get; set; }

        public virtual ICollection<ElementSteel> SteelElements { get; set; }

        public virtual ICollection<ElementConcrete> ConcreteElements { get; set; }
    }
}
