using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dts.gui.RegistrationService;

namespace dts.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       /* private static Uri baseAddress = new Uri("http://localhost:3031/RegistrationService");
        private static RegistrationServiceClient _service;*/

        public MainWindow()
        {
            InitializeComponent();

            var model = new MainWindowModel();

            model.Init();
            this.DataContext = model;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // Debug.WriteLine(_service.Subscribe("Suhail"));
            
        }

        private void SetupRegistrationServiceClient()
        {
            /*_service = new RegistrationServiceClient(new InstanceContext(null, new RegistrationServiceCallback()));

            WSDualHttpBinding binding = (WSDualHttpBinding) _service.Endpoint.Binding;
            string uniqueCallbackAddress = baseAddress.AbsoluteUri;

            // make it unique - append a GUID
            uniqueCallbackAddress += Guid.NewGuid().ToString();
            //uniqueCallbackAddress += 9;
            binding.ClientBaseAddress = new Uri(uniqueCallbackAddress);*/
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //_service.Unsubscribe("Suhail");
        }
    }
}
