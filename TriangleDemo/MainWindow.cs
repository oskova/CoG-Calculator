using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleDemo
{
    public partial class MainWindow : Form
    {
        Graph graph;
        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph(this);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                graph.LoadInputFile(openFileDialog.FileName);
                graph.RenderFloorPlan();
            }
        }

        private void btnTriangulate_Click(object sender, EventArgs e)
        {
            graph.RenderTriangles();
        }

        private void btnCoG_Click(object sender, EventArgs e)
        {
            graph.RenderCoG();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            graph.Resize();
        }
    }
}
