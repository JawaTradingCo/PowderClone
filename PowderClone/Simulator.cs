using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace PowderClone
{
    delegate void SimulatorRenderComplete(Image output);

    static class Simulator
    {
        static public readonly Random Random = new Random();

        static public Timer RenderLoop = new Timer(ROpt.RenderLoopInterval);

        static public event SimulatorRenderComplete RenderComplete;

        static public List<Powder> Powders = new List<Powder>();

        static public Point MouseLocation = new Point(0,0);

        public static List<Keys> keysDown = new List<Keys>();


        public static bool DoSimulate = false;

        static Simulator()
        {
            RenderLoop.Elapsed += RenderLoop_Elapsed;

            Powders.Add(new Powder());
            Powders.Add(new Wall());


        }

        public static void Start()
        {
            DoSimulate = true;
            RenderLoop.Start();
        }


        static void Simulate()
        {
            foreach (var p in Powders.ToList())
            {
                p.InternalUpdate();
            }
        }

        static void RenderLoop_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if(DoSimulate)
                    Simulate();

                RenderComplete(Renderer.Render());
            }
            catch 
            {
                
            }
            
        }

        public static void AddPowderSafe(Powder p)
        {
            if(!Powders.Exists(c => c.x == p.x & c.y == p.y))//Make sure space isnt occupied
            {
                Powders.Add(p);
            }
        }

    }
}
