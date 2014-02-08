using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace PowderClone
{
    public partial class Form1 : Form
    {

        private bool doMouseDraw;
        
        public Form1()
        {
            InitializeComponent();

            Simulator.RenderComplete += Simulator_RenderComplete;

            Simulator.Start();
        }


        void Simulator_RenderComplete(Image output)
        {
            pictureBox1.Image = output;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int Xscale = pictureBox1.Width / ROpt.OutputWidth;
            int Yscale = pictureBox1.Height / ROpt.OutputHeight;
            Simulator.MouseLocation = new Point(e.X / Xscale, e.Y / Yscale);
            if (doMouseDraw)
            {
                Simulator.AddPowderSafe(new Sand { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y});
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            Simulator.AddPowderSafe(new Sand { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y});

            doMouseDraw = true;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            doMouseDraw = false;
        }



    }
}
