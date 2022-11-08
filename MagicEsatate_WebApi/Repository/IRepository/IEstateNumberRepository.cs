using MagicEsatate_WebApi.Models;

namespace MagicEsatate_WebApi.Repository.IRepository
{
    public interface IEstateNumberRepository: IRepository<EstateNumber>
    {
        Task<EstateNumber> UpdateAsync(EstateNumber entity);
    }
}
