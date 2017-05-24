using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Interface
{
    public interface IDatabase<T>
    {
        IEnumerable<T> getAll();
        T get(int id);
        void delete(int id);
        int add(T t);
    }
}
