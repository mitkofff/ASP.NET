namespace StructuralDesign.Web.Controllers
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Services.Data;
    using StructuralDesign.Web.ViewModels.Book;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    public class LibraryController : Controller
    {
        private readonly ILibraryService libraryService;
        private readonly Cloudinary cloudinary;

        public LibraryController(ILibraryService libraryService, Cloudinary cloudinary)
        {
            this.libraryService = libraryService;
            this.cloudinary = cloudinary;
        }

        public IActionResult All()
        {
            var viewModel = new BooksListViewModel
            {
                Books = this.libraryService.GetAllBooks<BookInListViewModel>(),
            };

            return this.View(viewModel);
        }


        public IActionResult Read(int id)
        {
            var book = this.libraryService.GetById<BookReadModeViewModel>(id);

            return this.View(book);
        }

        public IActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(BookCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var ownerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.libraryService.CreateAsync(this.cloudinary, input, ownerId);

            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Book(BookCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var ownerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.libraryService.CreateAsync(this.cloudinary, input, ownerId);

            return this.Redirect("/");
        }

    }
}
