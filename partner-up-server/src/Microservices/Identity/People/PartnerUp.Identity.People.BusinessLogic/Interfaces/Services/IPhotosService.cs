using Microsoft.AspNetCore.Http;

namespace PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;

public interface IPhotosService
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
