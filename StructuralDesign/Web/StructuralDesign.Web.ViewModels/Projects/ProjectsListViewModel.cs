namespace StructuralDesign.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;

    public class ProjectsListViewModel
    {
        public IEnumerable<ProjectsPerUserViewModel> Projects { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.ProjectsCountPerUser / this.ProjectsPerPage);

        public int ProjectsCountPerUser { get; set; }

        public int ProjectsPerPage { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;
    }
}
