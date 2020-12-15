namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.ElementSteel;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public interface IElementSteelService
    {
        Task<string> CreateAsync(CreateInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId);

        ResultViewModel Result(string id);

        EditInputModel GetById(string id);

        Task<string> EditAsync(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection);

        Task<string> DeleteAsync(string id);
    }
}
