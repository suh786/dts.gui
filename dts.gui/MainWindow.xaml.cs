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
using dts.gui.PersonSubscriptionService;

namespace dts.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel _model;
        /* private static Uri baseAddress = new Uri("http://localhost:3031/RegistrationService");
        private static RegistrationServiceClient _service;*/

        public MainWindow()
        {
            InitializeComponent();

            /*this.Loaded += OnLoaded;
            _model = new MainWindowModel();

            this.DataContext = _model;

            _model.Init();*/

            SetupRegistrationServiceClient();

            //dtsPersonServiceClient.Subscribe();

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
           
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(dtsPersonServiceClient.Subscribe());
            
        }
        private static readonly Uri _baseAddress = new Uri("http://localhost:3031/PersonSubscriptionService");
        private PersonSubscriptionServiceClient dtsPersonServiceClient;

        private void SetupRegistrationServiceClient()
        {
            dtsPersonServiceClient = new PersonSubscriptionServiceClient(new InstanceContext(null, new RegistrationServiceCallback()));
            var uniqueCallbackAddress = _baseAddress.AbsoluteUri;
            // make it unique - append a GUID
            uniqueCallbackAddress += Guid.NewGuid().ToString();
            ((WSDualHttpBinding)dtsPersonServiceClient.Endpoint.Binding).ClientBaseAddress = new Uri(uniqueCallbackAddress);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //_service.Unsubscribe("Suhail");
        }
    }
}
