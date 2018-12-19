namespace SimulatorApplication
{
    partial class endeffector
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radiotransfer = new System.Windows.Forms.RadioButton();
            this.radioamp = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSourceSlotno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbDestinationSlotno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recipeTypeDataSet1 = new SimulatorApplication.RecipeTypeDataSet();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radiomapwafer = new System.Windows.Forms.RadioButton();
            this.radioclearwafer = new System.Windows.Forms.RadioButton();
            this.radiononalign = new System.Windows.Forms.RadioButton();
            this.radiowithalign = new System.Windows.Forms.RadioButton();
            this.cmbalign = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbalign);
            this.groupBox1.Controls.Add(this.radiotransfer);
            this.groupBox1.Controls.Add(this.radioamp);
            this.groupBox1.Location = new System.Drawing.Point(80, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radiotransfer
            // 
            this.radiotransfer.AutoSize = true;
            this.radiotransfer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radiotransfer.Location = new System.Drawing.Point(299, 22);
            this.radiotransfer.Name = "radiotransfer";
            this.radiotransfer.Size = new System.Drawing.Size(88, 24);
            this.radiotransfer.TabIndex = 4;
            this.radiotransfer.TabStop = true;
            this.radiotransfer.Text = "Transfer";
            this.radiotransfer.UseVisualStyleBackColor = true;
            this.radiotransfer.CheckedChanged += new System.EventHandler(this.radiotransfer_CheckedChanged);
            // 
            // radioamp
            // 
            this.radioamp.AutoSize = true;
            this.radioamp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioamp.Location = new System.Drawing.Point(41, 22);
            this.radioamp.Name = "radioamp";
            this.radioamp.Size = new System.Drawing.Size(61, 24);
            this.radioamp.TabIndex = 3;
            this.radioamp.TabStop = true;
            this.radioamp.Text = "Map";
            this.radioamp.UseVisualStyleBackColor = true;
            this.radioamp.CheckedChanged += new System.EventHandler(this.radioamp_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSourceSlotno);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbSource);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 261);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tbSourceSlotno
            // 
            this.tbSourceSlotno.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSourceSlotno.Location = new System.Drawing.Point(132, 118);
            this.tbSourceSlotno.Name = "tbSourceSlotno";
            this.tbSourceSlotno.Size = new System.Drawing.Size(100, 25);
            this.tbSourceSlotno.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(49, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slot no";
            // 
            // cmbSource
            // 
            this.cmbSource.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "CSA",
            "Arm",
            "Aligner",
            "APM"});
            this.cmbSource.Location = new System.Drawing.Point(111, 61);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(121, 28);
            this.cmbSource.TabIndex = 2;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(105, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbDestinationSlotno);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbDestination);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(355, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 261);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // tbDestinationSlotno
            // 
            this.tbDestinationSlotno.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDestinationSlotno.Location = new System.Drawing.Point(132, 118);
            this.tbDestinationSlotno.Name = "tbDestinationSlotno";
            this.tbDestinationSlotno.Size = new System.Drawing.Size(100, 25);
            this.tbDestinationSlotno.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(49, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Slot no";
            // 
            // cmbDestination
            // 
            this.cmbDestination.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Items.AddRange(new object[] {
            "CSA",
            "Arm",
            "Aligner",
            "APM"});
            this.cmbDestination.Location = new System.Drawing.Point(111, 61);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(121, 28);
            this.cmbDestination.TabIndex = 2;
            this.cmbDestination.SelectedIndexChanged += new System.EventHandler(this.cmbDestination_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(105, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Destination";
            // 
            // recipeTypeDataSet1
            // 
            this.recipeTypeDataSet1.DataSetName = "RecipeTypeDataSet";
            this.recipeTypeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Location = new System.Drawing.Point(101, 500);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(421, 500);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // radiomapwafer
            // 
            this.radiomapwafer.AutoSize = true;
            this.radiomapwafer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radiomapwafer.Location = new System.Drawing.Point(123, 124);
            this.radiomapwafer.Name = "radiomapwafer";
            this.radiomapwafer.Size = new System.Drawing.Size(106, 24);
            this.radiomapwafer.TabIndex = 8;
            this.radiomapwafer.TabStop = true;
            this.radiomapwafer.Text = "Map wafer";
            this.radiomapwafer.UseVisualStyleBackColor = true;
            this.radiomapwafer.Visible = false;
            this.radiomapwafer.CheckedChanged += new System.EventHandler(this.radiomapwafer_CheckedChanged);
            // 
            // radioclearwafer
            // 
            this.radioclearwafer.AutoSize = true;
            this.radioclearwafer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioclearwafer.Location = new System.Drawing.Point(344, 124);
            this.radioclearwafer.Name = "radioclearwafer";
            this.radioclearwafer.Size = new System.Drawing.Size(111, 24);
            this.radioclearwafer.TabIndex = 9;
            this.radioclearwafer.TabStop = true;
            this.radioclearwafer.Text = "Clear wafer";
            this.radioclearwafer.UseVisualStyleBackColor = true;
            this.radioclearwafer.CheckedChanged += new System.EventHandler(this.radioclearwafer_CheckedChanged);
            // 
            // radiononalign
            // 
            this.radiononalign.AutoSize = true;
            this.radiononalign.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radiononalign.Location = new System.Drawing.Point(44, 85);
            this.radiononalign.Name = "radiononalign";
            this.radiononalign.Size = new System.Drawing.Size(103, 24);
            this.radiononalign.TabIndex = 10;
            this.radiononalign.TabStop = true;
            this.radiononalign.Text = "Non Align";
            this.radiononalign.UseVisualStyleBackColor = true;
            this.radiononalign.Visible = false;
            // 
            // radiowithalign
            // 
            this.radiowithalign.AutoSize = true;
            this.radiowithalign.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radiowithalign.Location = new System.Drawing.Point(44, 163);
            this.radiowithalign.Name = "radiowithalign";
            this.radiowithalign.Size = new System.Drawing.Size(106, 24);
            this.radiowithalign.TabIndex = 11;
            this.radiowithalign.TabStop = true;
            this.radiowithalign.Text = "With Align";
            this.radiowithalign.UseVisualStyleBackColor = true;
            this.radiowithalign.Visible = false;
            // 
            // cmbalign
            // 
            this.cmbalign.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbalign.FormattingEnabled = true;
            this.cmbalign.Items.AddRange(new object[] {
            "None",
            "With Align"});
            this.cmbalign.Location = new System.Drawing.Point(384, 26);
            this.cmbalign.Name = "cmbalign";
            this.cmbalign.Size = new System.Drawing.Size(86, 24);
            this.cmbalign.TabIndex = 12;
            // 
            // endeffector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 590);
            this.Controls.Add(this.radiowithalign);
            this.Controls.Add(this.radiononalign);
            this.Controls.Add(this.radioclearwafer);
            this.Controls.Add(this.radiomapwafer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "endeffector";
            this.Text = "Wafer map/Transfer";
            this.Load += new System.EventHandler(this.endeffector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radiotransfer;
        private System.Windows.Forms.RadioButton radioamp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RecipeTypeDataSet recipeTypeDataSet1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radiomapwafer;
        private System.Windows.Forms.RadioButton radioclearwafer;
        public System.Windows.Forms.ComboBox cmbSource;
        public System.Windows.Forms.TextBox tbSourceSlotno;
        public System.Windows.Forms.TextBox tbDestinationSlotno;
        public System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.RadioButton radiononalign;
        private System.Windows.Forms.RadioButton radiowithalign;
        private System.Windows.Forms.ComboBox cmbalign;
    }
}