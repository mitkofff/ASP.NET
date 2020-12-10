using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;

using System.Threading.Tasks;

namespace StructuralDesign.Services.Data
{/*
    public class CloudinaryExtension
    {
        public static async Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file)
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

            return resultUrl;
        }
    }*/
}
