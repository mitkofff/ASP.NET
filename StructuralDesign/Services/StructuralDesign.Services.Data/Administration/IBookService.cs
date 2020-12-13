namespace StructuralDesign.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Administration;

    public interface IBookService
    {
        IList<T> GetAllPBooks<T>(int page, int itemsPerPage);

        int GetBooksCount();

        AdmDeleteViewModel DeleteView(int id);

        Task DeleteConfirmed(int id);
    }
}
