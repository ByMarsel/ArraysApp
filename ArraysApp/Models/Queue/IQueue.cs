namespace ArraysApp.Models.Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        int Size { get; }
    }
}