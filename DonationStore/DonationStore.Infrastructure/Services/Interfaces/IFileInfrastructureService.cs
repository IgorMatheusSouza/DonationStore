using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.Services.Interfaces
{
    public interface IFileInfrastructureService
    {
        Task CreateFileAsync(IFormFile filekey, string fileName);
    }
}
