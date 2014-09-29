using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Distance.Model;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Distance.View
{
    class ReferencePointIcon : DistanceIcon
    {
        protected ReferencePoint rp;

        public ReferencePointIcon(ReferencePoint rp)
        {
            this.rp = rp;

            icon = new Image();
            icon.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "Images/referencepoint.png"));

            // Register for updates on the mouse down event so that we may start a drag'n'drop operation.
            this.icon.MouseDown += icon_MouseDown;
        }

        void icon_MouseDown(object sender, MouseEventArgs e)
        {
            //Icon.DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
