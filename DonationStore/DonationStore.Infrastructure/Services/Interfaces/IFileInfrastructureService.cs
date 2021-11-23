using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.Services.Interfaces
{
    public interface IFileInfrastructureService
    {
        Task<string> FileToBase64(IFormFile filekey);

        Task CreateFileAsync(IFormFile filekey, string LocalPath);

        Task<string> LoadImage(string name);
    }
}
