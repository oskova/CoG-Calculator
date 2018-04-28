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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTriangulate = new System.Windows.Forms.Button();
            this.btnCoG = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(122, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 405);
            this.panel1.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnTriangulate
            // 
            this.btnTriangulate.Location = new System.Drawing.Point(13, 41);
            this.btnTriangulate.Name = "btnTriangulate";
            this.btnTriangulate.Size = new System.Drawing.Size(103, 23);
            this.btnTriangulate.TabIndex = 2;
            this.btnTriangulate.Text = "Triangulate";
            this.btnTriangulate.UseVisualStyleBackColor = true;
            this.btnTriangulate.Click += new System.EventHandler(this.btnTriangulate_Click);
            // 
            // btnCoG
            // 
            this.btnCoG.Location = new System.Drawing.Point(13, 70);
            this.btnCoG.Name = "btnCoG";
            this.btnCoG.Size = new System.Drawing.Size(103, 23);
            this.btnCoG.TabIndex = 3;
            this.btnCoG.Text = "Center Of Gravity";
            this.btnCoG.UseVisualStyleBackColor = true;
            this.btnCoG.Click += new System.EventHandler(this.btnCoG_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.Filter = ".csv file|*.csv";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 429);
            this.Controls.Add(this.btnCoG);
            this.Controls.Add(this.btnTriangulate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnTriangulate;
        private System.Windows.Forms.Button btnCoG;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

