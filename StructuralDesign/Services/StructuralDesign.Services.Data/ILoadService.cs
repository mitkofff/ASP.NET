namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Load;

    public interface ILoadService
    {
        Task CreateAsync(CreatLoadInputModel input);
    }
}
