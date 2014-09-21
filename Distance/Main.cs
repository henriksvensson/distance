using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Distance.View;

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

        private void Main_Load(object sender, EventArgs e)
        {
            pMainArea.BackgroundImage = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\plan.jpg");
            pMainArea.BackgroundImageLayout = ImageLayout.None;
            pMainArea.MouseClick += pMainArea_MouseClick;

            pMainArea.AllowDrop = true;
            pMainArea.DragEnter += pMainArea_DragEnter;
            pMainArea.DragDrop += pMainArea_DragDrop;

            doc = new DistanceDocument();
            doc.Changed += doc_Changed;
            doc.MicrophoneAdded += doc_MicrophoneAdded;

            calc = new Calculator.Calculator(doc);
            dataGridView1.DataSource = calc.Results;
        }

        void pMainArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                doc.AddMicrophone(new Microphone(e.X, e.Y));

            if (e.Button == MouseButtons.Right)
                doc.AddReferencePoint(new ReferencePoint(e.X, e.Y));
        }

        void pMainArea_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void pMainArea_DragEnter(object sender, DragEventArgs e)
        {
            MicrophoneIcon mi = (MicrophoneIcon)e.Data.GetData(typeof(MicrophoneIcon));
            if (mi != null)
            {
                mi.Icon.Location = new Point(e.X, e.Y);
            }
        }

        void doc_MicrophoneAdded(object sender, DistanceDocumentEventArgs e)
        {
            var mi = new MicrophoneIcon(e.Microphone);
            pMainArea.Controls.Add(mi.Icon);
        }

        void doc_Changed(object sender, EventArgs e)
        {
            calc.Recalculate();
            dataGridView1.Refresh();
        }

    }
}
