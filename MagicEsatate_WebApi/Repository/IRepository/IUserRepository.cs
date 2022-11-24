using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;

namespace MagicEsatate_WebApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
