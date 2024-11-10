using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhoto(IFormFile file);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}
