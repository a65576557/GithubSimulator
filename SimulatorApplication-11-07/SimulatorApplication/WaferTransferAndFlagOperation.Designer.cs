namespace SimulatorApplication
{
    partial class Wafer_Transfer_and_Flag_Operation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSourceStation = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMapWafer = new System.Windows.Forms.Button();
            this.btnClearWafer = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(93, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 531);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTransfer);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transfer Wafer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(248, 329);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(78, 29);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(319, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination Station";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Centralize",
            "APM"});
            this.comboBox1.Location = new System.Drawing.Point(45, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSourceStation);
            this.groupBox1.Location = new System.Drawing.Point(24, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Station";
            // 
            // lblSourceStation
            // 
            this.lblSourceStation.AutoSize = true;
            this.lblSourceStation.Location = new System.Drawing.Point(58, 71);
            this.lblSourceStation.Name = "lblSourceStation";
            this.lblSourceStation.Size = new System.Drawing.Size(0, 19);
            this.lblSourceStation.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMapWafer);
            this.tabPage2.Controls.Add(this.btnClearWafer);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flag Operation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMapWafer
            // 
            this.btnMapWafer.Location = new System.Drawing.Point(45, 155);
            this.btnMapWafer.Name = "btnMapWafer";
            this.btnMapWafer.Size = new System.Drawing.Size(105, 29);
            this.btnMapWafer.TabIndex = 6;
            this.btnMapWafer.Text = "Map Wafer";
            this.btnMapWafer.UseVisualStyleBackColor = true;
            this.btnMapWafer.Click += new System.EventHandler(this.btnMapWafer_Click);
            // 
            // btnClearWafer
            // 
            this.btnClearWafer.Location = new System.Drawing.Point(234, 155);
            this.btnClearWafer.Name = "btnClearWafer";
            this.btnClearWafer.Size = new System.Drawing.Size(105, 29);
            this.btnClearWafer.TabIndex = 5;
            this.btnClearWafer.Text = "Clear Wafer";
            this.btnClearWafer.UseVisualStyleBackColor = true;
            // 
            // Wafer_Transfer_and_Flag_Operation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 621);
            this.Controls.Add(this.tabControl1);
            this.Name = "Wafer_Transfer_and_Flag_Operation";
            this.Text = "WaferTransferAndFlagOperation";
            this.Load += new System.EventHandler(this.Wafer_Transfer_and_Flag_Operation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnMapWafer;
        private System.Windows.Forms.Button btnClearWafer;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSourceStation;
    }
}