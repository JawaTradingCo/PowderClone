
using System.Drawing;

namespace PowderClone
{
    class Liquid : Powder 
    {
        public Liquid()
        {
            PowderColor = Color.SkyBlue;
        }
        public override void Update()
        {
            //pls fix is bad

            if (OnSolid())
            {
                if (Simulator.Powders.Exists(c => c.y == y - 1))//If powder is above
                {
                    if (Simulator.Powders.Exists(c => c.y == y - 1 & c.x != x - 1) & Simulator.Powders.Exists(c => c.y == y - 1 & c.x != x + 1))
                    {
                        MoveX(Simulator.Random.Next(-1, 3));
                    }
                    else if (Simulator.Powders.Exists(c => c.y == y - 1 & c.x != x - 1))
                    {
                        MoveX(-1);
                    }
                    else if (Simulator.Powders.Exists(c => c.y == y - 1 & c.x != x + 1))
                    {
                        MoveX(+1);
                    }
                }
            }


            MoveY(1);//Gravity yo
        }
    }
}
