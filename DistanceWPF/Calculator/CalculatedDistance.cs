using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.Calculator
{
    class CalculatedDistance
    {
        public string MicrophoneName { get; set; }
        public double Distance { get; set; }

        public CalculatedDistance(string microphoneName, double distance)
        {
            MicrophoneName = microphoneName;
            Distance = distance;
        }
    }
}
