namespace StructuralDesign.Web.ViewModels.Administration
{
    using System;
    using System.Collections.Generic;

    public class AdmBooksListViewModel
    {
        public IEnumerable<AdmBookViewModel> Books { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.BooksCount / this.BooksPerPage);

        public int BooksCount { get; set; }

        public int BooksPerPage { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;
    }
}
