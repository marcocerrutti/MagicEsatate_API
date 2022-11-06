using MagicEsatate_WebApi.Models;
using System.Linq.Expressions;

namespace MagicEsatate_WebApi.Repository.IRepository
{
    public interface IEstateRepository
    {
        Task<List<Estate>> GetAll(Expression<Func<Estate, bool>> filter  = null);
        Task <Estate> Get(Expression<Func<Estate, bool>> filter = null, bool tracked=true);
        Task Create(Estate entity);
        Task Remove(Estate entity);
        Task Save();

    }
}
