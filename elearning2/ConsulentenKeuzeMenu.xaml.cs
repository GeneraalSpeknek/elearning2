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

namespace elearning2
{
    /// <summary>
    /// Interaction logic for ConsulentenKeuzeMenu.xaml
    /// </summary>
    public partial class ConsulentenKeuzeMenu : Window
    {
        
        VakWijzigen VakWijzigenForm = new VakWijzigen();
      //  public string WhichButton = "hoi";
        public ConsulentenKeuzeMenu()
        {
            InitializeComponent();
        }

        private void btAddVak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            VakWijzigenForm.Show();
        }
    }
}
