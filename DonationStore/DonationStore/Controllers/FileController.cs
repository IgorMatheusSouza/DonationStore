using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Controllers
{
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        [HttpPost]
        public IActionResult UploadImage([FromForm] IFormFile filekey)
        {
            var fileName = Guid.NewGuid();
            var filePath = Directory.GetCurrentDirectory() + "\\DonationImgs\\" + fileName + ".jpg";

            if (filekey.Length > 0)
            {
                _ = CreateFile();
            }

            async Task CreateFile(){

                await Task.Run(() =>
                {
                    using var stream = System.IO.File.Create(filePath);
                    filekey.CopyToAsync(stream);
                });
            }

            return Ok(new { fileName, filePath });
        }
    }
}
