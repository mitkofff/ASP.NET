namespace StructuralDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class ElementSteel : BaseDeletableModel<string>
    {
        public ElementSteel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Loads = new HashSet<Load>();
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public int SteelId { get; set; }

        public MaterialSteel Steel { get; set; }

        public double Length { get; set; }

        public BoundaryCondition LeftBoundaryCondition { get; set; }

        public BoundaryCondition RightBoundaryCondition { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public int BoltId { get; set; }

        public ElementBolt Bolt { get; set; }

        public int MaterialBoltId { get; set; }

        public MaterialSteel MaterialBolt { get; set; }

        public double? ResultFactor { get; set; }

        public string Result { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
