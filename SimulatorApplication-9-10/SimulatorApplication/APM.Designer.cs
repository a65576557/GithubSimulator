namespace SimulatorApplication
{
    partial class APM
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnidle = new System.Windows.Forms.Button();
            this.btnservice = new System.Windows.Forms.Button();
            this.btnprocess = new System.Windows.Forms.Button();
            this.btnabort = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(111, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(314, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnidle
            // 
            this.btnidle.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnidle.Location = new System.Drawing.Point(58, 43);
            this.btnidle.Name = "btnidle";
            this.btnidle.Size = new System.Drawing.Size(74, 28);
            this.btnidle.TabIndex = 2;
            this.btnidle.Text = "Idle";
            this.btnidle.UseVisualStyleBackColor = true;
            this.btnidle.Click += new System.EventHandler(this.btnidle_Click);
            // 
            // btnservice
            // 
            this.btnservice.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnservice.Location = new System.Drawing.Point(161, 43);
            this.btnservice.Name = "btnservice";
            this.btnservice.Size = new System.Drawing.Size(74, 28);
            this.btnservice.TabIndex = 3;
            this.btnservice.Text = "Service";
            this.btnservice.UseVisualStyleBackColor = true;
            // 
            // btnprocess
            // 
            this.btnprocess.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnprocess.Location = new System.Drawing.Point(264, 43);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(74, 28);
            this.btnprocess.TabIndex = 4;
            this.btnprocess.Text = "Process";
            this.btnprocess.UseVisualStyleBackColor = true;
            this.btnprocess.Click += new System.EventHandler(this.btnprocess_Click);
            // 
            // btnabort
            // 
            this.btnabort.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnabort.Location = new System.Drawing.Point(368, 43);
            this.btnabort.Name = "btnabort";
            this.btnabort.Size = new System.Drawing.Size(74, 28);
            this.btnabort.TabIndex = 5;
            this.btnabort.Text = "Abort";
            this.btnabort.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(111, 108);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 194);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // APM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 439);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnabort);
            this.Controls.Add(this.btnprocess);
            this.Controls.Add(this.btnservice);
            this.Controls.Add(this.btnidle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "APM";
            this.Text = "APM";
            this.Load += new System.EventHandler(this.APM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnidle;
        private System.Windows.Forms.Button btnservice;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.Button btnabort;
        private System.Windows.Forms.ListBox listBox1;
    }
}