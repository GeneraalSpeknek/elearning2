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
    /// Interaction logic for PersoonWijzigen.xaml
    /// </summary>
    public partial class PersoonWijzigen : Window
    {
        public PersoonWijzigen()
        {
            InitializeComponent();
        }

        private void btAddPerson_Click(object sender, RoutedEventArgs e)
        {
            string sVoornaam = tbVoornaam.Text;
            string sTussenvoegsel = tbTussenvoegsel.Text;
            string sAchternaam = tbAchternaam.Text;
            string sTelefoonnummer = tbTelefoonNummer.Text;
            string sEmail = tbEmail.Text;
            string sKamerNummer = UdKamerNummer.Text;

            new Dbs_Conn().AddPerson(sVoornaam, sTussenvoegsel, sAchternaam, sTelefoonnummer, sEmail, sKamerNummer);
        }
    }
}
