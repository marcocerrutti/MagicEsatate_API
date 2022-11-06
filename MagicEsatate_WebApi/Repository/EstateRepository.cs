using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicEsatate_WebApi.Repository
{
    public class EstateRepository : IEstateRepository
    {

        private readonly ApplcationDbContext _db;
        public EstateRepository(ApplcationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Estate entity)
        {
           await _db.Estates.AddAsync(entity);
            await Save();
        }

        public async Task<Estate> Get(Expression<Func<Estate, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Estate> query = _db.Estates;
            if (!tracked)
            {
                query = query.Where(filter);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Estate>> GetAll(Expression<Func<Estate, bool>> filter = null)
        {
            IQueryable<Estate> query = _db.Estates;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
            
        }

        public async Task Remove(Estate entity)
        {
            _db.Estates.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

       
    }
}
