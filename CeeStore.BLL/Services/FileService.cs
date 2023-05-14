using CeeStore.BLL.ServicesContract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.Services
{
    public class FileService : IFileService
    {
        
        

        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var file = imageFile;

            if (file == null || file.Length == 0)
            {
                throw new NotImplementedException("No file has been uploaded");
            }

            string path = "";
            if (file.Length > 0)
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    
                    await file.CopyToAsync(fileStream);
                }
            }

            return path;

        }
    }
}
