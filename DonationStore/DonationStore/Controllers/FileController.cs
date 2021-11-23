using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.GenericMessages;
using DonationStore.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        private readonly IFileInfrastructureService InfrastructureService;

        public FileController(IFileInfrastructureService infrastructureService)
        {
            InfrastructureService = infrastructureService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile filekey)
        {
            var fileName = Guid.NewGuid();
            var LocalPath = Directory.GetCurrentDirectory() + SystemConstantValues.ImageFolder + fileName + SystemConstantValues.ImageExtension;

            if (filekey.Length > 0)
            {
                string file = await InfrastructureService.FileToBase64(filekey);
                _ = InfrastructureService.CreateFileAsync(filekey, LocalPath);

                return OkCreated(new { fileName, file });
            }

            return ReturnError(HttpStatusCode.BadRequest, ErrorMessages.InvalidFile);
        }
    }
}
