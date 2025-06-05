using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole
{
    public static class RectangleExtensions
    {
        public static double GetPerimeter(this Rectangle rectangle)
        {
            return (rectangle.Width + rectangle.Length) * 2;
        }
    }
}
