using MagicEsatate_Web.Models.Dto;
using MagicEstate_Utility;
using MagicEstate_Web.Models;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace MagicEstate_Web.Services
{
    public class EstateService : BaseService, IEstateService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string estateUrl;
        
        public EstateService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            estateUrl = configuration.GetValue<string>("ServiceUrls:EstateAPI");
        }

        public Task<T> CreateAsync<T>(EstateCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = estateUrl + "/api/EstateAPI"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = estateUrl + "/api/EstateAPI/"+id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateAPI"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/EstateAPI/"+id

            });
        }

        public Task<T> UpdateAsync<T>(EstateUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = estateUrl + "/api/EstateAPI/"+ dto.Id

            });
        }
    }
}
