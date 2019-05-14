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
            queue.Enqueue("первый", 1);
            queue.Enqueue("второй", 1);
            queue.Enqueue("третий", 2);
            queue.Print();
            Console.WriteLine("достали " + queue.Dequeue());
            queue.Print();

            Console.ReadKey();
        }
    }
}
