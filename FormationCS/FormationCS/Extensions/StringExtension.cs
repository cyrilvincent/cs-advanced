using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Extensions
{
    public static class StringExtension
    {
        public static string ToCAMLCase(this string s)
        {
            return s[0].ToString().ToUpper() + s.Substring(1).ToLower();
        }
    }
}
