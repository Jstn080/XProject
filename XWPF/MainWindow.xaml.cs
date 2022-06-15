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

namespace XWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void pbtn_Click(object sender, RoutedEventArgs e)
        {
            XPerson xPerson = new XPerson();
            xPerson.Show();
            Close();
        }

        private void obtn_Click(object sender, RoutedEventArgs e)
        {
            XOfficers xOfficers = new XOfficers();
            xOfficers.Show();
            Close();
        }

        private void tbtn_Click(object sender, RoutedEventArgs e)
        {
            xTrials xTrials = new xTrials();
            xTrials.Show();
            Close();
        }
    }
}
