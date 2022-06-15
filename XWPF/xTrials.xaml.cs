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
    /// Interaktionslogik für xTrials.xaml
    /// </summary>
    public partial class xTrials : Window
    {
        ObservableCollection<trial> ot;
        public xTrials()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ot = await RestHelper.GetTrials();
            trialdata.ItemsSource = ot;
        }

        private async void removebtn_Click(object sender, RoutedEventArgs e)
        {
            trial trial = trialdata.SelectedItem as trial;
            if (trial == null)
            {
                return;
            }

            bool del = await RestHelper.DeleteTrial(trial.t_id);

            if (del == true)
            {
                trialdata.Items.Remove(trial);
            }
            else
            {
                return;
            }
        }
    }
}
