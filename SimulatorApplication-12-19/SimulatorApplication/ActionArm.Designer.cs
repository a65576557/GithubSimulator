namespace SimulatorApplication
{
    partial class ActionArm
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
            this.listAction = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listAction
            // 
            this.listAction.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listAction.FormattingEnabled = true;
            this.listAction.ItemHeight = 27;
            this.listAction.Items.AddRange(new object[] {
            "Home",
            "Rotate",
            "Retract",
            "Extend",
            "Map",
            "Go slot",
            "Up",
            "Down",
            "Vaccum on",
            "Vaccum off",
            "Ser on",
            "Ser off"});
            this.listAction.Location = new System.Drawing.Point(193, 25);
            this.listAction.Name = "listAction";
            this.listAction.Size = new System.Drawing.Size(144, 301);
            this.listAction.TabIndex = 0;
            this.listAction.SelectedIndexChanged += new System.EventHandler(this.listAction_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(82, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(291, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel Action";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ActionArm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 608);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listAction);
            this.Name = "ActionArm";
            this.Text = "ActionArm";
            this.Load += new System.EventHandler(this.ActionArm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}