using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dts.gui.View
{
    /// <summary>
    /// Interaction logic for RelativesDialogView.xaml
    /// </summary>
    public partial class RelativesDialogView : Window
    {
        public RelativesDialogView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(TimeSpan.FromMinutes(1));
        }

    }
}
