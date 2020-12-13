namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.ElementConcrete;
    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;

    public interface IElementConcreteService
    {
        Task<string> CreateAsync(CreateConcreteColumnInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId);

        ResultViewModel Result(string id);

        EditInputModel GetById(string id);

        Task<string> EditAsync(string id, EditInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection);

        Task<string> DeleteAsync(string id);
    }
}
