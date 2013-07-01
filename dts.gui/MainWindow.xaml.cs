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
using dts.gui.View;

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

            _model = new MainWindowModel();

            this.DataContext = _model;

            _model.Init();

        }

        private void HandleShowRelatives(object sender, RoutedEventArgs e)
        {
            var relativesDialog = new RelativesDialogView();
            relativesDialog.ShowDialog();
        }
    }
}
