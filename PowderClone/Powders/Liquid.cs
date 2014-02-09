using System.Linq;
using System.Drawing;

namespace PowderClone
{
    class Liquid : Powder
    {
        public bool Pressure;
        public Liquid()
        {
            PowderColor = Color.SkyBlue;
        }
        public override void Update()
        {
            //pls fix is bad

            if (Simulator.Powders.Exists(c => c.y == y - 1 && c.x == x))//If powder is above
            {
                Pressure = true;
            }

            if (Pressure)
            {
                MoveX(Simulator.Random.Next(-1, 2));
            }

            var neighbours = Simulator.Powders.Where(p => (p.y == y && p.x == x - 1) || (p.y == y && p.x == x + 1));

            foreach (var liquid in neighbours.OfType<Liquid>())
            {
                liquid.Pressure = true;
            }

            if (!neighbours.Any() && !Simulator.Powders.Exists(c => c.y == y - 1 && c.x == x))
            {
                Pressure = false;
            }



            MoveY(1);//Gravity yo
        }
    }
}
