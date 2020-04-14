//using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:60222/TestHub")
                .Build();
            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };


        }


        private Task _connection_Closed(Exception arg)
        {
            throw new NotImplementedException();
        }

        private async Task BtnConnectAsync(object sender, RoutedEventArgs e)
        {
            _connection.On<string>("Connected", (connectionid) =>
            {
                //MessageBox.Show(connection id)
                tbMain.Text = connectionid;
            });

            _connection.On<string>("Posted", (value) =>
            {
                Dispatcher.BeginInvoke((Action)(() => 
                   {

                    messagesList.Items.Add(value);

                   }));
            
            });

            try
            {
                await _connection.StartAsync();
                messagesList.Items.Add("Connection started");
                BtnConnect.IsEnabled = false;
            }
        catch(Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        
        }
    }
}
