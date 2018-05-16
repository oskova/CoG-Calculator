namespace TriangleDemo
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelFileName = new System.Windows.Forms.Label();
            this.GBconforming = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConformingCoGY = new System.Windows.Forms.TextBox();
            this.tbConformingCoGX = new System.Windows.Forms.TextBox();
            this.chbConformingCoG = new System.Windows.Forms.CheckBox();
            this.chbConformingTriangulate = new System.Windows.Forms.CheckBox();
            this.GBconstrained = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConstrainedCoGY = new System.Windows.Forms.TextBox();
            this.tbConstrainedCoGX = new System.Windows.Forms.TextBox();
            this.chbConstrainedCoG = new System.Windows.Forms.CheckBox();
            this.chbConstrainedTriangulate = new System.Windows.Forms.CheckBox();
            this.tbToleranceFactor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.GBconforming.SuspendLayout();
            this.GBconstrained.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(137, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 562);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.MainWindow_Resize);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(119, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.Filter = ".csv file|*.csv";
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(134, 578);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(340, 13);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "hmmmm, you should select file... ...I mean, if you want... No pressure... ";
            // 
            // GBconforming
            // 
            this.GBconforming.Controls.Add(this.label4);
            this.GBconforming.Controls.Add(this.label1);
            this.GBconforming.Controls.Add(this.tbConformingCoGY);
            this.GBconforming.Controls.Add(this.tbConformingCoGX);
            this.GBconforming.Controls.Add(this.chbConformingCoG);
            this.GBconforming.Controls.Add(this.chbConformingTriangulate);
            this.GBconforming.Location = new System.Drawing.Point(3, 40);
            this.GBconforming.Name = "GBconforming";
            this.GBconforming.Size = new System.Drawing.Size(127, 123);
            this.GBconforming.TabIndex = 5;
            this.GBconforming.TabStop = false;
            this.GBconforming.Text = "Conforming Delaunay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X:";
            // 
            // tbConformingCoGY
            // 
            this.tbConformingCoGY.Location = new System.Drawing.Point(27, 91);
            this.tbConformingCoGY.Name = "tbConformingCoGY";
            this.tbConformingCoGY.ReadOnly = true;
            this.tbConformingCoGY.Size = new System.Drawing.Size(94, 20);
            this.tbConformingCoGY.TabIndex = 3;
            // 
            // tbConformingCoGX
            // 
            this.tbConformingCoGX.Location = new System.Drawing.Point(27, 65);
            this.tbConformingCoGX.Name = "tbConformingCoGX";
            this.tbConformingCoGX.ReadOnly = true;
            this.tbConformingCoGX.Size = new System.Drawing.Size(94, 20);
            this.tbConformingCoGX.TabIndex = 2;
            // 
            // chbConformingCoG
            // 
            this.chbConformingCoG.AutoSize = true;
            this.chbConformingCoG.Checked = true;
            this.chbConformingCoG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbConformingCoG.Location = new System.Drawing.Point(9, 42);
            this.chbConformingCoG.Name = "chbConformingCoG";
            this.chbConformingCoG.Size = new System.Drawing.Size(47, 17);
            this.chbConformingCoG.TabIndex = 1;
            this.chbConformingCoG.Text = "CoG";
            this.chbConformingCoG.UseVisualStyleBackColor = true;
            this.chbConformingCoG.CheckedChanged += new System.EventHandler(this.chbConformingCoG_CheckedChanged);
            // 
            // chbConformingTriangulate
            // 
            this.chbConformingTriangulate.AutoSize = true;
            this.chbConformingTriangulate.Location = new System.Drawing.Point(9, 19);
            this.chbConformingTriangulate.Name = "chbConformingTriangulate";
            this.chbConformingTriangulate.Size = new System.Drawing.Size(79, 17);
            this.chbConformingTriangulate.TabIndex = 0;
            this.chbConformingTriangulate.Text = "Triangulate";
            this.chbConformingTriangulate.UseVisualStyleBackColor = true;
            this.chbConformingTriangulate.Click += new System.EventHandler(this.chbConformingTriangulate_Clicked);
            // 
            // GBconstrained
            // 
            this.GBconstrained.Controls.Add(this.label3);
            this.GBconstrained.Controls.Add(this.label2);
            this.GBconstrained.Controls.Add(this.tbConstrainedCoGY);
            this.GBconstrained.Controls.Add(this.tbConstrainedCoGX);
            this.GBconstrained.Controls.Add(this.chbConstrainedCoG);
            this.GBconstrained.Controls.Add(this.chbConstrainedTriangulate);
            this.GBconstrained.Location = new System.Drawing.Point(3, 169);
            this.GBconstrained.Name = "GBconstrained";
            this.GBconstrained.Size = new System.Drawing.Size(127, 123);
            this.GBconstrained.TabIndex = 6;
            this.GBconstrained.TabStop = false;
            this.GBconstrained.Text = "Constrained Delaunay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "X:";
            // 
            // tbConstrainedCoGY
            // 
            this.tbConstrainedCoGY.Location = new System.Drawing.Point(27, 91);
            this.tbConstrainedCoGY.Name = "tbConstrainedCoGY";
            this.tbConstrainedCoGY.ReadOnly = true;
            this.tbConstrainedCoGY.Size = new System.Drawing.Size(94, 20);
            this.tbConstrainedCoGY.TabIndex = 5;
            // 
            // tbConstrainedCoGX
            // 
            this.tbConstrainedCoGX.Location = new System.Drawing.Point(27, 65);
            this.tbConstrainedCoGX.Name = "tbConstrainedCoGX";
            this.tbConstrainedCoGX.ReadOnly = true;
            this.tbConstrainedCoGX.Size = new System.Drawing.Size(94, 20);
            this.tbConstrainedCoGX.TabIndex = 4;
            // 
            // chbConstrainedCoG
            // 
            this.chbConstrainedCoG.AutoSize = true;
            this.chbConstrainedCoG.Checked = true;
            this.chbConstrainedCoG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbConstrainedCoG.Location = new System.Drawing.Point(9, 42);
            this.chbConstrainedCoG.Name = "chbConstrainedCoG";
            this.chbConstrainedCoG.Size = new System.Drawing.Size(47, 17);
            this.chbConstrainedCoG.TabIndex = 1;
            this.chbConstrainedCoG.Text = "CoG";
            this.chbConstrainedCoG.UseVisualStyleBackColor = true;
            this.chbConstrainedCoG.CheckedChanged += new System.EventHandler(this.chbConstrainedCoG_CheckedChanged);
            // 
            // chbConstrainedTriangulate
            // 
            this.chbConstrainedTriangulate.AutoSize = true;
            this.chbConstrainedTriangulate.Location = new System.Drawing.Point(9, 19);
            this.chbConstrainedTriangulate.Name = "chbConstrainedTriangulate";
            this.chbConstrainedTriangulate.Size = new System.Drawing.Size(79, 17);
            this.chbConstrainedTriangulate.TabIndex = 0;
            this.chbConstrainedTriangulate.Text = "Triangulate";
            this.chbConstrainedTriangulate.UseVisualStyleBackColor = true;
            this.chbConstrainedTriangulate.Click += new System.EventHandler(this.chbConstrainedTriangulate_Clicked);
            // 
            // tbToleranceFactor
            // 
            this.tbToleranceFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbToleranceFactor.Location = new System.Drawing.Point(12, 532);
            this.tbToleranceFactor.Name = "tbToleranceFactor";
            this.tbToleranceFactor.Size = new System.Drawing.Size(55, 20);
            this.tbToleranceFactor.TabIndex = 7;
            this.tbToleranceFactor.Text = "0,5";
            this.tbToleranceFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 516);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tolerance:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(70, 533);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "%";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(12, 558);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 598);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbToleranceFactor);
            this.Controls.Add(this.GBconstrained);
            this.Controls.Add(this.GBconforming);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "CoG Calculator";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.GBconforming.ResumeLayout(false);
            this.GBconforming.PerformLayout();
            this.GBconstrained.ResumeLayout(false);
            this.GBconstrained.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.GroupBox GBconforming;
        private System.Windows.Forms.CheckBox chbConformingCoG;
        private System.Windows.Forms.CheckBox chbConformingTriangulate;
        private System.Windows.Forms.GroupBox GBconstrained;
        private System.Windows.Forms.CheckBox chbConstrainedCoG;
        private System.Windows.Forms.CheckBox chbConstrainedTriangulate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConformingCoGY;
        private System.Windows.Forms.TextBox tbConformingCoGX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConstrainedCoGY;
        private System.Windows.Forms.TextBox tbConstrainedCoGX;
        private System.Windows.Forms.TextBox tbToleranceFactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
    }
}

