using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowderClone
{
    class Utility
    {
        public static List<Point> MakeSquare(Point centre,int radius)
        {
            var points = new List<Point>();
            for (int x = centre.X - radius; x <= centre.X + radius; x++)
            {
                for (int y = centre.Y - radius; y <= centre.Y + radius; y++)
                {
                    points.Add(new Point(x,y));
                }
            }
            return points;
        }
    }
}
