namespace SimulatorApplication
{
    partial class cassettemap
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
            this.btnmap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnmap
            // 
            this.btnmap.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnmap.Location = new System.Drawing.Point(149, 83);
            this.btnmap.Name = "btnmap";
            this.btnmap.Size = new System.Drawing.Size(119, 32);
            this.btnmap.TabIndex = 0;
            this.btnmap.Text = "map";
            this.btnmap.UseVisualStyleBackColor = true;
            this.btnmap.Click += new System.EventHandler(this.btnmap_Click);
            // 
            // cassettemap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 364);
            this.Controls.Add(this.btnmap);
            this.Name = "cassettemap";
            this.Text = "cassettemap";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnmap;
    }
}