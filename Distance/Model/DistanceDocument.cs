using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.Model
{
    class DistanceDocument
    {
        private List<Microphone> microphones = new List<Microphone>();
        private List<ReferencePoint> referencePoints = new List<ReferencePoint>();
        private Image plan = null;

        public List<Microphone> Microphones { get { return microphones; } }

        public List<ReferencePoint> ReferencePoints { get { return referencePoints; } }

        public Image Plan { get { return plan; } set { this.plan = value; } }

        public delegate void ChangedEventHandler(object sender, EventArgs e);

        public event ChangedEventHandler Changed;

        public void AddMicrophone(Microphone m)
        {
            microphones.Add(m);
            OnChanged(EventArgs.Empty);
        }

        public void AddReferencePoint(ReferencePoint rp)
        {
            referencePoints.Add(rp);
            OnChanged(EventArgs.Empty);
        }
        
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

    }
}
