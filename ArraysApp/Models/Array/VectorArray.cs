using ArraysApp.lib;
using System;

namespace ArraysApp.Models
{
    public class VectorArray<T>: BaseArray<T>
    {   
        private int vector;
        public VectorArray(int vector):base() {
            this.vector = vector;
        }

        protected override void Resize() {
            var tempArray = new T[array.Length + vector];
            Array.Copy(array, tempArray, array.Length);
            array = tempArray;
        }
    }
}
