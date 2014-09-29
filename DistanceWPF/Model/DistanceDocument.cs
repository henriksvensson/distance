using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Distance.Model
{
    class DistanceDocument
    {
        private List<Microphone> microphones = new List<Microphone>();
        private List<ReferencePoint> referencePoints = new List<ReferencePoint>();
        private ImageBrush plan = null;
        private double scale = 0; // In meter per pixel

        public List<Microphone> Microphones { get { return microphones; } }
        public List<ReferencePoint> ReferencePoints { get { return referencePoints; } }

        public ImageBrush Plan
        {
            get { return plan; }
            set
            {
                this.plan = value;
                this.plan.Stretch = Stretch.None;
                this.plan.AlignmentX = AlignmentX.Left;
                this.plan.AlignmentY = AlignmentY.Top;
                OnChanged(EventArgs.Empty);
            }
        }

        public double Scale { get { return scale; } set { scale = value; OnChanged(EventArgs.Empty); } }

        #region Events

        public delegate void MicrophoneAddedEventHandler(object sender, DistanceDocumentEventArgs e);
        public event MicrophoneAddedEventHandler MicrophoneAdded;
        protected virtual void OnMicrophoneAdded(DistanceDocumentEventArgs e)
        {
            if (MicrophoneAdded != null)
                MicrophoneAdded(this, e);
        }

        public delegate void ReferencePointAddedEventHandler(object sender, DistanceDocumentEventArgs e);
        public event ReferencePointAddedEventHandler ReferencePointAdded;
        protected virtual void OnReferencePointAdded(DistanceDocumentEventArgs e)
        {
            if (ReferencePointAdded != null)
                ReferencePointAdded(this, e);
        }

        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        #endregion

        public void AddMicrophone(Microphone m)
        {
            microphones.Add(m);
            if (string.IsNullOrWhiteSpace(m.Name))
                m.Name = "Microphone " + microphones.Count;
            OnMicrophoneAdded(new DistanceDocumentEventArgs(m));
            OnChanged(EventArgs.Empty);
        }

        public void AddReferencePoint(ReferencePoint rp)
        {
            referencePoints.Add(rp);
            OnReferencePointAdded(new DistanceDocumentEventArgs(rp));
            OnChanged(EventArgs.Empty);
        }

    }
}
