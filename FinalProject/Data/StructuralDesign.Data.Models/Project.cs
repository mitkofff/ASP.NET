namespace StructuralDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class Project : BaseDeletableModel<string>
    {
        public Project()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Foundations = new HashSet<ElementFoundation>();
            this.SteelElements = new HashSet<ElementSteel>();
            this.ConcreteElements = new HashSet<ElementConcrete>();
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ProjectAvatar ProjectAvatar { get; set; }

        [Required]
        [MinLength(3)]
        public string Location { get; set; }

        public virtual ICollection<ElementFoundation> Foundations {get; set; }

        public virtual ICollection<ElementSteel> SteelElements { get; set; }

        public virtual ICollection<ElementConcrete> ConcreteElements { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
