using MagicEsatate_Web.Models.Dto;

namespace MagicEstate_Web.Services.IService
{
    public interface IEstateNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(EstateNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
