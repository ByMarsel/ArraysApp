using ArraysApp.lib;

namespace ArraysApp.Models.Queue
{
    public class Queue<T> : IQueue<T>
    {
        private IArray<T> queue;

        public Queue()
        {
            this.queue = new SingleArray<T>();
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
        }

        public T Dequeue()
        {
            return this.queue.Remove(0);
        }

        public int Size {
            get { return this.queue.Size; }
        }
    }
}