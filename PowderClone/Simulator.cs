using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        static public Point MouseLocation = new Point(0, 0);

        static public List<Keys> keysDown = new List<Keys>();

        public static int RenderTime = 0;

        public static int SimulateTime = 0;

        public static object PowderLock = new object();
        public static object RenderLock = new object();


        public static bool DoSimulate = false;

        static Simulator()
        {
            RenderLoop.Elapsed += RenderLoop_Elapsed;
        }

        public static void Start()
        {
            DoSimulate = true;
            RenderLoop.Start();
        }


        static void Simulate()
        {
            lock (PowderLock)
            {
                foreach (var p in Powders.Where(p => !p.IsSolid))
                {
                    p.InternalUpdate();
                }
            }
        }

        static void RenderLoop_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (RenderLock)
            {
                var counter = new Stopwatch();
                counter.Start();

                if (DoSimulate)
                    Simulate();

                SimulateTime = (int)counter.ElapsedMilliseconds;

                counter.Restart();
                RenderComplete(Renderer.Render());

                RenderTime = (int)counter.ElapsedMilliseconds;

                counter.Stop();
            }

        }

        public static void AddPowderSafe(Powder p)
        {
            if (p.y >= 0 && p.x >= 0 && p.y <= ROpt.OutputWidth && p.x <= ROpt.OutputHeight)
            {
                lock (PowderLock)
                {
                    if (!Powders.Exists(c => c.x == p.x & c.y == p.y)) //Make sure space isnt occupied
                    {
                        Powders.Add(p);
                    }
                }
            }
        }

        public static void RemovePowderSafe(int x, int y)
        {
            lock(PowderLock)
                Powders.RemoveAll(p => p.x == x && p.y == y);
        }

        public static void ClearPowders()
        {
            lock(PowderLock)
                Powders.Clear();
        }

    }
}
