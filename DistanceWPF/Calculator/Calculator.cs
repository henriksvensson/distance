using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Distance.Model;

namespace Distance.Calculator
{
    class Calculator
    {
        private DistanceDocument doc;
        private ObservableCollection<CalculatedDistance> distances;

        public Calculator(DistanceDocument doc)
        {
            this.doc = doc;
            this.distances = new ObservableCollection<CalculatedDistance>();
            this.Recalculate();
            this.doc.Changed += doc_Changed;
        }

        void doc_Changed(object sender, EventArgs e)
        {
            Recalculate();
        }

        public ObservableCollection<CalculatedDistance> Distances { get { return distances; } }

        public void Recalculate()
        {
            distances.Clear();

            if (doc.ReferencePoints.Count > 0)
            {
                ReferencePoint rp = doc.ReferencePoints[0];

                foreach (Microphone m in doc.Microphones)
                {
                    distances.Add(new CalculatedDistance(m.Name, Math.Sqrt(Math.Pow(rp.X - m.X, 2) + Math.Pow(rp.Y - m.Y, 2)) * doc.Scale ));
                }
            }
        }
    }
}
