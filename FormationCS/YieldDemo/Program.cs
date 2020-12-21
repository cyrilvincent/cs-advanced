using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldDemo
{
    class Program
    {

        static bool IsPrime(long x)
        {
            if(x < 2)
            {
                return false;
            }
            for (int div = 2; div < x; div++)
            {
                if (x % div == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static IEnumerable<long> Generate(long nb)
        {
            for(int i=0;i<nb;i++)
            {
                yield return i;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Yield");
            var l = Generate(10000000000000000);
            var res = l.Where(n => n % 2 == 0).Where(n => IsPrime(n)).ToList();
            // Lazy Loading
            foreach (int j in res)
            {
                Console.WriteLine(j);
            }
            
        }
    }
}
