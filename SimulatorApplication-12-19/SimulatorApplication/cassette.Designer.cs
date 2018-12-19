namespace SimulatorApplication
{
    partial class cassette
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
            this.picCassette = new System.Windows.Forms.PictureBox();
            this.picChamber = new System.Windows.Forms.PictureBox();
            this.picCentralize = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picRobot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCassette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChamber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCentralize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRobot)).BeginInit();
            this.SuspendLayout();
            // 
            // picCassette
            // 
            this.picCassette.Location = new System.Drawing.Point(560, 483);
            this.picCassette.Name = "picCassette";
            this.picCassette.Size = new System.Drawing.Size(213, 182);
            this.picCassette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCassette.TabIndex = 3;
            this.picCassette.TabStop = false;
            // 
            // picChamber
            // 
            this.picChamber.Location = new System.Drawing.Point(941, 243);
            this.picChamber.Name = "picChamber";
            this.picChamber.Size = new System.Drawing.Size(217, 203);
            this.picChamber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChamber.TabIndex = 2;
            this.picChamber.TabStop = false;
            // 
            // picCentralize
            // 
            this.picCentralize.Location = new System.Drawing.Point(232, 243);
            this.picCentralize.Name = "picCentralize";
            this.picCentralize.Size = new System.Drawing.Size(216, 203);
            this.picCentralize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCentralize.TabIndex = 1;
            this.picCentralize.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(560, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picRobot
            // 
            this.picRobot.Location = new System.Drawing.Point(560, 243);
            this.picRobot.Name = "picRobot";
            this.picRobot.Size = new System.Drawing.Size(217, 203);
            this.picRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRobot.TabIndex = 4;
            this.picRobot.TabStop = false;
            // 
            // cassette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1333, 791);
            this.Controls.Add(this.picRobot);
            this.Controls.Add(this.picCassette);
            this.Controls.Add(this.picChamber);
            this.Controls.Add(this.picCentralize);
            this.Controls.Add(this.pictureBox1);
            this.Name = "cassette";
            this.Text = "cassette";
            this.Load += new System.EventHandler(this.cassette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCassette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChamber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCentralize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRobot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCentralize;
        private System.Windows.Forms.PictureBox picChamber;
        private System.Windows.Forms.PictureBox picCassette;
        private System.Windows.Forms.PictureBox picRobot;
    }
}