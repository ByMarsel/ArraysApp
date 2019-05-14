using ArraysApp.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp.Models.Queue
{
    struct PriorityValue<T>
    {
        public int Priority;
        public IArray<T> items;
        public PriorityValue(int priority, IArray<T> items)
        {
            this.Priority = priority;
            this.items = items;
        }
    }

    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private PriorityValue<T>[] array;
        public int Size { get; private set; }

        public PriorityQueue()
        {
            this.array = new PriorityValue<T>[] { new PriorityValue<T>(1, new SingleArray<T>()) };
        }

        public T Dequeue()
        {
            if (Size > 0)
            {
                var queue = array[array.Length - 1].items;
                if (queue.Size > 0)
                {
                    if (queue.Size > 0)
                    {
                        return queue.Remove(0);
                    }
                    else
                    {
                        Size--;
                        Array.Resize(ref array, array.Length - 1);
                        return Dequeue();
                    }

                }
            }
            throw new InvalidOperationException("Queue is empty");
        }

        public void Enqueue(T item, int priority)
        {
            var isEnqueuedWithoutResize = false;
            foreach (var priorityTuple in array)
            {
                if (priorityTuple.Priority == priority)
                {
                    priorityTuple.items.Add(item);
                    Size++;
                    isEnqueuedWithoutResize = true;
                    break;
                }
            }



            if (!isEnqueuedWithoutResize)
            {
                Resize();
                var isEnqueuedAfterResize = false;
                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i].Priority > priority)
                    {
                        for (var j = i; j < array.Length - 1; j++)
                        {
                            var temp = array[j + 1];
                            array[j + 1] = array[j];
                            if (!isEnqueuedAfterResize)
                            {
                                array[j] = new PriorityValue<T>(priority, new SingleArray<T>());
                                array[j].items.Add(item);
                                isEnqueuedAfterResize = true;
                            }
                        }
                    }
                    if (!isEnqueuedAfterResize)
                    {
                        array[array.Length - 1] = new PriorityValue<T>(priority, new SingleArray<T>());
                    }
                    break;

                }
            }
        }

        private void Resize()
        {
            Array.Resize(ref array, array.Length + 1);
        }

        public void Print()
        {
            foreach (var queue in array)
            {
                Console.WriteLine("Priority " + queue.Priority);
                for (var i = 0; i < queue.items.Size; i++)
                {
                    Console.Write(" " + queue.items[i] + " ");
                }
            }
        }
    }
}
