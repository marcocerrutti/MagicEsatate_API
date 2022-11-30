using MagicEsatate_Web.Models.Dto;
using MagicEstate_Utility;
using MagicEstate_Web.Models;
using MagicEstate_Web.Services.IService;

namespace MagicEstate_Web.Services
{
    public class AuthService: BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string estateUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            estateUrl = configuration.GetValue<string>("ServiceUrls:EstateAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = estateUrl + "/api/UsersAuth/Login"

            });
        }

        public Task<T> ReegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = estateUrl + "/api/UsersAuth/register"

            });
        }
    }
}
