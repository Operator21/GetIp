using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GetIP
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IP> ip = new List<IP>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getid_btn_Click(object sender, RoutedEventArgs e)
        {
             Getip();
        }
        private async Task Getip()
        {
            IpGet webClient = new IpGet();
            ip = await webClient.GetCurrentIP();
            foreach(IP i in ip)
            {
                Result.Text = i.Ipv4;
            }
        }
    }
}
