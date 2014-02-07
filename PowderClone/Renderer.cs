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
            buffer = new Bitmap(ROpt.OutputWidth,ROpt.OutputHeight);

            var g = Graphics.FromImage(buffer);
            g.Clear(Color.Black);

            g.Dispose();
        }

        static void DrawPowders()
        {
            try
            {
                foreach (var p in Simulator.Powders.ToList())
                    buffer.SetPixel(p.x, p.y, p.PowderColor);
            }
            catch { }
        }

        static void DrawUI()
        {
            buffer.SetPixel(Simulator.MouseLocation.X, Simulator.MouseLocation.Y, Color.White);
        }


    }
}
