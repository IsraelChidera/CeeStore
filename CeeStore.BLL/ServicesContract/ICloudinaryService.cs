using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace CeeStore.BLL.ServicesContract
{
    public interface ICloudinaryService
    {
        ImageUploadResult UploadImage(ImageUploadParams imageFile);
        bool DeleteImage(string imageFile);
    }
}
