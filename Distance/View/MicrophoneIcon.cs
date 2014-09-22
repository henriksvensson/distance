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
            Icon.SizeMode = PictureBoxSizeMode.AutoSize;

            Bitmap b = new Bitmap(@"C:\Users\Henrik\Documents\visual studio 2013\Projects\Distance\Distance\microphone.png");
            b.MakeTransparent();
            Icon.Image = b;
            
            // Place the image so that the center of it is where the document mic coordinates are.
            Icon.Location = new Point(mic.X - Icon.Image.Width / 2, mic.Y - Icon.Image.Height / 2);

            // Register for updates on the mouse down event so that we may start a drag'n'drop operation.
            this.icon.MouseDown += icon_MouseDown;
        }

        void icon_MouseDown(object sender, MouseEventArgs e)
        {
            Icon.DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
