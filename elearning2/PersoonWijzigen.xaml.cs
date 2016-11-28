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

        private void PopulateListboxUsers()
        {

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

        #region placeholdertext
        /*  private void tbVoornaam_GotFocus(object sender, RoutedEventArgs e)
          {
              if (tbVoornaam.Text == "Voornaam")
              {
                  tbVoornaam.Text = "";
              }
          }

          private void tbVoornaam_LostFocus(object sender, RoutedEventArgs e)
          {
              if (tbVoornaam.Text=="")
              {
                  tbVoornaam.Text = "Voornaam";
              }
          }
          #endregion

          private void tbTussenvoegsel_GotFocus(object sender, RoutedEventArgs e)
          {
              if (tbTussenvoegsel.Text == "Tussenvoegsel")
              {
                  tbTussenvoegsel.Text="";
              }
          }

          private void tbTussenvoegsel_LostFocus(object sender, RoutedEventArgs e)
          {
              if (tbTussenvoegsel.Text=="")
              {
                  tbTussenvoegsel.Text = "Tussenvoegsel";
              }
          }

          private void tbAchternaam_GotFocus(object sender, RoutedEventArgs e)
          {
              if (tbAchternaam.Text == "Achternaam")
              {
                  tbAchternaam.Text = "";
              }
          }

          private void tbAchternaam_LostFocus(object sender, RoutedEventArgs e)
          {
              if (tbAchternaam.Text == "")
              {
                  tbAchternaam.Text = "Achternaam";
              }
          }

          private void tbTelefoonNummer_GotFocus(object sender, RoutedEventArgs e)
          {
              if (tbTelefoonNummer.Text == "Telefoonnummer")
              {
                  tbTelefoonNummer.Text = "";
              }
          }

          private void tbTelefoonNummer_LostFocus(object sender, RoutedEventArgs e)
          {
              if (tbTelefoonNummer.Text == "")
              {
                  tbTelefoonNummer.Text = "";
              }
          }

          private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
          {
              if (tbEmail.Text == "E-mail")
              {
                  tbEmail.Text = "";
              }
          }

          private void tbEmail_LostFocus(object sender, RoutedEventArgs e)
          {
              if (tbEmail.Text == "")
              {
                  tbEmail.Text = "E-mail";
              }
          }*/
        #endregion
    }
}
