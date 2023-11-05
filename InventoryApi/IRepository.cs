using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InventoryApi
{
    public interface IRepository: IDisposable
    {
        List<T> GetDataList<T, TProperty>(Func<T,bool> filter, Expression<Func<T, TProperty>> property)
            where T : class;
        T GetDataById<T>(int id)
            where T : class;
        void Create<T>(T item)
            where T : class;
        void Update<T>(int id, T item)
            where T : class;
        void Delete<T>(int id)
            where T : class;
    }
}
