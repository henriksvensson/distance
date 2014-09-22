using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.Model
{
    class DistancePoint
    {
        private double x;
        private double y;
        private string name = "";

        public DistancePoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public DistancePoint(double x, double y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public double X { get { return x; } set { x = value; } }

        public double Y { get { return y; } set { y = value; } }

        public string Name { get { return name; } set { name = value; } }
    }
}
