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
using Microsoft.WindowsAzure.Management.Models;
using System.IO;

namespace AzureManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ManagementController _controller;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void _createButtonClick(object sender, RoutedEventArgs e)
        {
            if (_controller == null)
            {
                _controller = new ManagementController(
                    new ManagementControllerParamters
                {
                    SubscriptionId = "7384a11f-2cd3-4656-8c58-b6c1587aa219",
                    Base64EncodedCertificate = "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",
                    CloudServiceName = "ccondoaccount2",
                    PackageFilePath = "Mycloudservice.cspkg",
                    Region = LocationNames.EastUS,
                    StorageAccountName = "MyTempNameForNow"
                });
            }
        }

        private async void _deployButtonClick(object sender, RoutedEventArgs e)
        {
            _controller.CreateVM();
            _controller.CreateCloudService();
            _controller.DeployCloudService();
        }
    }
}
