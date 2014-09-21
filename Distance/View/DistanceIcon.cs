using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distance.View
{
    abstract class DistanceIcon
    {
        protected PictureBox icon;

        public PictureBox Icon { get { return icon; } }
    }
}
