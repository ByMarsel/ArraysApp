using ArraysApp.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            minPriority = 1;
        }

        public T Dequeue()
        {
            if (Size > 0)
            {
                var queue = array[0];

                if (queue != null && queue.Size > 0)
                {

                    minPriority++;
                    Size--;
                   
                    return queue.Remove(0);
                }
                else
                {
                    minPriority++;
                    var newArray = new IArray<T>[array.Length - 1];
                    for (int i = 1; i < array.Length; i++) {
                        newArray[i - 1] = array[i];
                    }
                    array = newArray;
                    return Dequeue();
                }

            }
            throw new InvalidOperationException("Queue is empty");
        }

        public void Enqueue(T item, int priority)
        {

            ValidatePriority(priority);

            if (array.Length > priority - 1)
            {
                if (array[priority - 1] != null)
                {
                    array[priority - 1].Add(item);
                }
                else
                {
                    if (priority < minPriority) {
                        SlideToAhead();
                    }
           
                    array[priority - 1] = new SingleArray<T>();
                    array[priority - 1].Add(item);
                }
                if (minPriority > priority) {
                    minPriority = priority;
                }
                Size++;
            }
            else
            {
                IncreaseSize();
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

        private void IncreaseSize()
        {
            Array.Resize(ref array, array.Length+1);
        }

        private void SlideToAhead() {
            var newArray = new IArray<T>[array.Length + 1];
            Array.Copy(array, 0, newArray, 1, array.Length);
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
