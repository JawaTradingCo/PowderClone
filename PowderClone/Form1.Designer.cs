namespace PowderClone
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPowder = new System.Windows.Forms.Button();
            this.buttonSand = new System.Windows.Forms.Button();
            this.buttonLiquid = new System.Windows.Forms.Button();
            this.buttonWall = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelFPS = new System.Windows.Forms.Label();
            this.buttonFire = new System.Windows.Forms.Button();
            this.buttonOil = new System.Windows.Forms.Button();
            this.pictureBox1 = new PowderClone.PictureBoxWithInterpolationMode();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPowder
            // 
            this.buttonPowder.Location = new System.Drawing.Point(12, 534);
            this.buttonPowder.Name = "buttonPowder";
            this.buttonPowder.Size = new System.Drawing.Size(75, 23);
            this.buttonPowder.TabIndex = 1;
            this.buttonPowder.Text = "Powder";
            this.buttonPowder.UseVisualStyleBackColor = true;
            this.buttonPowder.Click += new System.EventHandler(this.buttonPowder_Click);
            // 
            // buttonSand
            // 
            this.buttonSand.Location = new System.Drawing.Point(93, 534);
            this.buttonSand.Name = "buttonSand";
            this.buttonSand.Size = new System.Drawing.Size(75, 23);
            this.buttonSand.TabIndex = 2;
            this.buttonSand.Text = "Sand";
            this.buttonSand.UseVisualStyleBackColor = true;
            this.buttonSand.Click += new System.EventHandler(this.buttonSand_Click);
            // 
            // buttonLiquid
            // 
            this.buttonLiquid.Location = new System.Drawing.Point(174, 534);
            this.buttonLiquid.Name = "buttonLiquid";
            this.buttonLiquid.Size = new System.Drawing.Size(75, 23);
            this.buttonLiquid.TabIndex = 3;
            this.buttonLiquid.Text = "Liquid";
            this.buttonLiquid.UseVisualStyleBackColor = true;
            this.buttonLiquid.Click += new System.EventHandler(this.buttonLiquid_Click);
            // 
            // buttonWall
            // 
            this.buttonWall.Location = new System.Drawing.Point(255, 534);
            this.buttonWall.Name = "buttonWall";
            this.buttonWall.Size = new System.Drawing.Size(75, 23);
            this.buttonWall.TabIndex = 4;
            this.buttonWall.Text = "Wall";
            this.buttonWall.UseVisualStyleBackColor = true;
            this.buttonWall.Click += new System.EventHandler(this.buttonWall_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(449, 534);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(12, 560);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(0, 13);
            this.labelFPS.TabIndex = 6;
            // 
            // buttonFire
            // 
            this.buttonFire.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonFire.Location = new System.Drawing.Point(336, 534);
            this.buttonFire.Name = "buttonFire";
            this.buttonFire.Size = new System.Drawing.Size(75, 23);
            this.buttonFire.TabIndex = 7;
            this.buttonFire.Text = "Fire";
            this.buttonFire.UseVisualStyleBackColor = true;
            this.buttonFire.Click += new System.EventHandler(this.buttonFire_Click);
            // 
            // buttonOil
            // 
            this.buttonOil.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonOil.Location = new System.Drawing.Point(336, 563);
            this.buttonOil.Name = "buttonOil";
            this.buttonOil.Size = new System.Drawing.Size(75, 23);
            this.buttonOil.TabIndex = 8;
            this.buttonOil.Text = "Oil";
            this.buttonOil.UseVisualStyleBackColor = true;
            this.buttonOil.Click += new System.EventHandler(this.buttonOil_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 596);
            this.Controls.Add(this.buttonOil);
            this.Controls.Add(this.buttonFire);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonWall);
            this.Controls.Add(this.buttonLiquid);
            this.Controls.Add(this.buttonSand);
            this.Controls.Add(this.buttonPowder);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Powder Clone";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBoxWithInterpolationMode pictureBox1;
        private System.Windows.Forms.Button buttonPowder;
        private System.Windows.Forms.Button buttonSand;
        private System.Windows.Forms.Button buttonLiquid;
        private System.Windows.Forms.Button buttonWall;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.Button buttonFire;
        private System.Windows.Forms.Button buttonOil;

    }
}

