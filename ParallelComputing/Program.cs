using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelComputing
{
    class Program
    {
        static int SleepTime = 500;

        static void Main(string[] args)
        {
            ParallelComputingVariant1();
            //ParallelComputingVariant2();
            Console.ReadLine();
        }

        static void ParallelComputingVariant1()
        {
            Task t1 = new Task(() => WriteNumbers());
            Task t2 = new Task(() => WriteWords());
            Task t3 = new Task(() => WriteColors());
            t1.Start();
            t2.Start();
            t3.Start();
        }

        static void ParallelComputingVariant2()
        {
            Parallel.Invoke
                (
                    new Action(WriteNumbers),
                    new Action(WriteWords),
                    new Action(WriteColors)
                );
        }

        static void WriteNumbers()
        {
            Thread.CurrentThread.Name = "Thread 1";
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Thread name {0}, Number: {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep(SleepTime);
            }
        }

        static void WriteWords()
        {
            Thread.CurrentThread.Name = "Thread 2";
            String localString = "This is an example for using    tasks";
            String[] localWords = localString.Split(' ');
            foreach (String s in localWords)
            {
                Console.WriteLine("Thread name {0}, Word: {1}", Thread.CurrentThread.Name, s);
                Thread.Sleep(SleepTime);
            }
        }
        static void WriteColors()
        {
            Thread.CurrentThread.Name = "Thread 3";
            String[] localColors = { "red", "orange", "blue", "green", "yellow", "white", "black" };
            foreach (String s in localColors)
            {
                Console.WriteLine("Thread name {0}, Colors: {1}", Thread.CurrentThread.Name, s);
                Thread.Sleep(SleepTime);
            }
        }
    }
}
