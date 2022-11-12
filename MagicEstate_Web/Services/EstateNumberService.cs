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
        public Task<T> CreateAsync<T>(EstateNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = estateUrl + "/api/EstateNumberAPI/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateNumberAPI/" + id

            });
        }

        public Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = estateUrl + "/api/EstateNumberAPI/" + dto.EstateNo

            });
        }
    }
}
