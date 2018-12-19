namespace SimulatorApplication
{
    partial class FullMVs
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
            this.ModuleSelection = new System.Windows.Forms.ListView();
            this.ValueSelection = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WaferSelection = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModuleSelection
            // 
            this.ModuleSelection.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ModuleSelection.Location = new System.Drawing.Point(517, 44);
            this.ModuleSelection.Name = "ModuleSelection";
            this.ModuleSelection.Size = new System.Drawing.Size(632, 305);
            this.ModuleSelection.TabIndex = 0;
            this.ModuleSelection.UseCompatibleStateImageBehavior = false;
            this.ModuleSelection.SelectedIndexChanged += new System.EventHandler(this.ModuleSelection_SelectedIndexChanged);
            // 
            // ValueSelection
            // 
            this.ValueSelection.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ValueSelection.Location = new System.Drawing.Point(517, 405);
            this.ValueSelection.Name = "ValueSelection";
            this.ValueSelection.Size = new System.Drawing.Size(681, 283);
            this.ValueSelection.TabIndex = 1;
            this.ValueSelection.UseCompatibleStateImageBehavior = false;
            this.ValueSelection.SelectedIndexChanged += new System.EventHandler(this.ValueSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(630, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Module/Step selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(630, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Measured Value Selection";
            // 
            // WaferSelection
            // 
            this.WaferSelection.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WaferSelection.Location = new System.Drawing.Point(155, 114);
            this.WaferSelection.Name = "WaferSelection";
            this.WaferSelection.Size = new System.Drawing.Size(343, 391);
            this.WaferSelection.TabIndex = 4;
            this.WaferSelection.UseCompatibleStateImageBehavior = false;
            this.WaferSelection.SelectedIndexChanged += new System.EventHandler(this.WaferSelection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(192, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wafer Selection";
            // 
            // btnChart
            // 
            this.btnChart.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChart.Location = new System.Drawing.Point(12, 229);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(117, 44);
            this.btnChart.TabIndex = 6;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // FullMVs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 722);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WaferSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ValueSelection);
            this.Controls.Add(this.ModuleSelection);
            this.Name = "FullMVs";
            this.Text = "Full MVs";
            this.Load += new System.EventHandler(this.FullMVs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ModuleSelection;
        private System.Windows.Forms.ListView ValueSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView WaferSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChart;
    }
}