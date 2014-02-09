using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowderClone
{
    class Fire : Powder
    {
        public int Life;
        public Fire()
        {
            PowderColor = Color.OrangeRed;

            Life = Simulator.Random.Next(0, 100);
        }

        public override void Update()
        {
            MoveY(-1);
            MoveX(Simulator.Random.Next(-1, 2));

            var possibleIgnitions = Utility.MakeSquare(new Point(x, y), 1);

            foreach (var point in possibleIgnitions)
            {
                var powder = Simulator.Powders.FirstOrDefault(p => p.x == point.X && p.y == point.Y);

                if (powder is Extinguishes)
                {
                    Simulator.DeleteQueue.Enqueue(this);
                    continue;
                }

                if(powder == null || !(powder is Flammable)) continue;

                var flammable = powder as Flammable;
                if (Simulator.Random.NextDouble() < flammable.Flammability())
                {

                    Simulator.DeleteQueue.Enqueue(powder);
                    if(Simulator.Random.NextDouble() > flammable.Flammability())
                        Simulator.AddPowderSafe(new Fire { x = powder.x, y = powder.y });
                }
            }


            Life--;

            if (Life <= 0)
            {
                Simulator.DeleteQueue.Enqueue(this);
            }
        }
    }
}
