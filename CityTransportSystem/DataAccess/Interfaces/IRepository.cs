using System;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(int id);
        IEnumerable<T> GetList();       
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
