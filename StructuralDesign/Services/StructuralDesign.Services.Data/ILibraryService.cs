namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;
    using StructuralDesign.Web.ViewModels.Book;

    public interface ILibraryService
    {
        Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file);

        Task CreateAsync(Cloudinary cloudinary, BookCreateInputModel input, string ownerId);

        IEnumerable<T> GetAllBooks<T>();

        T GetById<T>(int id);
    }
}
