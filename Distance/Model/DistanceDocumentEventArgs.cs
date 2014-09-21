using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.Model
{
    class DistanceDocumentEventArgs
    {
        protected Microphone mic;
        protected ReferencePoint rp;

        public DistanceDocumentEventArgs(Microphone mic, ReferencePoint rp)
        {
            this.mic = mic;
            this.rp = rp;
        }

        public DistanceDocumentEventArgs(Microphone mic)
        {
            this.mic = mic;
            this.rp = null;
        }

        public DistanceDocumentEventArgs(ReferencePoint rp)
        {
            this.mic = null;
            this.rp = rp;
        }

        public Microphone Microphone { get { return mic; } }
        public ReferencePoint ReferencePoint { get { return rp; } }
    }
}
