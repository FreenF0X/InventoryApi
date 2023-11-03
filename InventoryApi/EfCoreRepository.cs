using ConsoleApp1;
using InventoryApi.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InventoryApi
{
    public class EfCoreRepository: IRepository<Provider>
    {
        
        public EfCoreRepository()
        {
            
        }

        public IEnumerable<Provider> GetDataList()
        {
            using (var db = new ApplicationContext())
            {
                return db.Providers;
            }
            
        }

        public Provider GetDataById(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Providers.Find(id);
            }
            
        }


        public void Create(Provider provider)
        {
            using (var db = new ApplicationContext())
            {
                db.Providers.Add(provider);
            }
            
        }

        public void Update(Provider provider)
        {
            using (var db = new ApplicationContext())
            {
                db.Entry(provider).State = EntityState.Modified;
            }
                
        }

        public void Delete(int id)
        {
            using (var db = new ApplicationContext())
            {
                Provider provider = db.Providers.Find(id);
                if (provider != null)
                    db.Providers.Remove(provider);
            }
        }

    }
}
