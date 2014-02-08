using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowderClone
{
    class Testing
    {
        static Timer t = new Timer();

        private static Timer t2 = new Timer();

        public static void StartTest()
        {
            //create small blob of powder every half second
            t.Interval = 500;
            t.Tick += t_Tick;
            t.Start();

            //shutdown after 20 seconds
            t2.Interval = 20000;
            t2.Tick += t2_Tick;
            t2.Start();
        }

        static void t2_Tick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        static void t_Tick(object sender, EventArgs e)
        {
            var square = Utility.MakeSquare(new Point(64, 64), 2);
            foreach (Point point in square)
            {
                var powder = new Sand {x = point.X, y = point.Y};
                Simulator.AddPowderSafe(powder);
            }
        }
    }
}
