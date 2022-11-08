using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Repository.IRepository;

namespace MagicEsatate_WebApi.Repository
{
    public class EstateNumberRepository : Repository<EstateNumber>, IEstateNumberRepository
    {
        private readonly ApplcationDbContext _db;
        public EstateNumberRepository(ApplcationDbContext db) : base(db)
        {
            _db = db;   
        }

        public async Task<EstateNumber> UpdateAsync(EstateNumber entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.EstateNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
