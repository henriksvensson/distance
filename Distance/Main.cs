using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Distance.Model;

namespace Distance
{
    public partial class Main : Form
    {
        private DistanceDocument doc;
        private Calculator.Calculator calc;

        public Main()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            pbPlan.Image = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\plan.jpg");
            doc = new DistanceDocument();
            doc.Changed += doc_Changed;

            calc = new Calculator.Calculator(doc);

            dataGridView1.DataSource = calc.Results;
        }

        void doc_Changed(object sender, EventArgs e)
        {
            pbPlan.Refresh();
        }

        private void pbPlan_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                doc.AddMicrophone(new Microphone(e.X, e.Y));

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                doc.AddReferencePoint(new ReferencePoint(e.X, e.Y));
        }

        private void pbPlan_Paint(object sender, PaintEventArgs e)
        {
            Image micicon = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\microphone.png");
            Image rpicon = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\referencepoint.png");
            foreach (Microphone m in doc.Microphones)
            {
                e.Graphics.DrawImage(micicon, m.X, m.Y);
            }

            foreach (ReferencePoint rp in doc.ReferencePoints)
            {
                e.Graphics.DrawImage(rpicon, rp.X, rp.Y);
            }
        }
    }
}
