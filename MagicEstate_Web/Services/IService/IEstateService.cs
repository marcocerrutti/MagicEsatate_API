using MagicEsatate_Web.Models.Dto;

namespace MagicEstate_Web.Services.IService
{
    public interface IEstateService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateCreateDTO dto);
        Task<T> UpdateAsync<T>(EstateUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
