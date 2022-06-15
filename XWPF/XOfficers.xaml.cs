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
using System.Windows.Shapes;
using XLibrary;
using XService.Models;

namespace XWPF
{
    /// <summary>
    /// Interaktionslogik für XOfficers.xaml
    /// </summary>
    public partial class XOfficers : Window
    {
        ObservableCollection<officers> oo;
        public XOfficers()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            oo = await RestHelper.GetAllOfficers();
            officerdata.ItemsSource= oo;
        }

        private async void removebtn_Click(object sender, RoutedEventArgs e)
        {
            officers officers = officerdata.SelectedItem as officers;
            if (officers == null)
            {
                return;
            }

            bool del = await RestHelper.DeleteOfficer(officers.of_id);

            if (del == true)
            {
                officerdata.Items.Remove(officers);
            }
            else
            {
                return;
            }
        }
    }
}
