using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace PowderClone
{
    public partial class Form1 : Form
    {
        private delegate void SetFPSText();
        private SetFPSText FPSdelegate;

        private bool doMouseDraw;
        private bool doMouseDelete;

        private PlaceablePowders currentPowder = PlaceablePowders.Sand;
        
        public Form1()
        {
            InitializeComponent();

            FPSdelegate = SetText;

            Simulator.RenderComplete += Simulator_RenderComplete;

            Simulator.Start();
        }


        void Simulator_RenderComplete(Image output)
        {
            pictureBox1.Image = output;

            if (!labelFPS.InvokeRequired)
                labelFPS.Text = string.Format("\u0394Render: {0} \u0394Simulate: {1}", Simulator.RenderTime, Simulator.SimulateTime);
            else
                labelFPS.Invoke(FPSdelegate);
        }
        void SetText()
        {
            labelFPS.Text = string.Format("\u0394Render: {0} \u0394Simulate: {1}", Simulator.RenderTime, Simulator.SimulateTime);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int Xscale = pictureBox1.Width / ROpt.OutputWidth;
            int Yscale = pictureBox1.Height / ROpt.OutputHeight;
            Simulator.MouseLocation = new Point(e.X / Xscale, e.Y / Yscale);
            if (doMouseDraw)
            {
                PlaceFromMouse();
            }
            if (doMouseDelete)
            {
                Simulator.RemovePowderSafe(Simulator.MouseLocation.X,Simulator.MouseLocation.Y);
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    PlaceFromMouse();
                    doMouseDraw = true;
                    break;

                case MouseButtons.Right:
                    Simulator.RemovePowderSafe(Simulator.MouseLocation.X, Simulator.MouseLocation.Y);
                    doMouseDelete = true;

                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            doMouseDraw = false;
            doMouseDelete = false;
        }

        private void PlaceFromMouse()
        {
            switch (currentPowder)
            {
                case PlaceablePowders.Powder:
                    Simulator.AddPowderSafe(new Powder { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
                case PlaceablePowders.Sand:
                    Simulator.AddPowderSafe(new Sand { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
                case PlaceablePowders.Liquid:
                    Simulator.AddPowderSafe(new Liquid { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
                case PlaceablePowders.Wall:
                    Simulator.AddPowderSafe(new Wall { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
                case PlaceablePowders.Fire:
                    Simulator.AddPowderSafe(new Fire { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
                case PlaceablePowders.Oil:
                    Simulator.AddPowderSafe(new Oil { x = Simulator.MouseLocation.X, y = Simulator.MouseLocation.Y });
                    break;
            }
        }

        private void buttonPowder_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Powder;
        }

        private void buttonSand_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Sand;
        }

        private void buttonLiquid_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Liquid;
        }

        private void buttonWall_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Wall;
        }

        private void buttonFire_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Fire;
        }

        private void buttonOil_Click(object sender, EventArgs e)
        {
            currentPowder = PlaceablePowders.Oil;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Simulator.ClearPowders();
        }



    }

    public enum PlaceablePowders
    {
        Powder,
        Sand,
        Liquid,
        Wall,
        Fire,
        Oil
    }
}
