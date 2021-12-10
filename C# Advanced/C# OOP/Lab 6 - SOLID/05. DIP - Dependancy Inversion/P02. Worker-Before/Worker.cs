using P02._Worker_Before.Contracts;
using System;

namespace P02._Worker_Before
{
    public class Worker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Works normaly");
        }
    }
}
