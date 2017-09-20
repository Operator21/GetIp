using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
        static HttpClient httpClient = new HttpClient();
        List<IP> ips = new List<IP>();
        IP i = new IP();
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
            /*IpGet webClient = new IpGet();
            ip = await webClient.GetCurrentIP();
            */
            
            //var ip = await httpClient.GetStringAsync("https://api.ipify.org");
            var ip = await httpClient.GetStringAsync("https://api.ipify.org?format=json");
            Debug.WriteLine(ip);
            IParser parser = new JsonParser();
            i = await parser.ParseString<IP>(ip);
            Debug.WriteLine(i.ip);
            Result.Text = i.ip;
        }
    }
}
