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
        public async Task<IActionResult> UploadImage([FromForm] IFormFile filekey)
        {
            var fileName = Guid.NewGuid();
            var LocalPath = Directory.GetCurrentDirectory() + "\\DonationImgs\\" + fileName + ".jpg";

            using var ms = new MemoryStream();
            await filekey.CopyToAsync(ms);
            var fileBytes = ms.ToArray();
            string file = Convert.ToBase64String(fileBytes);

            if (filekey.Length > 0)
            {
                _ = CreateFile();
            }

            async Task CreateFile()
            {
                await Task.Run(async () =>
                {
                    using var stream = System.IO.File.Create(LocalPath);
                    await filekey.CopyToAsync(stream);
                });
            }

            return Ok( new { fileName, file });
        }
    }
}
