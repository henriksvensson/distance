using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Distance.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distance.View
{
    class MicrophoneIcon : DistanceIcon
    {
        protected Microphone mic;

        public MicrophoneIcon(Microphone mic)
        {
            this.mic = mic;
            this.icon = new PictureBox();
            this.icon.Image = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\microphone.png");
            this.icon.Location = new Point(mic.X, mic.Y);

            this.icon.MouseDown += icon_MouseDown;
        }

        void icon_MouseDown(object sender, MouseEventArgs e)
        {
            Icon.DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
