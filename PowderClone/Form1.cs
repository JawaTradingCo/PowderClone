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

        private Type currentPowder = typeof(Sand);


        public Form1()
        {
            InitializeComponent();

            FPSdelegate = SetText;

            Simulator.RenderComplete += Simulator_RenderComplete;

            Simulator.Start();

            Testing.StartTest();
        }


        void Simulator_RenderComplete(Image output)
        {
            pictureBox1.Image = output;

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
                Simulator.RemovePowderSafe(Simulator.MouseLocation.X, Simulator.MouseLocation.Y);
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
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
            var square = Utility.MakeSquare(Simulator.MouseLocation, 1);
            foreach (Point point in square)
            {
                var powder = (Powder)Activator.CreateInstance(currentPowder);
                powder.x = point.X;
                powder.y = point.Y;
                Simulator.AddPowderSafe(powder);
            }
        }

        #region Buttons

        private void buttonPowder_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Powder);
        }

        private void buttonSand_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Sand);
        }

        private void buttonLiquid_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Liquid);
        }

        private void buttonWall_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Wall);
        }

        private void buttonFire_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Fire);
        }

        private void buttonOil_Click(object sender, EventArgs e)
        {
            currentPowder = typeof(Oil);
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Simulator.ClearPowders();
        }
        #endregion
    }
}
