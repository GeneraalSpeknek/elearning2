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
    /// Interaction logic for VragenWijzigen.xaml
    /// </summary>
    public partial class VragenWijzigen : Window
    {
        int KiesVakId = 0;
        int KiesLesonderwerpId = 0;
        int KiesLesId = 0;

        string[] ArrayAntwoorden = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        struct Vakken
        {
            public string vakId { get; set; }
            public string VakNaam { get; set; }
        }

        struct LesOnderwerpen
        {
            public string LesOnderwerpId { get; set; }
            public string LesonderwerpNaam { get; set; }
        }

        struct Vragen
        {
            public string VraagId { get; set; }
            public string VraagTekst { get; set; }
            public string VraagNaam { get; set; }
        }

        struct Lessen
        {
            public string LesId { get; set; }
            public string LesNaam { get; set; }
        }

        #region Declare Bools Checkboxes
        int bCheckboxA;
        int bCheckboxB;
        int bCheckboxC;
        int bCheckboxD;
        int bCheckboxE;
        int bCheckboxF;
        int bCheckboxG;
        int bCheckboxH;
        int bCheckboxI;
        int bCheckboxJ;
        #endregion
        public VragenWijzigen()
        {
            InitializeComponent();
            FillCBKiesVak();
            TBInvisibleAntwoorden();
            DisableInputFields();
        }
        #region CheckCheckboxes
        private void CheckCheckboxes()
        {
            if (cbxA.IsChecked == true)
            {
                bCheckboxA = 1;
            }
            else
            {
                bCheckboxA = 0;
            }

            if (cbxB.IsChecked == true)
            {
                bCheckboxB = 1;
            }
            else
            {
                bCheckboxB = 0;
            }
            if (cbxC.IsChecked == true)
            {
                bCheckboxC = 1;
            }
            else
            {
                bCheckboxC = 0;
            }
            if (cbxD.IsChecked == true)
            {
                bCheckboxD = 1;
            }
            else
            {
                bCheckboxD = 0;
            }
            if (cbxE.IsChecked == true)
            {
                bCheckboxE = 1;
            }
            else
            {
                bCheckboxE = 0;
            }
            if (cbxF.IsChecked == true)
            {
                bCheckboxF = 1;
            }
            else
            {
                bCheckboxF = 0;
            }
            if (cbxG.IsChecked == true)
            {
                bCheckboxG = 1;
            }
            else
            {
                bCheckboxG = 0;
            }
            if (cbxH.IsChecked == true)
            {
                bCheckboxH = 1;
            }
            else
            {
                bCheckboxH = 0;
            }
            if (cbxI.IsChecked == true)
            {
                bCheckboxI = 1;
            }
            else
            {
                bCheckboxI = 0;
            }
            if (cbxJ.IsChecked == true)
            {
                bCheckboxJ = 1;
            }
            else
            {
                bCheckboxJ = 0;
            }
        }
        #endregion

        private void DisableInputFields()
        {
            cbLesonderwerpKiezen.IsEnabled = false;
            cbLesKiezen.IsEnabled = false;
            tbAntwoordA.Visibility = System.Windows.Visibility.Visible;
            cbWelkAntwoordLetter.IsEnabled = false;
            /*cbxA.IsEnabled = false;
            cbxB.IsEnabled = false;
            cbxC.IsEnabled = false;
            cbxD.IsEnabled = false;
            cbxE.IsEnabled = false;
            cbxF.IsEnabled = false;
            cbxG.IsEnabled = false;
            cbxH.IsEnabled = false;
            cbxI.IsEnabled = false;
            cbxJ.IsEnabled = false;*/
        }
        private void FillCBKiesVak()
        {
            DataTable dtVakken = new Dbs_Conn().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { vakId = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            cbKiesVak.ItemsSource = lstVakken;
        }
        private void FillCBLesonderwerpen()
        {   
            DataTable dtLesonderwerpen = new Dbs_Conn().GetLesonderwerpenVW(KiesVakId);
            List<LesOnderwerpen> lstLesOnderwerpen = new List<LesOnderwerpen>();

            foreach (DataRow drLesonderwerpen in dtLesonderwerpen.Rows)
            {
                lstLesOnderwerpen.Add(new LesOnderwerpen() { LesOnderwerpId = drLesonderwerpen[0].ToString(), LesonderwerpNaam = drLesonderwerpen[1].ToString() });
            }
            cbLesonderwerpKiezen.ItemsSource = lstLesOnderwerpen;
            if (lstLesOnderwerpen.Count == 0)
            {
                cbLesonderwerpKiezen.IsEnabled = false;
                MessageBox.Show("Bij het gekozen vak bestaan nog geen lesonderwerpen, voeg lesonderwerpen toe in het menu 'lesonderwerpen wijzigen', of kies een ander vak.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cbLesonderwerpKiezen.IsEnabled = true;
            }
        }

        private void FillCBLessen()
        {
            DataTable dtLessen = new Dbs_Conn().GetLessenVW(KiesLesonderwerpId);
            List<Lessen> lstLessen = new List<Lessen>();

            foreach (DataRow drLessen in dtLessen.Rows)
            {
                lstLessen.Add(new Lessen() { LesId = drLessen[0].ToString(), LesNaam = drLessen[2].ToString() });
            }
            cbLesKiezen.ItemsSource = lstLessen;
            if (lstLessen.Count == 0)
            {
                cbLesKiezen.IsEnabled = false;
                MessageBox.Show("Bij het gekozen lesonderwerp bestaan nog geen lessen, voeg lessen toe in het menu 'lessen wijzigen', of kies een ander lesonderwerp.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cbLesKiezen.IsEnabled = true;
            }
        }

        private void FillLVVragen()
        {
            DataTable dtVragen = new Dbs_Conn().GetVragenVW(KiesLesId);
            List<Vragen> lstVragen = new List<Vragen>();

            foreach (DataRow drVragen in dtVragen.Rows)
            {
                lstVragen.Add(new Vragen() { VraagId = drVragen[0].ToString(), VraagTekst = drVragen[3].ToString(), VraagNaam = drVragen[1].ToString() });
            }
            lvVragen.ItemsSource = lstVragen;
        }

        private void TBInvisibleAntwoorden()
        {
            tbAntwoordA.Visibility = System.Windows.Visibility.Visible;
            tbAntwoordB.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordC.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordD.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordE.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordF.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordG.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordH.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordI.Visibility = System.Windows.Visibility.Hidden;
            tbAntwoordJ.Visibility = System.Windows.Visibility.Hidden;

            if (cbWelkAntwoordLetter.SelectedItem != null)
            {
                int TestInt = cbWelkAntwoordLetter.SelectedIndex;
                string sSelectedAntwoord = cbWelkAntwoordLetter.SelectedItem.ToString();
                string sSelectedAntwoordVariable = "tbAntwoord" + sSelectedAntwoord;
                //string STEST = TestInt.ToString();
                //MessageBox.Show(STEST)
                
                switch (sSelectedAntwoordVariable)
                {
                    case "tbAntwoordA":
                        tbAntwoordA.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case "tbAntwoordB":
                        tbAntwoordB.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordC":
                        tbAntwoordC.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordD":
                        tbAntwoordD.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordE":
                        tbAntwoordE.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordF":
                        tbAntwoordF.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordG":
                        tbAntwoordG.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordH":
                        tbAntwoordH.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordI":
                        tbAntwoordI.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "tbAntwoordJ":
                        tbAntwoordJ.Visibility = System.Windows.Visibility.Visible;
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    default:
                        tbAntwoordA.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordB.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordC.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordD.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordE.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordF.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordG.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordH.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordI.Visibility = System.Windows.Visibility.Hidden;
                        tbAntwoordJ.Visibility = System.Windows.Visibility.Hidden;
                        break;
                }
            }
        }

        private void cbKiesVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesVak.SelectedItem != null)
            {
                KiesVakId = Int32.Parse(((Vakken)(cbKiesVak.SelectedItem)).vakId);
                FillCBLesonderwerpen();
                if (cbLesKiezen.IsEnabled != false)
                {
                    cbLesKiezen.IsEnabled = false;
                    cbLesKiezen.SelectedIndex = -1;
                }
            }  
        }

        private void cbLesonderwerpKiezen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLesonderwerpKiezen.SelectedItem != null)
            {
                KiesLesonderwerpId = Int32.Parse(((LesOnderwerpen)(cbLesonderwerpKiezen.SelectedItem)).LesOnderwerpId);
                FillCBLessen();
            }
        }

        private void cbLesKiezen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLesKiezen.SelectedItem != null)
            {
                KiesLesId = Int32.Parse(((Lessen)(cbLesKiezen.SelectedItem)).LesId);
                FillLVVragen();
                rtbVraag.IsEnabled = true;
            }
        }

        private void btAddVraag_Click(object sender, RoutedEventArgs e)
        {
            string sVraagTekst = new TextRange(rtbVraag.Document.ContentStart, rtbVraag.Document.ContentEnd).Text;
            string sVraagNaam = tbVraagNaam.Text;
            bool CheckrtbVraag = false;
            if (string.IsNullOrWhiteSpace(sVraagTekst) == true)
            {
                CheckrtbVraag = true;
            }
            else
            {
                CheckrtbVraag = false;
            }
            if (CheckrtbVraag == false)
            {
                if (sVraagNaam != "")
                {
                    CheckCheckboxes();
                    new Dbs_Conn().AddVraag(sVraagTekst, sVraagNaam, KiesLesId);
                   
                    FillLVVragen();
                }
                else
                {
                    MessageBox.Show("Het veld waarin de naam van de vraag ingevuld moet worden mag niet leeg zijn!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            else
            {
                MessageBox.Show("Het veld waarin de vraag ingevuld moet worden mag niet leeg zijn!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ConsulentenKeuzeMenu CKM = new ConsulentenKeuzeMenu();
            this.Close();
            CKM.Show();
        }

        private void lvVragen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvVragen.SelectedItem != null)
            {
                int VraagId = int.Parse(((Vragen)(lvVragen.SelectedItem)).VraagId);
            }
        }
        private void UdAantalAntwoorden_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.cbWelkAntwoordLetter.Items.Clear();
            int iAantalAntwoorden = Convert.ToInt32(UdAantalAntwoorden.Value);
            int iCounterAntwoorden = 0;
            while (iCounterAntwoorden != iAantalAntwoorden)
            {
                cbWelkAntwoordLetter.Items.Add(ArrayAntwoorden[iCounterAntwoorden]);
                iCounterAntwoorden++;
            }
            if (iAantalAntwoorden.ToString() != "")
            {
                cbWelkAntwoordLetter.IsEnabled = true;
            }
            else
            {
                cbWelkAntwoordLetter.IsEnabled = false;
            }
        }

        private void cbWelkAntwoordLetter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sSelectedAntwoord = "";
            string sSelectedAntwoordVariable;
            TBInvisibleAntwoorden();
            if (cbWelkAntwoordLetter.SelectedValue != null)
            {
                sSelectedAntwoord = cbWelkAntwoordLetter.SelectedItem.ToString();
                sSelectedAntwoordVariable = "antwoord " + sSelectedAntwoord;
                TBInvisibleAntwoorden();
                lblAntwoord.Content = "Vul hier in wat " + sSelectedAntwoordVariable + " moet zijn:";
                tbAntwoordA.IsEnabled = true;
            }
            
            else
	        {
                lblAntwoord.Content = "Geef hierboven allereerst aan wat welk antwoord u wilt wijzigen.";
                tbAntwoordA.IsEnabled = false;
            } 
        }
    }
}
