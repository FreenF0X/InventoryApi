using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InventoryApi
{
    public interface IRepository: IDisposable
    {
        List<T> GetDataList<T, TProperty>(Func<T,bool> filter, Expression<Func<T, TProperty>> property)
            where T : class; // получение всех объектов
        T GetDataById<T>(int id)
            where T : class; // получение одного объекта по id
        void Create<T>(T item)
            where T : class; // создание объекта
        void Update<T>(int id, T item)
            where T : class; // обновление объекта
        void Delete<T>(int id)
            where T : class; // удаление объекта по id
        //void Save();  // сохранение изменений


    }
}
