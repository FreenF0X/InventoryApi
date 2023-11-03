using System;
using System.Collections.Generic;

namespace InventoryApi
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetDataList(); // получение всех объектов
        T GetDataById(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        //void Save();  // сохранение изменений


    }
}
