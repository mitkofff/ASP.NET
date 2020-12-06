namespace StructuralDesign.Data.Models
{
    using System;
    using System.Collections.Generic;

    using StructuralDesign.Data.Common.Models;

    public class ProjectAvatar : BaseDeletableModel<string>
    {
        public ProjectAvatar()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ProjectId { get; set; }

        public virtual Project Projects { get; set; }

        public string Extension { get; set; }

    }
}
