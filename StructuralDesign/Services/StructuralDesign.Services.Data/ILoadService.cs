namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Load;

    public interface ILoadService
    {
        Task<int> CreateAsync(CreateLoadInputModel input);

        Task EditAsync(int id, CreateLoadInputModel input);

        Load GetSectionById(int id);
    }
}
