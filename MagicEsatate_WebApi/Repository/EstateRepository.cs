using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicEsatate_WebApi.Repository
{
    public class EstateRepository : Repository<Estate>, IEstateRepository
    {

        private readonly ApplcationDbContext _db;
        public EstateRepository(ApplcationDbContext db): base(db)
        {
            _db = db;
        }
        
        public async Task<Estate> UpdateAsync(Estate entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.Estates.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
