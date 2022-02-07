using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace RecipeAPI.Data
{
    public interface IPhotoService
    {
         Task <ImageUploadResult> UploadPhotoAsync(IFormFile photo);
    }
}