namespace StructuralDesign.Services.Data
{
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Section;

    public interface ISectionsService
    {
        Task<int> CreateAsync(CreateSectionInputModel input);
    }
}
