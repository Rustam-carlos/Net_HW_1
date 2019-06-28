using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Net_HW_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string ServerIP = null;
        static string ServerURL = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxIP.Text != null)
            {
                if (TextBoxURL.Text != null)
                {
                    ServerURL = TextBoxURL.Text;
                    IPHostEntry host1 = Dns.GetHostEntry(TextBoxURL.Text);
                    foreach (IPAddress ip in host1.AddressList)
                        TextBoxIP.Text = ip.ToString();
                }
                else
                    MessageBox.Show("Введите URL");
            }
            else
                MessageBox.Show("Ошибка ввода");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxURL.Text != null)
            {
                if (TextBoxIP.Text != null)
                {
                    ServerIP = TextBoxIP.Text;
                    IPAddress addr = IPAddress.Parse(ServerIP);
                    IPHostEntry entry = Dns.GetHostEntry(addr);
                    if (entry != null)
                        TextBoxURL.Text = entry.HostName;
                    else
                        MessageBox.Show("URL не доступен либо не существует");
                }
                else
                    MessageBox.Show("Введите IP");
            }
            else
                MessageBox.Show("Ошибка ввода");
        }
    }
}
