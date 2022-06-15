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
using System.Windows.Shapes;

namespace XWPF
{
    /// <summary>
    /// Interaktionslogik für XPerson.xaml
    /// </summary>
    public partial class XPerson : Window
    {
        public XPerson()
        {
            InitializeComponent();
        }

        private void cbtn_Click(object sender, RoutedEventArgs e)
        {
            XCriminal xcriminal = new XCriminal();
            xcriminal.Show();
            Close();
        }

        private void nbtn_Click(object sender, RoutedEventArgs e)
        {
            XNonCriminal xNonCriminal = new XNonCriminal();
            xNonCriminal.Show();
            Close();
        }
    }
}
