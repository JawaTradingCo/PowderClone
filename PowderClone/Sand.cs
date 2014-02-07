﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowderClone
{
    class Sand : Powder
    {
        public Sand()
        {
            SetColor(Color.SandyBrown);
        }
        public override void Update()
        {
            if (Simulator.Powders.Exists(c => c.x == x && c.y == y - 1))
            {
                if (Simulator.Powders.Exists(c => c.x == x && c.y == y + 1) | y + 1 == ROpt.OutputHeight)
                {
                    MoveX(Simulator.Random.Next(-1, 2));
                }
            }

            MoveY(1);
        }
    }
}
