namespace StructuralDesign.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class BookService : IBookService
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public BookService(
            IDeletableEntityRepository<Book> bookRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public IList<T> GetAllPBooks<T>(int page, int itemsPerPage)
        {
            var books = this.bookRepository.All()
                .OrderByDescending(x => x.ModifiedOn)
                .ThenBy(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return books;
        }

        public int GetBooksCount()
        {
            return this.bookRepository.All().Count();
        }
    }
}
