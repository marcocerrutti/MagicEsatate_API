using MagicEsatate_Web.Models.Dto;

namespace MagicEstate_Web.Services.IService
{
    public interface IEstateService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(EstateCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(EstateUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
