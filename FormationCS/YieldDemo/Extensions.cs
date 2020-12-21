using System;
using System.Collections.Generic;
using System.Text;

namespace YieldDemo
{
    public static class Extensions
    {
        public static IEnumerable<T> WhereCyril<T>(this IEnumerable<T> source, Func<T,bool> lambda)
        {
            foreach(T elem in source)
            {
                if(lambda(elem))
                {
                    yield return elem;
                }
            }
        }

        public static List<T> ToListCyril<T>(this IEnumerable<T> source)
        {
            List<T> result = new List<T>();
            foreach (T elem in source)
            {
                result.Add(elem);
            }
            return result;
        }
    }
}
