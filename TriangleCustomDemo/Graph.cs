using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TriangleCustomDemo.Properties;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.IO;
using TriangleNet.Meshing;
using TriangleNet.Rendering;

namespace TriangleCustomDemo
{
    class Graph
    {
        private StringBuilder filePath = new StringBuilder(@"C:\Users\Michal\Desktop\triangle.poly");
        private IPolygon input;
        private RenderManager renderManager;
        private MainWindow myGui;

        public Graph(MainWindow window)
        {
            myGui = window;
            input = FileProcessor.Read(filePath.ToString());
            IMesh mesh = input.Triangulate();

            renderManager = new RenderManager();

            IRenderControl control = new TriangleNet.Rendering.GDI.RenderControl();

            if (control != null)
            {
                InitializeRenderControl((Control)control);
                renderManager.Initialize(control);
                control.Refresh();
            }
            else
            {
                MessageBox.Show("Ooops ...", "Failed to initialize renderer.");
            }
        }

        private void InitializeRenderControl(Control control)
        {
            myGui.
            this.splitContainer.SuspendLayout();
            this.splitContainer.Panel2.Controls.Add(control);

            var size = this.splitContainer.Panel2.ClientRectangle;

            // Initialize control
            control.BackColor = Color.WhiteSmoke;
            control.Dock = DockStyle.Fill;
            control.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            control.Location = new System.Drawing.Point(0, 0);
            control.Name = "renderControl1";
            control.Size = new Size(size.Width, size.Height);
            control.TabIndex = 0;
            control.Text = "renderControl1";

            this.splitContainer.ResumeLayout();
        }
    }
}
