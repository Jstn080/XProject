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
    /// Interaktionslogik für XNonCriminal.xaml
    /// </summary>
    public partial class XNonCriminal : Window
    {
        ObservableCollection<non_criminal> on;
        public XNonCriminal()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            on = await RestHelper.GetNonCriminals();
            noncriminaldata.ItemsSource = on;
        }

        private async void addbtn_Click(object sender, RoutedEventArgs e)
        {
            int age = Convert.ToInt32(agetxt.Text);
            string name = nametxt.Text;
            string job = jobtxt.Text;
            string image = imagetxt.Text;
            string address = addresstxt.Text;

            non_criminal newnoncriminal = new non_criminal(age, name, job, image);
            await RestHelper.AddNoncriminal(newnoncriminal);
            
        }
    }
}
