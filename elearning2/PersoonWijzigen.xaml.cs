using System;
using System.Collections.Generic;
using System.Data;
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
        string sRol;

        struct UserInfoId
        {
            public string Userinfoid { get; set; }
        }
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

            string sUsrname = tbGebruikersnaam.Text;
            string sPass = tbPass.Password;

            new Dbs_Conn().AddUser(sUsrname, sPass, sRol);

            DataTable dtUserLoginId = new Dbs_Conn().GetUserLoginId(sUsrname);
            string sInlogInfoId = Convert.ToString(dtUserLoginId.Rows[0]["id"]);

            new Dbs_Conn().AddPerson(sVoornaam, sTussenvoegsel, sAchternaam, sTelefoonnummer, sEmail, sKamerNummer, sInlogInfoId);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            sRol = "leerling";
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            sRol = "consulent";
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ConsulentenKeuzeMenu CKM = new ConsulentenKeuzeMenu();
            this.Close();
            CKM.Show();
        }
    }
}
