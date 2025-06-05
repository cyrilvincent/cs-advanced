using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole
{
    public class Rectangle
    {
        public double Length { get; set; } = 0;
        public double Width { get; set; } = 0;
        public Point Point { get; set; } = new Point { X = 0, Y = 0 };

        public Rectangle()
        {
            Length = 0;
            Width = 0;
        }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public virtual double Surface
        {
            get { return Length * Width; }
        }

    }
}
