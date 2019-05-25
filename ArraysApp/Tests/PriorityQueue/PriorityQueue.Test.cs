using ArraysApp.Models.Queue;
using NUnit.Framework;

namespace ArraysApp.Tests.PriorityQueue
{
    [TestFixture]
    public class PriorityQueue_Test
    {
        IPriorityQueue<string> priorityQueue = new PriorityQueue<string>();

        [Test, Order(1)]
        public void Enqueue()
        {
            priorityQueue.Enqueue("first 1", 1);
            Assert.AreEqual(1, priorityQueue.Size);
        }
        
        [Test, Order(2)]
        public void Dequeue()
        {
            var value =  priorityQueue.Dequeue();
            Assert.AreEqual(0, priorityQueue.Size);
            Assert.AreEqual("first 1", value);
        }

        /*
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
        */
    }
}