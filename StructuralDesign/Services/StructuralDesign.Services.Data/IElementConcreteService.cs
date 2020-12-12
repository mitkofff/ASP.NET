namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Load;
    using StructuralDesign.Web.ViewModels.Section;
    using StructuralDesign.Web.ViewModels.ElementConcrete;

    public interface IElementConcreteService
    {
        Task<string> CreateAsync(CreateConcreteColumnInputModel input, CreateLoadInputModel inputLoad, CreateSectionInputModel inputSection, string projectId);
    }
}
