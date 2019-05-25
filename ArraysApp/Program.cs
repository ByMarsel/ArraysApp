using System;
using ArraysApp.Models;
using ArraysApp.Models.Queue;

namespace ArraysApp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var queue = new PriorityQueue<string>();
            queue.Enqueue("первый 1", 1);
            queue.Enqueue("второй 1", 1);
            Console.WriteLine("размер " + queue.Size);
            queue.Enqueue("первый 2", 2);
            queue.Enqueue("первый 4", 4);
            queue.Print();
            Console.WriteLine("достали: " + queue.Dequeue());
            queue.Print();
            Console.WriteLine("достали: " + queue.Dequeue());
            queue.Print();
            queue.Enqueue("третий 1", 1);
            queue.Print();
            Console.ReadKey();
        }
    }
}
