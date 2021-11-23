using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.Services.File
{
    public class FileInfrastructureService : IFileInfrastructureService
    {
        private readonly string ImagesPath = Directory.GetCurrentDirectory() + SystemConstantValues.ImageFolder;

        public async Task<string> LoadImage(string name) 
        {
            byte[] AsBytes = await System.IO.File.ReadAllBytesAsync(ImagesPath + name + SystemConstantValues.ImageExtension);
            return Convert.ToBase64String(AsBytes);
        }

        public async Task<string> FileToBase64(IFormFile filekey) 
        {
            using var ms = new MemoryStream();
            await filekey.CopyToAsync(ms);
            var fileBytes = ms.ToArray();
            string file = Convert.ToBase64String(fileBytes);
            return file;
        }

        public async Task CreateFileAsync(IFormFile filekey, string LocalPath)
        {
            await Task.Run(async () =>
            {
                using var stream = System.IO.File.Create(LocalPath);
                await filekey.CopyToAsync(stream);
            });
        }
    }
}
