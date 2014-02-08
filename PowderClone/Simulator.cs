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

        //delete queue will delete all items in it after each simulate loop
        public static Queue<Powder> DeleteQueue = new Queue<Powder>();
        //add queue is pretty much the same
        public static Queue<Powder> AddQueue = new Queue<Powder>();

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
                while (DeleteQueue.Count > 0)
                {
                    var p = DeleteQueue.Dequeue();
                    Powders.Remove(p);
                }
                while (AddQueue.Count > 0)
                {
                    var p = AddQueue.Dequeue();
                    Powders.Add(p);
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
                lock(PowderLock)
                if (!Powders.Any(c => c.x == p.x && c.y == p.y)) //Make sure space isnt occupied
                {
                    if(!AddQueue.Any(c => c.x == p.x && c.y == p.y))
                        AddQueue.Enqueue(p);
                }
                else if (DeleteQueue.Any(c => c.x == p.x && c.y == p.y))
                {
                    //if something is going to be deleted here, we can add anyway.

                    if (!AddQueue.Any(c => c.x == p.x && c.y == p.y))
                        AddQueue.Enqueue(p);
                }
            }
        }

        public static void RemovePowderSafe(int x, int y)
        {
            var powder = Powders.FirstOrDefault(p => p.x == x && p.y == y);

            if (powder != null)
                DeleteQueue.Enqueue(powder);
        }

        public static void ClearPowders()
        {
            lock (PowderLock)
                Powders.Clear();
        }

    }
}
