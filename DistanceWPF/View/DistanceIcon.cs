using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace Distance.View
{
    abstract class DistanceIcon
    {
        protected Image icon;

        public Image Icon { get { return icon; } }
    }
}
