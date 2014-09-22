using System;
using System.Collections.Generic;
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
        private DataTable results;

        public Calculator(DistanceDocument doc)
        {
            this.doc = doc;
            this.results = new DataTable();
            results.Columns.Add("Microphone");
            results.Columns.Add("Distance");

            this.doc.Changed += doc_Changed;
        }

        void doc_Changed(object sender, EventArgs e)
        {
            Recalculate();
        }

        public DataTable Results { get { return results; } }

        public void Recalculate()
        {
            results.Clear();

            if (doc.ReferencePoints.Count > 0)
            {
                ReferencePoint rp = doc.ReferencePoints[0];

                foreach (Microphone m in doc.Microphones)
                {
                    DataRow dr = results.NewRow();
                    dr[0] = m.Name;
                    dr[1] = Math.Sqrt(Math.Pow(rp.X - m.X, 2) + Math.Pow(rp.Y - m.Y, 2));

                    results.Rows.Add(dr);
                }
            }
        }
    }
}
