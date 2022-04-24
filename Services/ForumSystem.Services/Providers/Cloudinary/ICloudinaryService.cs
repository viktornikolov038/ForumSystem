using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ForumNet.Services.Providers.Cloudinary
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file, string fileName);
    }
}
