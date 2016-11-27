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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace elearning2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public struct inloggegevens
        {
            public string RolID { get; set; }
            public string inlognaam { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            tbUsrName.Focus();
        }

        private void tbLogin_Click(object sender, RoutedEventArgs e)
        {
            string usrname = tbUsrName.Text;
            string pwd = tbPwd.Password;

            if(usrname == "" || pwd == "")
            {
                MessageBox.Show("U moet in beide tekstvelden iets invullen!");
            }

            DataTable dtLoginCheck = new Dbs_Conn().LoginCheck(usrname,pwd);

            int iRows = Convert.ToInt32(dtLoginCheck.Rows.Count.ToString());
            
            if (iRows == 0)
            {
                MessageBox.Show("U heeft een verkeerde gebruikersnaam of wachtwoord ingevoerd.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (iRows == 1)
            {
                DataTable RolChecker = new Dbs_Conn().RolChecker(usrname);
                string RolID = Convert.ToString(dtLoginCheck.Rows[0]["rol"]);

                if (RolID == "consulent")
                {
                    ConsulentenKeuzeMenu CKM = new ConsulentenKeuzeMenu();
                    this.Close();
                    CKM.Show();
                }
                if (RolID == "leerling")
                {
                    MessageBox.Show("Ingelogd als leerling!");
                }

            }
        }

        private void btCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
