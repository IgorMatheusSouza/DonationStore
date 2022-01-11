using DonationStore.Application.Services.Abstractions;
using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.GenericMessages;
using DonationStore.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        private readonly IFileInfrastructureService InfrastructureService;

        public FileController(IFileInfrastructureService infrastructureService, IUserService userService) : base(userService)
        {
            InfrastructureService = infrastructureService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile filekey)
        {
            var fileName = Guid.NewGuid().ToString();

            if (filekey.Length > 0)
            {
                string fileUrl = SystemConstantValues.BlobUrl + fileName + SystemConstantValues.ImageExtension;
                await InfrastructureService.CreateFileAsync(filekey, fileName); 
                return OkCreated(new { fileName, fileUrl });
            }

            return ReturnError(HttpStatusCode.BadRequest, ErrorMessages.InvalidFile);
        }
    }
}
