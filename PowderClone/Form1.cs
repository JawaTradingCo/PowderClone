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

        private Type currentPowder = typeof(Sand);

        private Timer mouseTimer = new Timer();

        private MouseMode mouseMode = MouseMode.Place;


        public Form1()
        {
            InitializeComponent();

            FPSdelegate = SetText;

            Simulator.RenderComplete += Simulator_RenderComplete;

            Simulator.Start();

            mouseTimer.Interval = 10;
            mouseTimer.Tick += mouseTimer_Tick;
        }

        void Simulator_RenderComplete(Image output)
        {
            pictureBox1.Image = output;

            labelFPS.Invoke(FPSdelegate);
        }
        void SetText()
        {
            labelFPS.Text = string.Format("Render: {0}ms Simulate: {1}ms", Simulator.RenderTime, Simulator.SimulateTime);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int Xscale = pictureBox1.Width / ROpt.OutputWidth;
            int Yscale = pictureBox1.Height / ROpt.OutputHeight;
            Simulator.MouseLocation = new Point(e.X / Xscale, e.Y / Yscale);
        }

        void mouseTimer_Tick(object sender, EventArgs e)
        {
            switch (mouseMode)
            {
                case MouseMode.Place:
                    PlaceFromMouse();
                    break;
                case MouseMode.Delete:
                    Simulator.RemovePowderSafe(Simulator.MouseLocation.X, Simulator.MouseLocation.Y);
                    break;
            }
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    PlaceFromMouse();

                    mouseMode = MouseMode.Place;
                    mouseTimer.Start();
                    break;

                case MouseButtons.Right:
                    Simulator.RemovePowderSafe(Simulator.MouseLocation.X, Simulator.MouseLocation.Y);

                    mouseMode = MouseMode.Delete;
                    mouseTimer.Start();
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseTimer.Stop();
        }

        private void PlaceFromMouse()
        {
            var square = Utility.MakeSquare(Simulator.MouseLocation, 1);
            foreach (Point point in square)
            {
                if(checkBoxReplace.Checked)
                    Simulator.RemovePowderSafe(point.X, point.Y);

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

        private enum MouseMode
        {
            Place,
            Delete
        }
    }
}
