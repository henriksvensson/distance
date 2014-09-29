using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Distance.Model;
using Distance.Calculator;
using Distance.View;
using System.Data;

namespace DistanceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DistanceDocument doc;
        private Calculator calc;

        public MainWindow()
        {
            InitializeComponent();

            doc = new DistanceDocument();
            doc.Changed += doc_Changed;
            doc.MicrophoneAdded += doc_MicrophoneAdded;
            doc.ReferencePointAdded += doc_ReferencePointAdded;

            calc = new Calculator(doc);
            dataGrid.DataContext = calc.Distances;

            doc.Plan = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/plan.jpg")));
            doc.Scale = 0.3; // meter per pixel
        }

        void doc_MicrophoneAdded(object sender, DistanceDocumentEventArgs e)
        {
            // A new microphone was added to the document. Create a new icon for it
            // and place it on the plan.
            var mi = new MicrophoneIcon(e.Microphone);
            mainCanvas.Children.Add(mi.Icon);
            // Center the icon on the coordinates from the document.
            Canvas.SetLeft(mi.Icon, e.Microphone.X - mi.Icon.Source.Width / 2);
            Canvas.SetTop(mi.Icon, e.Microphone.Y - mi.Icon.Source.Height / 2);
        }

        void doc_ReferencePointAdded(object sender, DistanceDocumentEventArgs e)
        {
            // A new ReferencePoint was added to the document. Create a new icon for it
            // and place it on the plan.
            var rp = new ReferencePointIcon(e.ReferencePoint);
            mainCanvas.Children.Add(rp.Icon);
            // Center the icon on the coordinates from the document.
            Canvas.SetLeft(rp.Icon, e.ReferencePoint.X - rp.Icon.Source.Width / 2);
            Canvas.SetTop(rp.Icon, e.ReferencePoint.Y - rp.Icon.Source.Height / 2);
        }

        void doc_Changed(object sender, EventArgs e)
        {
            // Update background image if necessary
            if (mainCanvas.Background != doc.Plan)
                mainCanvas.Background = doc.Plan;

            //// Recalculate and update data grid
            //if (calc != null)
            //    calc.Recalculate();
            //if (dataGridView1 != null)
            //    dataGridView1.Refresh();
        }

        private void mainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            doc.AddMicrophone(new Microphone(e.GetPosition(mainCanvas).X, e.GetPosition(mainCanvas).Y));
        }

        private void mainCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            doc.AddReferencePoint(new ReferencePoint(e.GetPosition(mainCanvas).X, e.GetPosition(mainCanvas).Y));
        }
    }
}
