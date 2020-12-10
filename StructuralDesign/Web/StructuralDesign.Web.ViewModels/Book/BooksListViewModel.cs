namespace StructuralDesign.Web.ViewModels.Book
{
    using System.Collections.Generic;

    public class BooksListViewModel
    {
        public IEnumerable<BookInListViewModel> Books { get; set; }
    }
}
