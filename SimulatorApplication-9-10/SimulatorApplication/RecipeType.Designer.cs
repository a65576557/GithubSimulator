namespace SimulatorApplication
{
    partial class RecipeType
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConditioning = new System.Windows.Forms.Button();
            this.btnModule = new System.Windows.Forms.Button();
            this.btnCassette = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listboxRecipeName = new System.Windows.Forms.ListBox();
            this.tbrecipename = new System.Windows.Forms.TextBox();
            this.tbrecipeDate = new System.Windows.Forms.TextBox();
            this.recipeTypeDataSet = new SimulatorApplication.RecipeTypeDataSet();
            this.recipeTypeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recipeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.recipeTableAdapter = new SimulatorApplication.RecipeTypeDataSetTableAdapters.recipeTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConditioning);
            this.groupBox1.Controls.Add(this.btnModule);
            this.groupBox1.Controls.Add(this.btnCassette);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recipe Type";
            // 
            // btnConditioning
            // 
            this.btnConditioning.Location = new System.Drawing.Point(41, 199);
            this.btnConditioning.Name = "btnConditioning";
            this.btnConditioning.Size = new System.Drawing.Size(119, 26);
            this.btnConditioning.TabIndex = 5;
            this.btnConditioning.Text = "Conditioning";
            this.btnConditioning.UseVisualStyleBackColor = true;
            this.btnConditioning.Click += new System.EventHandler(this.btnConditioning_Click);
            // 
            // btnModule
            // 
            this.btnModule.Location = new System.Drawing.Point(41, 144);
            this.btnModule.Name = "btnModule";
            this.btnModule.Size = new System.Drawing.Size(119, 25);
            this.btnModule.TabIndex = 4;
            this.btnModule.Text = "module";
            this.btnModule.UseVisualStyleBackColor = true;
            this.btnModule.Click += new System.EventHandler(this.btnModule_Click);
            // 
            // btnCassette
            // 
            this.btnCassette.Location = new System.Drawing.Point(41, 90);
            this.btnCassette.Name = "btnCassette";
            this.btnCassette.Size = new System.Drawing.Size(119, 26);
            this.btnCassette.TabIndex = 3;
            this.btnCassette.Text = "Cassette";
            this.btnCassette.UseVisualStyleBackColor = true;
            this.btnCassette.Click += new System.EventHandler(this.btnCassette_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(16, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(6, 21);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Service";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(12, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 37);
            this.button4.TabIndex = 1;
            this.button4.Text = "new";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(135, 305);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 37);
            this.button5.TabIndex = 2;
            this.button5.Text = "delete";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpen.Location = new System.Drawing.Point(12, 390);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(108, 37);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(135, 390);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 37);
            this.button7.TabIndex = 4;
            this.button7.Text = "exit";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataMember = "recipe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(256, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recipe Name";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(484, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time";
            this.label2.Visible = false;
            // 
            // listboxRecipeName
            // 
            this.listboxRecipeName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listboxRecipeName.FormattingEnabled = true;
            this.listboxRecipeName.ItemHeight = 24;
            this.listboxRecipeName.Location = new System.Drawing.Point(707, 84);
            this.listboxRecipeName.Name = "listboxRecipeName";
            this.listboxRecipeName.Size = new System.Drawing.Size(239, 340);
            this.listboxRecipeName.TabIndex = 9;
            this.listboxRecipeName.Visible = false;
            this.listboxRecipeName.SelectedIndexChanged += new System.EventHandler(this.listboxRecipeName_SelectedIndexChanged);
            // 
            // tbrecipename
            // 
            this.tbrecipename.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbrecipename.Location = new System.Drawing.Point(235, 136);
            this.tbrecipename.Name = "tbrecipename";
            this.tbrecipename.Size = new System.Drawing.Size(172, 33);
            this.tbrecipename.TabIndex = 10;
            this.tbrecipename.Visible = false;
            // 
            // tbrecipeDate
            // 
            this.tbrecipeDate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbrecipeDate.Location = new System.Drawing.Point(444, 136);
            this.tbrecipeDate.Name = "tbrecipeDate";
            this.tbrecipeDate.Size = new System.Drawing.Size(141, 33);
            this.tbrecipeDate.TabIndex = 12;
            this.tbrecipeDate.Visible = false;
            // 
            // recipeTypeDataSet
            // 
            this.recipeTypeDataSet.DataSetName = "RecipeTypeDataSet";
            this.recipeTypeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recipeTypeDataSetBindingSource
            // 
            this.recipeTypeDataSetBindingSource.DataSource = this.recipeTypeDataSet;
            this.recipeTypeDataSetBindingSource.Position = 0;
            // 
            // recipeBindingSource1
            // 
            this.recipeBindingSource1.DataMember = "recipe";
            this.recipeBindingSource1.DataSource = this.recipeTypeDataSetBindingSource;
            // 
            // recipeTableAdapter
            // 
            this.recipeTableAdapter.ClearBeforeFill = true;
            // 
            // RecipeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 686);
            this.Controls.Add(this.tbrecipeDate);
            this.Controls.Add(this.tbrecipename);
            this.Controls.Add(this.listboxRecipeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecipeType";
            this.Text = "RecipeType";
            this.Load += new System.EventHandler(this.RecipeType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTypeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModule;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button button7;
       // private RecipeTypeDataSet recipeTypeDataSet;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbrecipeDate;
        public System.Windows.Forms.TextBox tbrecipename;
        public System.Windows.Forms.ListBox listboxRecipeName;
        public System.Windows.Forms.Label label1;
        private RecipeTypeDataSet recipeTypeDataSet;
        private System.Windows.Forms.BindingSource recipeTypeDataSetBindingSource;
        private System.Windows.Forms.BindingSource recipeBindingSource1;
        private RecipeTypeDataSetTableAdapters.recipeTableAdapter recipeTableAdapter;
        public System.Windows.Forms.Button btnCassette;
        private System.Windows.Forms.Button btnConditioning;
    }
}