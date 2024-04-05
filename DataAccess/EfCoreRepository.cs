using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess
{
    public class EfCoreRepository : IRepository//,IDisposable
    {
        ApplicationContext _db;
        public EfCoreRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<List<TEntity>> GetAllDataListAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, TProperty>>[] includes)
            where TEntity : class
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Where(filter).ToListAsync();
        }

        public async Task<TEntity?> GetDataByIdAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, TProperty>>[] includes)
           where TEntity : class
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);

            var result = await query.Where(filter).ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<TEntity?> CreateAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            await _db.AddAsync<TEntity>(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            //_db.Entry<TEntity>(entity).State = EntityState.Modified;
            _db.Set<TEntity>().Update(entity);//.State=EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync<TEntity>(int id)
            where TEntity : class
        {
            var entity = await _db.FindAsync<TEntity>(id);
            if (entity != null)
                _db.Remove<TEntity>(entity);
            await _db.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }
    }
}
