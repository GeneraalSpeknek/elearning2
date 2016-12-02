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
        }

        struct Lessen
        {
            public string LesId { get; set; }
            public string LesNaam { get; set; }
        }
        public VragenWijzigen()
        {
            InitializeComponent();
            FillCBKiesVak();
            cbLesonderwerpKiezen.IsEnabled = false;
            cbLesKiezen.IsEnabled = false;
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

        private void FillLBVragen()
        {
            DataTable dtVragen = new Dbs_Conn().GetVragenVW(KiesLesId);
            List<Vragen> lstVragen = new List<Vragen>();

            foreach (DataRow drVragen in dtVragen.Rows)
            {
                lstVragen.Add(new Vragen() { VraagId = drVragen[0].ToString(), VraagTekst = drVragen[1].ToString() });
            }
            lbVragen.ItemsSource = lstVragen;
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
                FillLBVragen();
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
                    new Dbs_Conn().AddVraag(sVraagTekst, sVraagNaam, KiesLesId);
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
    }
}
