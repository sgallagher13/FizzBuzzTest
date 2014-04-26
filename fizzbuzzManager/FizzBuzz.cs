using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizzbuzzManager
{
    public class FizzBuzz
    {
        /// <summary>
        /// Returns a List of type string for each number that falls between the start and end numbers. 
        /// If the number is divisable by 3, returns "Fizz". If divisable by 5, returns "Buzz", else returns number
        /// </summary>
        /// <param name="start">starting number</param>
        ///  <param name="end">ending number</param>
        /// <returns>List of strings</returns>
        public List<string> GetFizzBuzzResults(short start, short end)
        {
           
            if (end < start)
            {
                throw new ApplicationException("end number must be greater than start number");
            }   

           

            var results = new List<string>();

            for (var i = start; i <= end; i++)
            {
                var fizz = i % 3 == 0;
                var buzz = i % 5 == 0;

                if (fizz && buzz)
                   results.Add("Fizz" + "Buzz");
                else if (fizz)
                    results.Add("Fizz");
                else if (buzz)
                    results.Add("Buzz");
                else
                {
                   results.Add(i.ToString());
                }

            }

            return results;
        }

        
        /// <summary>
        /// Returns a list of type string representing each number between a given start number an end number, or a particular phrase based on the divisibility of the number value passed.
        /// 
        /// </summary>
        /// <param name="start">starting number</param>
        /// <param name="end">ending number</param>
        /// <param name="combos">IDictionary of numbers and associated phrases to replace numbers if any give number is divisible by the passed value.</param>
        /// <returns></returns>
        public List<string> GetFizzBuzzCustomResults(short start, short end, IDictionary<short,string> combos)
        {

            if (end < start)
            {
                throw new ApplicationException("end number must be greater than start number");
            }

            var results = new List<string>();
            var extraLoop = combos != null;

            for (var i = start; i <= end; i++)
            {
                if (!extraLoop) { results.Add(i.ToString()); continue;}

                var sb = new StringBuilder();
                var i1 = i;
                foreach (var combo in combos.Where(combo => i1%combo.Key == 0))
                {
                    sb.Append(combo.Value);
                }

                results.Add(sb.Length > 0 ? sb.ToString() : i.ToString());
            }

            return results;
        }

    }
}
