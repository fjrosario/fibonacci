using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static IList<long> fibonacciNumbers;

        public static bool isPrime(long number)
        {
            long boundary = (long)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static long Fibonacci(int n)
        {
            long a = 0;
            long b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
                fibonacciNumbers.Add(temp);
            }
            return a;
        }

        static void Main(string[] args)
        {
            const int DESIRED_FIBONACCI_NUMBER = 50;
            fibonacciNumbers = new List<long>(DESIRED_FIBONACCI_NUMBER);
            //Populate list with first 50 fibonacci numbers
            Fibonacci(DESIRED_FIBONACCI_NUMBER);
            //Print out Fibonacci sequence in order
            Console.WriteLine(string.Format("Fibonacci numbers from 1 - {0}", DESIRED_FIBONACCI_NUMBER));
            foreach (long num in fibonacciNumbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(string.Format("Fibonacci numbers from {0} - 1, without prime numbers", DESIRED_FIBONACCI_NUMBER));

            var fibonacciNumbersSansPrimes = fibonacciNumbers.Where(n => (isPrime(n) == false)).OrderByDescending(n => n);

            foreach (long num in fibonacciNumbersSansPrimes)
            {
                Console.WriteLine(num);
            }


            Console.ReadKey();
        }
    }
}
