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
            this.Elements = new HashSet<Element>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        public string Location { get; set; }

        [Required]
        public ICollection<Element> Elements {get; set; }

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
