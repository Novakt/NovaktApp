using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Interface
{
    public interface IDatabase<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(int id);
        int Add(T t);
    }
}
