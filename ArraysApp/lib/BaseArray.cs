using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp.lib
{
    public abstract class BaseArray<T> : IArray<T>
    {
        protected T[] array;
        private readonly int? factor;
        public virtual int Size { get; protected set; }
        public virtual T this[int index] {
            get {
                return array[index];
            }
        }
   

        public BaseArray(int? factor = null, int initLength = 0) {
            this.array = new T[initLength];
            this.factor = factor;
        }
        public virtual void Add(T item)
        {
            if (Size < array.Length)
            {
                array[Size] = item;
                Size++;
            }
            else {
                Resize();
                Add(item);
            }
        }

        public virtual void Add(T item, int index)
        {
            if (index < 0) {
                throw new ArgumentException("Index less than zero");
            }

            if (index < Size)
            {
                array[index] = item;
            }
            else
            {
                Resize();
                Add(item, index);
            }
        }

        protected virtual void Resize()
        {
            int newLength;

            if (factor.HasValue)
            {
                newLength = array.Length + array.Length * factor.Value / 100;
            }
            else
            {
                newLength = array.Length + 1;
            }
            Array.Resize(ref array, newLength);
        }
 
        public virtual T Remove(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index less than zero");
            }

            if (Size > 0 && index < Size ) {
                Size--;
                var result = array[index];
             
                for(var i = index+1; i < array.Length; i++){
                    array[i - 1] = array[i];
                }
                Array.Resize(ref array, array.Length - 1);
                return result;
            }

            throw new InvalidOperationException("Array is empty");
        }
    }
}
