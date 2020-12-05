namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Foundation;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public interface IFoundationService
    {
        Task<string> CreateAsync(CreateFoundationInputModel input, CreatLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id);

        Task<string> EditAsync(CreateFoundationInputModel input, CreatLoadInputModel inputLoad, CreateSectionInputModel inputSection, string id);

        Task AddResultAsync(string foundamentId);
    }
}
