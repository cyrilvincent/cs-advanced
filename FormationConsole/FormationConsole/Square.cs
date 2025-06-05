using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        public override bool Equals(object obj)
        {
            return this.Surface == ((Square)obj).Surface;
        }
    }

    
}
