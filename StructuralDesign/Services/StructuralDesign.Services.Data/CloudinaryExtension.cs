using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;

using System.Threading.Tasks;

namespace StructuralDesign.Services.Data
{
    class CloudinaryExtension
    {
        public static async Task UploadAsync(Cloudinary cloudinary, IFormFile file)
        {
            byte[] uploadedImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadedImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(uploadedImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                await cloudinary.UploadAsync(uploadParams);
            }
        }
    }
}
