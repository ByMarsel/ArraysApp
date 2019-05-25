using ArraysApp.lib;
using System;

namespace ArraysApp.Models.Queue
{

    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        public int Size { get; private set; }

        private IArray<T>[] array;
        private int minPriority;

        public PriorityQueue()
        {
            this.array = new[] { new SingleArray<T>() };
            this.minPriority = 1;
        }

        public T Dequeue()
        {
            if (Size > 0)
            {
                var queue = array[0];

                if (queue != null && queue.Size > 0)
                {
                    Size--;
                    return queue.Remove(0);
                }
                else
                {
                    minPriority++;
                    SlideToBack();
                    return Dequeue();
                }

            }
            throw new InvalidOperationException("Queue is empty");
        }

        public void Enqueue(T item, int priority)
        {

            ValidatePriority(priority);
            int arrIndex = priority - 1;

            if (array.Length > arrIndex)
            {
                if (priority < minPriority)
                {
                    SlideToAhead();
                    minPriority = priority;
                }
                
                if (array[arrIndex] != null)
                {
                    array[arrIndex].Add(item);
                }
                else
                {
                    array[arrIndex] = new SingleArray<T>();
                    array[arrIndex].Add(item);
                }
                Size++;
            }
            else
            {
                Resize(priority);
                Enqueue(item, priority);
            }
        }

        private void ValidatePriority(int priority)
        {
            if (priority < 1)
            {
                throw new ArgumentException("Priority not less 1");
            }
        }

        private void Resize(int priority)
        {
            var newLenght = array.Length >= priority ? array.Length : priority;
            if (array.Length != newLenght)
            {
                Array.Resize(ref array, array.Length + 1);
            }
        }

        private void SlideToAhead() {
            var newArray = new IArray<T>[array.Length + 1];
            Array.Copy(array, 0, newArray, 1, array.Length);
            array = newArray;
        }

        private void SlideToBack()
        {
            var newArray = new IArray<T>[array.Length - 1];
            Array.Copy(array, 1, newArray, 0, array.Length);
            array = newArray;
        }

        public void Print()
        {
            var priority = 1;
            foreach (var queue in array)
            {

                Console.WriteLine("Priority " + priority);
                if (queue == null) {
                    priority++;
                    continue;
                }
                for (var i = 0; i < queue.Size; i++)
                {
                    Console.Write(" " + queue[i] + " ");
                }
                Console.WriteLine("");
                priority++;
            }
        }
    }
}
