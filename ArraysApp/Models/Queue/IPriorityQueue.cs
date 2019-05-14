using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp.Models.Queue
{
    interface IPriorityQueue<T>
    {
        int Size
        {
            get;
        }
        void Enqueue(T item, int priority);
        T Dequeue();
    }
}
