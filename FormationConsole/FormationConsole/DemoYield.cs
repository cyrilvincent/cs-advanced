using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole
{
    public class DemoYield
    {
        public IEnumerable<int> Infinite()
        {
            int i = 0;
            while (true)
            {
                yield return i;
                Thread.Sleep(1000);
                i++;
            }
        }

        public void CallInfinite()
        {
            var result = Infinite();
            var result2 = result.Where(x => x % 2 == 0);
            foreach (int i in result2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
