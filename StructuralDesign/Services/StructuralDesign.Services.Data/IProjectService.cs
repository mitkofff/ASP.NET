namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StructuralDesign.Web.ViewModels.Projects;

    public interface IProjectService
    {
        Task CreateAsync(CreateProjectViewModel input, string ownerId);

        IList<T> GetAllProjectOfCurrentUser<T>(int page, int itemsPerPage, string ownerId);

        int GetProjectsCountPerUser(string ownerId);
        public DetailsViewModel Details(string id);
    }
}
