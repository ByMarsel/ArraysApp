using ArraysApp.lib;
using System;

namespace ArraysApp.Models
{
    public class MatrixArray<T> : IArray<T>
    {
        public int Size { get; protected set; }
        protected T[,] array;
        protected int vector;

        public MatrixArray(int vector)
        {
            this.vector = vector;
            array = new T[1, this.vector];
            Size = 0;
        }

        public T this[int index]
        {
            get
            {
                return array[index / array.GetLength(1), index % array.GetLength(1)];
            }
        }



        public void Add(T item)
        {
            if (Size < array.Length)
            {
                array[Size / array.GetLength(1), Size % array.GetLength(1)] = item;
                Size++;
            }
            else
            {
                Resize();
                Add(item);
            }
        }

        public void Add(T item, int index)
        {
            if (index < array.Length && index > -1)
            {
                array[index / array.GetLength(1), index % array.GetLength(1)] = item;
            }
            else
            {
                Resize();
                Add(item, index);
            }
        }

        protected void Resize()
        {
            var tempArr = new T[array.GetLength(1) + 1, vector];
            Array.Copy(array, tempArr, array.Length);
            array = tempArr;
        }

        public T Remove(int index)
        {
            var result = array[Size / array.GetLength(1), Size % array.GetLength(1) - 1];
            Size--;
            return result;
        }
    }
}
