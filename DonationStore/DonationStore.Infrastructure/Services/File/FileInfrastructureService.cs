using Azure.Storage.Blobs;
using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.Services.File
{
    public class FileInfrastructureService : IFileInfrastructureService
    {
        private readonly IConfiguration _configuration; 

        public FileInfrastructureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CreateFileAsync(IFormFile file, string fileName)
        {
            await Task.Run(async () =>
            {
                fileName += SystemConstantValues.ImageExtension;
                var connection = _configuration.GetSection(SystemConstantValues.BlobConnectionName).Value;

                BlobServiceClient blobServiceClient = new BlobServiceClient(connection);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(SystemConstantValues.BlobStorageContainer);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream);
            });
        }
    }
}
