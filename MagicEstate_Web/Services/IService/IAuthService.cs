using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Models;

namespace MagicEstate_Web.Services.IService
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objCreate);
        Task<T> ReegisterAsync<T>(RegistrationRequestDTO objCreate);
    }
}
