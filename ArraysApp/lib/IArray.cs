using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp.lib
{
    public interface IArray<T>
    {
        int Size
        {
            get;
        }

        T this[int index]
        {
            get;
        } 
        void Add(T item);
        void Add(T item, int index);
        T Remove(int index);
    }
}
