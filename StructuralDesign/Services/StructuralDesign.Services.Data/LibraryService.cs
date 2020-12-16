namespace StructuralDesign.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;
    using StructuralDesign.Web.ViewModels.Book;

    public class LibraryService : ILibraryService
    {
        private readonly IDeletableEntityRepository<Book> bookRepository;

        public LibraryService(IDeletableEntityRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task CreateAsync(Cloudinary cloudinary, BookCreateInputModel input, string ownerId)
        {
            var url = this.UploadAsync(cloudinary, input.Document).Result;

            var book = new Book
            {
                Name = input.Name,
                Description = input.Description,
                OwnerId = ownerId,
                FilePath = url,
            };

            await this.bookRepository.AddAsync(book);
            await this.bookRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBooks<T>()
        {
            return this.bookRepository.AllAsNoTracking()
                        .Where(x => x.IsApproved == true)
                        .OrderByDescending(x => x.Name)
                        .To<T>()
                        .ToList();
        }

        public T GetById<T>(int id)
        {
            return this.bookRepository.AllAsNoTracking()
                        .Where(x => x.IsApproved == true)
                        .Where(x => x.Id == id)
                        .To<T>()
                        .FirstOrDefault();
        }

        public async Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file)
        {
            byte[] uploadedDocument;
            string resultUrl;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadedDocument = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(uploadedDocument))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var result = await cloudinary.UploadAsync(uploadParams);
                resultUrl = result.Uri.AbsoluteUri;
            }

            var url = resultUrl;
            if (resultUrl.Substring(0, 5) == "http:")
            {
                url = "https:" + resultUrl.Substring(5, resultUrl.Length-5);
            }

            return url;
        }
    }
}
