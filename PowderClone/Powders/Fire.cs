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

            var possibleIgnitions = Simulator.Powders.Where(p =>p is Flammable &&
                                                            ((p.x == x + 1 && p.y == y) |
                                                            (p.y == y + 1 && p.x == x) |
                                                            (p.x == x - 1 && p.y == y) |
                                                            (p.y == y - 1 && p.x == x))
                                                            );

            foreach (var possibleIgnition in possibleIgnitions)
            {
               var flammable = possibleIgnition as Flammable;
                if (Simulator.Random.NextDouble() < flammable.Flammability())
                {

                    Simulator.DeleteQueue.Enqueue(possibleIgnition);
                    Simulator.AddPowderSafe(new Fire { x = possibleIgnition.x, y = possibleIgnition.y });
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
