using InventoryApi.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryApi
{
    public class EfCoreRepository: IRepository, IDisposable
    {
        ApplicationContext db;
        public EfCoreRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public List<TEntity> GetDataList<TEntity,TProperty>(Func<TEntity, bool> filter, Expression<Func<TEntity, TProperty>> property)
            where TEntity : class
        {
                return db.Set<TEntity>().Include(property).Where(filter).ToList();
        }

        public TEntity GetDataById<TEntity>(int id)
            where TEntity : class
        {
                return db.Find<TEntity>(id);
        }


        public void Create<TEntity>(TEntity entity)
            where TEntity : class
        {
                db.Add<TEntity>(entity);
                db.SaveChanges();
        }

        public void Update<TEntity>(int id, TEntity entity)
            where TEntity : class
        {
                db.Entry<TEntity>(entity).State = EntityState.Modified;
                db.SaveChanges();
        }

        public void Delete<TEntity>(int id)
            where TEntity : class
        {
                var entity = db.Find<TEntity>(id);
                if (entity != null)
                    db.Remove<TEntity>(entity);
                db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
