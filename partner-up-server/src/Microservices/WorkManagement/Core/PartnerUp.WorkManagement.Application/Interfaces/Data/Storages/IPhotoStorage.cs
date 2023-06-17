using Microsoft.AspNetCore.Http;

namespace PartnerUp.WorkManagement.Application.Interfaces.Data.Storages;

public interface IPhotoStorage
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
