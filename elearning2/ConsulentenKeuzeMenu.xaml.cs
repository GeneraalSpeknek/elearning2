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
        
      //  public string WhichButton = "hoi";
        public ConsulentenKeuzeMenu()
        {
            InitializeComponent();
        }

        private void btAddVak_Click(object sender, RoutedEventArgs e)
        {
            VakWijzigen VakWijzigenForm = new VakWijzigen();
            this.Close();
            VakWijzigenForm.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MWForm = new MainWindow();
            this.Hide();
            MWForm.Show();
        }

        private void btModifyLesonderwerp_Click(object sender, RoutedEventArgs e)
        {
            LesonderwerpWijzigen ChangeLO = new LesonderwerpWijzigen();
            this.Close();
            ChangeLO.Show();
        }

        private void btPersoonWijzigen_Click(object sender, RoutedEventArgs e)
        {
            PersoonWijzigen PWForm = new PersoonWijzigen();
            this.Close();
            PWForm.Show();
        }

        private void btVraagWijzigen_Click(object sender, RoutedEventArgs e)
        {
            VragenWijzigen VW = new VragenWijzigen();
            this.Close();
            VW.Show();
        }
    }
}
