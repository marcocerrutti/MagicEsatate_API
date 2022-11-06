using MagicEsatate_WebApi.Models;
using System.Linq.Expressions;

namespace MagicEsatate_WebApi.Repository.IRepository
{
    public interface IEstateRepository: IRepository<Estate>
    {
        Task<Estate> UpdateAsync(Estate entity);
     

    }
}
