using System;
using ArraysApp.Models;
using ArraysApp.Models.Queue;

namespace ArraysApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var queue = new Queue<string>();
            
            queue.Enqueue("первый");
            queue.Enqueue("вторый");
            queue.Enqueue("третий");
            queue.Enqueue("четвертый");
            
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue("пятый");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            var priorityQueue = new PriorityQueue<string>();
            priorityQueue.Enqueue("первый 1", 1);
            priorityQueue.Enqueue("второй 1", 1);
            Console.WriteLine("размер " + priorityQueue.Size);
            priorityQueue.Enqueue("первый 2", 2);
            priorityQueue.Enqueue("первый 4", 4);
            priorityQueue.Print();
            Console.WriteLine("достали: " + priorityQueue.Dequeue());
            priorityQueue.Print();
            Console.WriteLine("достали: " + priorityQueue.Dequeue());
            priorityQueue.Print();
            priorityQueue.Enqueue("третий 1", 1);
            priorityQueue.Print(); 
            
            Console.ReadKey();
        }
    }
}
