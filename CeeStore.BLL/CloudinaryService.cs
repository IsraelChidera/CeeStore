using CeeStore.BLL.Services;
using CeeStore.BLL.ServicesContract;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CeeStore.BLL
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;  

        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            var account = new Account(
                cloudinarySettings.Value.CloudName,
                cloudinarySettings.Value.ApiKey,
                cloudinarySettings.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public bool DeleteImage(string imageFile)
        {
            throw new NotImplementedException();
        }

        public ImageUploadResult UploadImage(ImageUploadParams imageFile)
        {
            var result =  _cloudinary.Upload(imageFile);
            return result;                
        }
    }
}
