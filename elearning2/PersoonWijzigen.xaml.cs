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
        bool ValidateGegevensInputBool;

        struct UserInfoId
        {
            public string Userinfoid { get; set; }
        }


        struct UserInfo
        {
            public string UserId { get; set; }
            public string voornaam { get; set; }
            public string tussenvoegsel { get; set; }
            public string achternaam { get; set; }
            public string kamernummer { get; set; }
            public string telefoonnummer { get; set; }
            public string email { get; set; }
            public string inloginfoId { get; set; }
        }

        struct UserCredentials
        {
            public string inlogId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Rol { get; set; }

        }
        public PersoonWijzigen()
        {
            InitializeComponent();
            PopulateLVUsers();
        }

        private void ValidateGegevensInput()
        {
            if (tbVoornaam.Text == "" || tbAchternaam.Text == "" || tbTelefoonNummer.Text == "" || tbEmail.Text == "" || tbGebruikersnaam.Text == "" || tbPass.Password == "" || cbRol.Text == "")
            {
                ValidateGegevensInputBool = false;
            }
            else
            {
                ValidateGegevensInputBool = true;
            }
        }
        private void PopulateLVUsers()
        {
            DataTable dtLesonderwerpen = new Dbs_Conn().GetUser();
            if (dtLesonderwerpen != null)
            {
                List<UserInfo> lstUsers = new List<UserInfo>();

                foreach (DataRow drLesonderwerpen in dtLesonderwerpen.Rows)
                {
                    lstUsers.Add(new UserInfo() { UserId = drLesonderwerpen[0].ToString(),
                        voornaam = drLesonderwerpen[1].ToString(),
                        tussenvoegsel = drLesonderwerpen[2].ToString(),
                        achternaam = drLesonderwerpen[3].ToString(),
                        kamernummer = drLesonderwerpen[4].ToString(),
                        telefoonnummer = drLesonderwerpen[5].ToString(),
                        email = drLesonderwerpen[6].ToString(),
                        inloginfoId = drLesonderwerpen[7].ToString()
                    });
                }
                lvUsers.ItemsSource = lstUsers;
            }
        }
        private void btAddPerson_Click(object sender, RoutedEventArgs e)
        {
            ValidateGegevensInput();
            if (ValidateGegevensInputBool == true)
            {          
                string sUsrname = tbGebruikersnaam.Text;

                DataTable dtCheckUsername = new Dbs_Conn().CheckUserName(sUsrname);
                if (dtCheckUsername != null)
                {
                    int iRowsCheckUsername = dtCheckUsername.Rows.Count;
                    if (iRowsCheckUsername == 0)
                    {
                        string sVoornaam = tbVoornaam.Text;
                        string sTussenvoegsel = tbTussenvoegsel.Text;
                        string sAchternaam = tbAchternaam.Text;
                        string sTelefoonnummer = tbTelefoonNummer.Text;
                        string sEmail = tbEmail.Text;
                        string sKamerNummer = UdKamerNummer.Text;
                        string sPass = tbPass.Password;

                        new Dbs_Conn().AddUser(sUsrname, sPass, sRol);

                        DataTable dtUserLoginId = new Dbs_Conn().GetUserLoginId(sUsrname);
                        string sInlogInfoId = Convert.ToString(dtUserLoginId.Rows[0]["id"]);

                        new Dbs_Conn().AddPerson(sVoornaam, sTussenvoegsel, sAchternaam, sTelefoonnummer, sEmail, sKamerNummer, sInlogInfoId);

                        PopulateLVUsers();
                    }
                    else
                    {
                        MessageBox.Show("De gekozen gebruikersnaam is al in gebruik, kies een andere gebruikersnaam.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Verplichte velden mogen niet leeg zijn! Verplichte velden kun je herkennen aan een '*'.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
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

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUsers.SelectedItem != null)
            {
                tbVoornaam.Text = ((UserInfo)(lvUsers.SelectedItem)).voornaam;
                tbTussenvoegsel.Text = ((UserInfo)(lvUsers.SelectedItem)).tussenvoegsel;
                tbAchternaam.Text = ((UserInfo)(lvUsers.SelectedItem)).achternaam;
                tbTelefoonNummer.Text = ((UserInfo)(lvUsers.SelectedItem)).telefoonnummer;
                tbEmail.Text = ((UserInfo)(lvUsers.SelectedItem)).email;
                UdKamerNummer.Text = ((UserInfo)(lvUsers.SelectedItem)).kamernummer;
                string inloginfoId = ((UserInfo)(lvUsers.SelectedItem)).inloginfoId;
                string UserInfoId = ((UserInfo)(lvUsers.SelectedItem)).UserId;
                MessageBox.Show("inloginfoId = "+inloginfoId+ " userinfoid="+UserInfoId);

                DataTable dtUserCredentials = new Dbs_Conn().GetUserCredentials(inloginfoId);
                if (dtUserCredentials != null)
                {
                    string sUserCredentialsUsername = Convert.ToString(dtUserCredentials.Rows[0]["usrname"]);
                    string sUserCredentialsPass = Convert.ToString(dtUserCredentials.Rows[0]["pass"]);
                    string sUserCredentialsRol = Convert.ToString(dtUserCredentials.Rows[0]["rol"]);

                    tbGebruikersnaam.Text = sUserCredentialsUsername;
                    tbPass.Password = sUserCredentialsPass;
                    if (sUserCredentialsRol == "leerling")
                    {
                        cbRol.SelectedIndex = 0;
                    }
                    else if (sUserCredentialsRol == "consulent")
                    {
                        cbRol.SelectedIndex = 1;
                    }
                }
            }
        }

        private void btDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string sTussenvoegsel;
            string sVoornaam = ((UserInfo)(lvUsers.SelectedItem)).voornaam;
            string sTSVZonderTest = ((UserInfo)(lvUsers.SelectedItem)).tussenvoegsel;
            string sAchternaam = ((UserInfo)(lvUsers.SelectedItem)).achternaam;

            if (sTSVZonderTest != "")
            {
                sTussenvoegsel = " " + sTSVZonderTest + " ";
            }
            else
            {
                sTussenvoegsel = " ";
            }

            MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je '" + sVoornaam +""+ sTussenvoegsel +"" + sAchternaam + "' wilt verwijderen als gebruiker?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (DeleteYesNo == MessageBoxResult.Yes)
            {
                string inloginfoId = ((UserInfo)(lvUsers.SelectedItem)).inloginfoId;
                new Dbs_Conn().DeleteUserInloginfo(inloginfoId);
                
                string UserInfoId = ((UserInfo)(lvUsers.SelectedItem)).UserId;
                new Dbs_Conn().DeleteUserUserInfo(UserInfoId);
                PopulateLVUsers();

                tbVoornaam.Text = "";
                tbTussenvoegsel.Text = "";
                tbAchternaam.Text = "";
                tbTelefoonNummer.Text = "";
                tbEmail.Text = "";
                UdKamerNummer.Text = "";

                tbGebruikersnaam.Text = "";
                tbPass.Password = "";

                cbRol.SelectedIndex = -1;
            }
        }

        private void btModifyUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem != null)
            {
                /*string UserInfoIdChange = ((UserInfo)(lvUsers.SelectedItem)).UserId;
            string sVoornaamChange = tbVoornaam.Text;
            string sTussenvoegselChange = tbTussenvoegsel.Text;
            string sAchternaamChange = tbAchternaam.Text;
            string sTelefoonnummerChange = tbTelefoonNummer.Text;
            string sEmailChange = tbEmail.Text;
            string sKamerNummerChange = UdKamerNummer.Text;

            //int UserInfoIdChange = int.Parse(((UserInfo)(lvUsers.SelectedItem)).UserId);
            new Dbs_Conn().ChangeUserUserinfo(sVoornaamChange, sTussenvoegselChange, sAchternaamChange, sTelefoonnummerChange, sEmailChange, sKamerNummerChange, UserInfoIdChange);
            */
                ValidateGegevensInput();
                if (ValidateGegevensInputBool == true)
                {
                    string sUsernameChange = tbGebruikersnaam.Text;
                    int iinloginfoIdChange = int.Parse(((UserInfo)(lvUsers.SelectedItem)).inloginfoId);

                    DataTable dtCheckUsername = new Dbs_Conn().CheckUserName(sUsernameChange);
                    if (dtCheckUsername != null)
                    {
                        int iCheckUsername = Convert.ToInt32(dtCheckUsername.Rows[0]["id"]);
                        int iCheckUsernameRows = dtCheckUsername.Rows.Count;
                        if (iCheckUsername == iinloginfoIdChange || iCheckUsernameRows == 0)
                        {
                            string sinloginfoIdChange = ((UserInfo)(lvUsers.SelectedItem)).inloginfoId;
                            string sVoornaamChange = tbVoornaam.Text;
                            string sTussenvoegselChange = tbTussenvoegsel.Text;
                            string sAchternaamChange = tbAchternaam.Text;
                            string sTelefoonnummerChange = tbTelefoonNummer.Text;
                            string sEmailChange = tbEmail.Text;
                            string sKamerNummerChange = UdKamerNummer.Text;

                            string UserInfoIdChange = ((UserInfo)(lvUsers.SelectedItem)).UserId;

                            new Dbs_Conn().ChangeUserUserinfo(sVoornaamChange, sTussenvoegselChange, sAchternaamChange, sTelefoonnummerChange, sEmailChange, sKamerNummerChange, UserInfoIdChange);

                            string sPassChange = tbPass.Password;
                            new Dbs_Conn().ChangeInlogGegevens(sUsernameChange, sPassChange, sRol, sinloginfoIdChange);
                            //new Dbs_Conn().ChangeUserInlogInfo(sUsernameChange, sPassChange, sRol, inloginfoIdChange);

                            PopulateLVUsers();
                        }
                        else
                        {
                            MessageBox.Show("De gekozen gebruikersnaam is al in gebruik, kies een andere gebruikersnaam.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Verplichte velden mogen niet leeg zijn! Verplichte velden kun je herkennen aan een '*'.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                //string sPass = tbPass.Password;
            }
            else
            {
                MessageBox.Show("Selecteer een gebruiker die je wil aanpassen!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
