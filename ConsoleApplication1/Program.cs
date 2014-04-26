using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fizzbuzzManager;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var results = new FizzBuzz().GetFizzBuzzResults(-30, 50);
            var results = new FizzBuzz().GetFizzBuzzCustomResults(1, 100,
                new Dictionary<short, string> {{3, "Foo"}, {5, "Bar"}, {6, "Zing"}});

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}
