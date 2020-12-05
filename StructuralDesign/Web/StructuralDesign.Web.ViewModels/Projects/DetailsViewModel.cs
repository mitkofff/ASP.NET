namespace StructuralDesign.Web.ViewModels.Projects
{
    using System.Collections.Generic;

    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Foundation;

    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            this.Foundations = new HashSet<FoundationShortInfoViewModel>();
            this.SteelElements = new HashSet<ElementSteel>();
            this.ConcreteElements = new HashSet<ElementConcrete>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string OwnerId { get; set; }

        public virtual ICollection<FoundationShortInfoViewModel> Foundations { get; set; }

        public virtual ICollection<ElementSteel> SteelElements { get; set; }

        public virtual ICollection<ElementConcrete> ConcreteElements { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}