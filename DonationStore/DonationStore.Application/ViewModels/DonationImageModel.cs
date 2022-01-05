using DonationStore.Infrastructure.Constants;

namespace DonationStore.Application.ViewModels
{
    public class DonationImageModel
    {
        public string FileName { get; set; }

        public string FileUrl { get => SystemConstantValues.BlobUrl + FileName + SystemConstantValues.ImageExtension; }
    }
}
