namespace StructuralDesign.Services.Data
{
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Models;
    using StructuralDesign.Web.ViewModels.Home;
    using System.Linq;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;
        private readonly IDeletableEntityRepository<Project> projectsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Section> sectionsRepository;

        public GetCountsService(
            IDeletableEntityRepository<Book> booksRepository,
            IDeletableEntityRepository<Project> projectsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Section> sectionsRepository)
        {
            this.booksRepository = booksRepository;
            this.projectsRepository = projectsRepository;
            this.usersRepository = usersRepository;
            this.sectionsRepository = sectionsRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                CountOfBooks = this.booksRepository.All().Count(),
                CountOfProjects = this.projectsRepository.All().Count(),
                CountOfRegistratedUsers = this.usersRepository.All().Count(),
                CountOfSections = this.sectionsRepository.All().Count(),
            };

            return data;
        }
    }
}
