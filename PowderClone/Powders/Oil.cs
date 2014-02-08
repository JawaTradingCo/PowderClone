using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowderClone
{
    class Oil : Liquid, Flammable
    {
        public Oil()
        {
            PowderColor = Color.DarkSlateGray;
        }

        public double Flammability()
        {
            return 1.0;
        }
    }
}
