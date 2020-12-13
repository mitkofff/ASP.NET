namespace StructuralDesign.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;
    using StructuralDesign.Web.ViewModels.Administration;

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

        public T GetBookById<T>(int id)
        {
            var book = this.bookRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return book;
        }

        public int GetBooksCount()
        {
            return this.bookRepository.All().Count();
        }

        public AdmDeleteViewModel DeleteView(int id)
        {
            return this.GetBookById<AdmDeleteViewModel>(id);
        }

        public async Task DeleteConfirmed(int id)
        {
            var book = await this.bookRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.bookRepository.Delete(book);
            await this.bookRepository.SaveChangesAsync();
        }
    }
}
