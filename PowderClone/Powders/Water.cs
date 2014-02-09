using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowderClone
{
    class Water : Liquid, Extinguishes
    {
        public Water()
        {
            PowderColor = Color.DodgerBlue;
        }
    }
}
