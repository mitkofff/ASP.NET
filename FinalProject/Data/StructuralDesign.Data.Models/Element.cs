namespace StructuralDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class Element : BaseDeletableModel<string>
    {
        public Element()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Loads = new HashSet<Load>();
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public int SectionMaterialId { get; set; }

        public Material SectionMaterial { get; set; }

        public decimal? Length { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public int BoltId { get; set; }

        public Bolt Bolt { get; set; }

        public int BoltMaterialId { get; set; }

        public Material BoltMaterial { get; set; }

        public decimal? ResultFactor { get; set; }

        public string Description { get; set; }

        public string Result { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
