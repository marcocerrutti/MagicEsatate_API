using MagicEsatate_Web.Models.Dto;
using MagicEstate_Utility;
using MagicEstate_Web.Models;
using MagicEstate_Web.Services.IService;

namespace MagicEstate_Web.Services
{
    public class EstateNumberService : BaseService, IEstateNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string estateUrl;

        public EstateNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            estateUrl = configuration.GetValue<string>("ServiceUrls:EstateAPI");
        }
        public Task<T> CreateAsync<T>(EstateNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = estateUrl + "/api/EstateNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI/" + dto.EstateNo,
                Token = token
            });
        }
    }
}
