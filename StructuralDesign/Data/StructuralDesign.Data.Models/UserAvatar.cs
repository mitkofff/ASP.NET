namespace StructuralDesign.Data.Models
{
    using System;

    using StructuralDesign.Data.Common.Models;

    public class UserAvatar : BaseDeletableModel<string>
    {
        public UserAvatar()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Extension { get; set; }
    }
}
