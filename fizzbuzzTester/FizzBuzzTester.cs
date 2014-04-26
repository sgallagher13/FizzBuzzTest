using System;
using System.Collections.Generic;
using fizzbuzzManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace fizzbuzzTester
{
    [TestClass]
    public class FizzBuzzTester
    {
        private List<string> Seeder(short start, short end)
        {
            var fizzbuzzer = new FizzBuzz();
            var results = fizzbuzzer.GetFizzBuzzResults(start, end);

            return results;
        }

        private List<string> CustomSeeder(short start, short end, IDictionary<short,string> combos)
        {
            var fizzbuzzer = new FizzBuzz();
            var results = fizzbuzzer.GetFizzBuzzCustomResults(start, end, combos);
            return results;
        }

        

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzCustomResults_Returns_List()
        {
            short start = 1;
            short end = 100;
            var results = CustomSeeder(start, end, null);

            Assert.IsInstanceOfType(results, typeof(List<string>));
            Assert.AreEqual((end - start) + 1, results.Count);
        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzCustomResults_When_Divisible_By_Custom_Combos()
        {
            short start = 1;
            short end = 24;
            var combos = new Dictionary<short, string> {{4, "Foo"}, {6, "Bar"}, {8, "Zing"}};
            var results = CustomSeeder(start, end, combos);

            Assert.AreEqual("Foo", results[3]);
            Assert.AreEqual("Foo", results[19]);

            Assert.AreEqual("Bar", results[5]);
            Assert.AreEqual("Bar", results[17]);

            Assert.AreEqual("FooZing", results[7]);

            Assert.AreEqual("FooBar", results[11]);
            Assert.AreEqual("FooZing", results[15]);
            Assert.AreEqual("FooBarZing", results[23]);

           
        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzCustomResults_When_Not_Divisible_By_Custom_Combos()
        {
            short start = 1;
            short end = 24;
            var combos = new Dictionary<short, string> { { 4, "Foo" }, { 6, "Bar" } };
            var results = CustomSeeder(start, end, combos);

            Assert.AreEqual("1", results[0]);
            Assert.AreEqual("7", results[6]);
            Assert.AreEqual("14", results[13]);
            Assert.AreEqual("23", results[22]);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void FizzBuzz_GetFizzBuzzCustomResult_When_End_Less_Than_Start()
        {
            var combos = new Dictionary<short, string> { { 4, "Foo" }, { 6, "Bar" } };
            var results = CustomSeeder(30, 10, combos);
             Assert.Fail();
        }
            
        [TestMethod]
        public void FizzBuzz_GetFizzBuzzResults_Returns_List()
        {
            short start = 1;
            short end = 100;
            var results = Seeder(start, end);

            Assert.IsInstanceOfType(results, typeof(List<string>));
            Assert.AreEqual((end - start)+1, results.Count);
        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzResults_When_Divisible_By_3_Only()
        {
            var results = Seeder(1, 15);
            Assert.AreEqual("Fizz", results[2]);
            Assert.AreEqual("Fizz", results[5]);
            Assert.AreEqual("Fizz", results[8]);
            Assert.AreEqual("Fizz", results[11]);
            Assert.AreNotEqual("Fizz", results[14]);
          
        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzResults_When_Divisible_By_5_Only()
        {
            var results = Seeder(1, 15);
            Assert.AreEqual("Buzz", results[4]);
            Assert.AreEqual("Buzz", results[9]);
            Assert.AreNotEqual("Buzz", results[14]);

        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzResults_When_Divisible_By_3_And_5()
        {
            var results = Seeder(1, 45);
            Assert.AreEqual("FizzBuzz", results[14]);
            Assert.AreEqual("FizzBuzz", results[29]);
            Assert.AreEqual("FizzBuzz", results[44]);
        }

        [TestMethod]
        public void FizzBuzz_GetFizzBuzzResults_When_Not_Divisible_By_3_Or_5()
        {
            var results = Seeder(-10, 45);
            Assert.AreEqual("-8", results[2]);
            Assert.AreEqual("-7", results[3]);
            Assert.AreEqual("11", results[21]);
            Assert.AreEqual("44", results[54]);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void FizzBuzz_GetFizzBuzzResults_When_End_Less_Than_Start()
        {
            var results = Seeder(30,15);
            Assert.Fail();
        }

    }
}
