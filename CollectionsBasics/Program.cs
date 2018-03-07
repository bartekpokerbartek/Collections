using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CollectionsBasics
{
    class Program
    {
        static List<int> _list = new List<int> { 1, 2, 5, 7 };

        static void Main(string[] args)
        {
            TestNonGenericEnumerable();
            Console.WriteLine("--------------");
            TestGenericEnumerable();
            Console.WriteLine("--------------");
            YieldTests();
            Console.WriteLine("--------------");
            EnumeratorTests();
            Console.WriteLine("--------------");
            ThreadSafeTest();
            Console.ReadLine();
        }

        private static void TestNonGenericEnumerable()
        {
            EnumerableExample enumerable = new EnumerableExample(_list);

            foreach (var item in enumerable)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void TestGenericEnumerable()
        {
            GenericEnumerableExample enumerable = new GenericEnumerableExample();

            foreach (var item in enumerable)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void YieldTests()
        {
            var yieldExample = new YieldExample();

            foreach (var item in yieldExample.Sum(_list))
            {
                Console.WriteLine(item);
            }

            foreach (var item in yieldExample.YieldSum(_list))
            {
                Console.WriteLine(item);
            }
        }

        private static void EnumeratorTests()
        {
            var myCollection = new MyCollection(_list);

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }

        private static void ThreadSafeTest()
        {
            BlockingCollection<string> dataItems = new BlockingCollection<string>(100);

            // consumer
            Task.Run(() =>
            {
                while (!dataItems.IsCompleted)
                {
                    string data = string.Empty;
                    // Blocks if dataItems.Count == 0
                    // InvalidOperationException means that Take() was called on a completed collection.
                    // Some other thread can call CompleteAdding after we pass the
                    // IsCompleted check but before we call Take. 
                    // In this example, we can simply catch the exception since the 
                    // loop will break on the next iteration.
                    try
                    {
                        data = dataItems.Take();
                    }
                    catch (InvalidOperationException) {
                        Console.WriteLine("IOE catched.");
                    }

                    if (!string.IsNullOrEmpty(data))
                    {
                        Console.WriteLine("Taken: " + data);
                    }
                }
                Console.WriteLine("\r\n Collection empty. Completed.");
            });

            // producer
            Task.Run(() =>
            {
                var begin = DateTime.Now;

                while (DateTime.Now < begin.AddSeconds(10))
                {
                    string data = DateTime.Now.ToString();
                    // Blocks if dataItems.Count == dataItems.BoundedCapacity
                    dataItems.Add(data);
                    Console.WriteLine("Put: " + data);
                }
                // End of producing
                dataItems.CompleteAdding();
            });

        }
    }
}
