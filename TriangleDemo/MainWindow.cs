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
                List<TriangleNet.Geometry.Point> points = graph.CalculateCoG();
                if (points != null)
                {
                    tbConformingCoGX.Text = points[0].X.ToString();
                    tbConformingCoGY.Text = points[0].Y.ToString();
                    tbConstrainedCoGX.Text = points[1].X.ToString();
                    tbConstrainedCoGY.Text = points[1].Y.ToString();
                }
                label.Text = openFileDialog.FileName;
            }
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            graph.Resize();
        }

        private void chbConstrainedTriangulate_Clicked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.Options.ConformingDelaunay = false;
            graph.RenderTriangles(checkbox.Checked);
            chbConformingTriangulate.Checked = false;
        }

        private void chbConstrainedCoG_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.RenderConstrainedCoG(checkbox.Checked);
        }

        private void chbConformingTriangulate_Clicked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.Options.ConformingDelaunay = true;
            graph.RenderTriangles(checkbox.Checked);
            chbConstrainedTriangulate.Checked = false;
        }

        private void chbConformingCoG_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.RenderConformingCoG(checkbox.Checked);
        }
    }
}
