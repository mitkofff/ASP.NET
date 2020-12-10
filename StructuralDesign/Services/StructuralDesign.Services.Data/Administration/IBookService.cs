namespace StructuralDesign.Services.Data.Administration
{
    using System.Collections.Generic;

    public interface IBookService
    {
        IList<T> GetAllPBooks<T>(int page, int itemsPerPage);

        int GetBooksCount();
    }
}
