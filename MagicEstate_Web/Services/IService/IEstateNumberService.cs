using MagicEsatate_Web.Models.Dto;

namespace MagicEstate_Web.Services.IService
{
    public interface IEstateNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(EstateNumberCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
