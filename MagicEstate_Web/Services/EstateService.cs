using MagicEsatate_Web.Models.Dto;
using MagicEstate_Utility;
using MagicEstate_Web.Models;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

        public Task<T> CreateAsync<T>(EstateCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = estateUrl + "/api/v1/EstateAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = estateUrl + "/api/v1/EstateAPI/" + id,
                Token= token

            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/v1/EstateAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = estateUrl + "/api/v1/EstateAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(EstateUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = estateUrl + "/api/v1/EstateAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
