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
    /// Interaktionslogik für XCriminal.xaml
    /// </summary>
    public partial class XCriminal : Window
    {
        ObservableCollection<criminal> oc;
        public XCriminal()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            oc = await RestHelper.GetCriminals();
            criminaldata.ItemsSource = oc;
        }

        private async void removebtn_Click(object sender, RoutedEventArgs e)
        {
            criminal criminal = criminaldata.SelectedItem as criminal;
            if(criminal == null)
            {
                return;
            }

            bool del = await RestHelper.DeleteCriminal(criminal.p_id);

            if (del == true)
            {
                criminaldata.Items.Remove(criminal);
            }
            else
            {
                return;
            }
        }
    }
}
