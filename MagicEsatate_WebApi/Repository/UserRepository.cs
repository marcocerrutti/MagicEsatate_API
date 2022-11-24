using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Models.Dto;
using MagicEsatate_WebApi.Repository.IRepository;
using MagicEsatate_WebApi.Data;

namespace MagicEsatate_WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplcationDbContext _db;
        public UserRepository(ApplcationDbContext db)
        {
            _db = db;
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
