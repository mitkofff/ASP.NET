namespace StructuralDesign.Web.Areas.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Administration;
    using StructuralDesign.Web.Areas.Administration.Controllers;
    using StructuralDesign.Web.ViewModels.Administration;

    [Area("Administration")]
    public class BooksController : AdministrationController
    {

        private readonly IDeletableEntityRepository<Book> bookRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepostiory;
        private readonly IBookService bookService;

        public BooksController(IDeletableEntityRepository<Book> bookRepository,
            IDeletableEntityRepository<ApplicationUser> userRepostiory,
            IBookService bookService)
        {
            this.bookRepository = bookRepository;
            this.userRepostiory = userRepostiory;
            this.bookService = bookService;
        }

        // GET: Administration/Books
        public IActionResult Index(int id = 1)
        {
            if (id < 0)
            {
                return this.NotFound();
            }

            int booksPerPage = 5;

            var books = new AdmBooksListViewModel
            {
                BooksCount = this.bookService.GetBooksCount(),
                BooksPerPage = booksPerPage,
                PageNumber = id,
                Books = this.bookService.GetAllPBooks<AdmBookViewModel>(id, booksPerPage),
            };
            return this.View(books);
        }

        // GET: Administration/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = await this.bookRepository.All()
                .Include(b => b.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            return this.View(book);
        }

        // GET: Administration/Books/Create
        public IActionResult Create()
        {
            this.ViewData["OwnerId"] = new SelectList(this.userRepostiory.All(), "Id", "Id");

            return this.View();
        }

        // POST: Administration/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,FilePath,OwnerId,IsApproved,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Book book)
        {
            if (this.ModelState.IsValid)
            {
                await this.bookRepository.AddAsync(book);
                await this.bookRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["OwnerId"] = new SelectList(this.userRepostiory.All(), "Id", "Id", book.OwnerId);
            return this.View(book);
        }

        // GET: Administration/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = await this.bookRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.ViewData["OwnerId"] = new SelectList(this.userRepostiory.All(), "Id", "Id", book.OwnerId);
            return this.View(book);
        }

        // POST: Administration/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,FilePath,OwnerId,IsApproved,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Book book)
        {
            if (id != book.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.bookRepository.Update(book);
                    await this.bookRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BookExists(book.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["OwnerId"] = new SelectList(this.userRepostiory.All(), "Id", "Id", book.OwnerId);
            return this.View(book);
        }

        // GET: Administration/Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var book = this.bookService.DeleteView(id);
            if (book == null)
            {
                return this.NotFound();
            }

            return this.View(book);
        }

        // POST: Administration/Books/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.bookService.DeleteConfirmed(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BookExists(int id)
        {
            return this.bookRepository.All().Any(e => e.Id == id);
        }
    }
}
