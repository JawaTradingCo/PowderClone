using System.Diagnostics;
using System.Drawing;
using System.Linq;
namespace PowderClone
{
    static class Renderer
    {

        static Bitmap buffer;

        public static Image Render()
        {

            Clear();

            DrawPowders();

            DrawUI();

            return buffer;
        }

        static void Clear()
        {
            buffer = new Bitmap(ROpt.OutputWidth, ROpt.OutputHeight);

            lock (buffer)
            {
                var g = Graphics.FromImage(buffer);
                g.Clear(Color.Black);

                g.Dispose();
            }
        }

        static void DrawPowders()
        {
            lock (buffer)
                lock (Simulator.PowderLock)
                {
                    foreach (var p in Simulator.Powders.ToList())
                        buffer.SetPixel(p.x, p.y, p.PowderColor);
                }
        }

        static void DrawUI()
        {
            try
            {
                lock (buffer)
                    buffer.SetPixel(Simulator.MouseLocation.X, Simulator.MouseLocation.Y, Color.White);
            }
            catch { }
        }


    }
}
