using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IFileService
    {
        Task<string> UploadImage(IFormFile imageFile);
        bool DeleteImage(string imageFile);
    }
}
