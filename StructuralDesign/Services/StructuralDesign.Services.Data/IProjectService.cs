namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Projects;

    public interface IProjectService
    {
        int GetProjectsCountPerUser(string ownerId);

        Task CreateAsync(CreateProjectViewModel input, string ownerId);

        public DetailsViewModel Details(string id);

        Task DeleteAsync(string id);

        IList<T> GetAllProjectOfCurrentUser<T>(int page, int itemsPerPage, string ownerId);

    }
}
