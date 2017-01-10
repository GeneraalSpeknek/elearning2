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
        int VraagId;
        int VraagIdVulTekst;
        bool bAllAnswersFilled;

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

        struct Antwoorden
        {
            public int AntwoordId { get; set; }
            public int GoedAntwoordA { get; set; }
            public int GoedAntwoordB { get; set; }
            public int GoedAntwoordC { get; set; }
            public int GoedAntwoordD { get; set; }
            public int GoedAntwoordE { get; set; }
            public int GoedAntwoordF { get; set; }
            public int GoedAntwoordG { get; set; }
            public int GoedAntwoordH { get; set; }
            public int GoedAntwoordI { get; set; }
            public int GoedAntwoordJ { get; set; }
            public int AantalAntwoorden { get; set; }
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
            DisableCheckBoxes();
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
        private void VulTekstWhenLVSelectionChanged()
        {
            tbVraagNaam.Text = ((Vragen)(lvVragen.SelectedItem)).VraagNaam;
            rtbVraag.Document.Blocks.Clear();
            rtbVraag.AppendText(((Vragen)(lvVragen.SelectedItem)).VraagTekst);

            #region Vul lstantwoorden
            VraagIdVulTekst = Convert.ToInt32(((Vragen)(lvVragen.SelectedItem)).VraagId);
            DataTable dtAntwoorden = new Dbs_Conn().GetAntwoorden(VraagIdVulTekst);

            int AntwoordA = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoorda"]);
            int AntwoordB = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordb"]);
            int AntwoordC = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordc"]);
            int AntwoordD = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordd"]);
            int AntwoordE = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoorde"]);
            int AntwoordF = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordf"]);
            int AntwoordG = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordg"]);
            int AntwoordH = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordh"]);
            int AntwoordI = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordi"]);
            int AntwoordJ = Convert.ToInt32(dtAntwoorden.Rows[0]["goedantwoordj"]);
            int AantalAntwoorden = Convert.ToInt32(dtAntwoorden.Rows[0]["aantalantwoorden"]);

            UdAantalAntwoorden.Value = AantalAntwoorden;
            ResetCheckboxSettings();
            #endregion
            #region checkboxvuller
            if (AntwoordA == 1)
            {
                cbxA.IsChecked = true;
            }
            if (AntwoordB == 1)
            {
                cbxB.IsChecked = true;
            }
            if (AntwoordC == 1)
            {
                cbxC.IsChecked = true;
            }
            if (AntwoordD == 1)
            {
                cbxD.IsChecked = true;
            }
            if (AntwoordE == 1)
            {
                cbxE.IsChecked = true;
            }
            if (AntwoordF == 1)
            {
                cbxF.IsChecked = true;
            }
            if (AntwoordG == 1)
            {
                cbxG.IsChecked = true;
            }
            if (AntwoordH == 1)
            {
                cbxH.IsChecked = true;
            }
            if (AntwoordI == 1)
            {
                cbxI.IsChecked = true;
            }
            if (AntwoordJ == 1)
            {
                cbxJ.IsChecked = true;
            }
            #endregion
            #region Set tekst voor antwoordvelden
            DataTable dtAntwoordTeksten = new Dbs_Conn().GetAntwoordTekst(VraagIdVulTekst);
            string AntwoordTekstA = dtAntwoordTeksten.Rows[0]["antwoorda"].ToString();
            string AntwoordTekstB = dtAntwoordTeksten.Rows[0]["antwoordb"].ToString();
            string AntwoordTekstC = dtAntwoordTeksten.Rows[0]["antwoordc"].ToString();
            string AntwoordTekstD = dtAntwoordTeksten.Rows[0]["antwoordd"].ToString();
            string AntwoordTekstE = dtAntwoordTeksten.Rows[0]["antwoorde"].ToString();
            string AntwoordTekstF = dtAntwoordTeksten.Rows[0]["antwoordf"].ToString();
            string AntwoordTekstG = dtAntwoordTeksten.Rows[0]["antwoordg"].ToString();
            string AntwoordTekstH = dtAntwoordTeksten.Rows[0]["antwoordh"].ToString();
            string AntwoordTekstI = dtAntwoordTeksten.Rows[0]["antwoordi"].ToString();
            string AntwoordTekstJ = dtAntwoordTeksten.Rows[0]["antwoordj"].ToString();

            tbAntwoordA.Text = AntwoordTekstA;
            tbAntwoordB.Text = AntwoordTekstB;
            tbAntwoordC.Text = AntwoordTekstC;
            tbAntwoordD.Text = AntwoordTekstD;
            tbAntwoordE.Text = AntwoordTekstE;
            tbAntwoordF.Text = AntwoordTekstF;
            tbAntwoordG.Text = AntwoordTekstG;
            tbAntwoordH.Text = AntwoordTekstH;
            tbAntwoordI.Text = AntwoordTekstI;
            tbAntwoordJ.Text = AntwoordTekstJ;
            #endregion
        }

        private void AllAnswersFilled()
        {
            bAllAnswersFilled = false;

            string sAantalantwoorden = UdAantalAntwoorden.Value.ToString();
            int iAantalantwoorden = Convert.ToInt32(sAantalantwoorden);
            #region antwoordvalidatieswitch
            switch (iAantalantwoorden)
            {
                case 2:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 3:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 4:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 5:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 6:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "" && tbAntwoordF.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 7:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "" && tbAntwoordF.Text != "" && tbAntwoordG.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 8:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "" && tbAntwoordF.Text != "" && tbAntwoordG.Text != "" && tbAntwoordH.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 9:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "" && tbAntwoordF.Text != "" && tbAntwoordG.Text != "" && tbAntwoordH.Text != "" && tbAntwoordI.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                case 10:
                    if (tbAntwoordA.Text != "" && tbAntwoordB.Text != "" && tbAntwoordC.Text != "" && tbAntwoordD.Text != "" && tbAntwoordE.Text != "" && tbAntwoordF.Text != "" && tbAntwoordG.Text != "" && tbAntwoordH.Text != "" && tbAntwoordI.Text != "" && tbAntwoordJ.Text != "")
                    {
                        bAllAnswersFilled = true;
                    }
                    break;
                default:
                    break;
            }
            #endregion
        }

        private void DisableCheckBoxes()
        {
            cbxA.IsEnabled = false;
            cbxB.IsEnabled = false;
            cbxC.IsEnabled = false;
            cbxD.IsEnabled = false;
            cbxE.IsEnabled = false;
            cbxF.IsEnabled = false;
            cbxG.IsEnabled = false;
            cbxH.IsEnabled = false;
            cbxI.IsEnabled = false;
            cbxJ.IsEnabled = false;

            cbxA.IsChecked = false;
            cbxB.IsChecked = false;
            cbxC.IsChecked = false;
            cbxD.IsChecked = false;
            cbxE.IsChecked = false;
            cbxF.IsChecked = false;
            cbxG.IsChecked = false;
            cbxH.IsChecked = false;
            cbxI.IsChecked = false;
            cbxJ.IsChecked = false;
        }
        private void ResetCheckboxSettings()
        {
            int iAantalAntwoorden = Convert.ToInt32(UdAantalAntwoorden.Value);
            switch (iAantalAntwoorden)
            {
                case 2:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    break;
                case 3:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    break;
                case 4:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    break;
                case 5:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    break;
                case 6:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    cbxF.IsEnabled = true;
                    break;
                case 7:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    cbxF.IsEnabled = true;
                    cbxG.IsEnabled = true;
                    break;
                case 8:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    cbxF.IsEnabled = true;
                    cbxG.IsEnabled = true;
                    cbxH.IsEnabled = true;
                    break;
                case 9:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    cbxF.IsEnabled = true;
                    cbxG.IsEnabled = true;
                    cbxH.IsEnabled = true;
                    cbxI.IsEnabled = true;
                    break;
                case 10:
                    cbxA.IsEnabled = true;
                    cbxB.IsEnabled = true;
                    cbxC.IsEnabled = true;
                    cbxD.IsEnabled = true;
                    cbxE.IsEnabled = true;
                    cbxF.IsEnabled = true;
                    cbxG.IsEnabled = true;
                    cbxH.IsEnabled = true;
                    cbxI.IsEnabled = true;
                    cbxJ.IsEnabled = true;
                    break;
                default:
                    break;
            }
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
                    DataTable dtCheckVraagnaam = new Dbs_Conn().CheckVraagNaam(sVraagNaam);
                    if (dtCheckVraagnaam != null)
                    {
                        if (dtCheckVraagnaam.Rows.Count == 0)
                        {
                            if (UdAantalAntwoorden.Value != null)
                            {
                                string sAantalantwoorden = UdAantalAntwoorden.Value.ToString();
                                int iAantalantwoorden = Convert.ToInt32(sAantalantwoorden);
                                AllAnswersFilled();
                                if (bAllAnswersFilled == true)
                                {
                                    CheckCheckboxes();
                                    new Dbs_Conn().AddVraag(sVraagTekst, sVraagNaam, KiesLesId);
                                    FillLVVragen();
                                    int iAantalantwoordenChecked = bCheckboxA + bCheckboxB + bCheckboxC + bCheckboxD + bCheckboxE + bCheckboxF + bCheckboxG + bCheckboxH + bCheckboxI + bCheckboxJ;
                                    if (iAantalantwoordenChecked != 0)
                                    {
                                        DataTable dtVragenId = new Dbs_Conn().GetVragenId(sVraagNaam);
                                        int iVragenId = Convert.ToInt32(dtVragenId.Rows[0]["id"]);
                                        new Dbs_Conn().AddVraagAntwoorden(iVragenId, bCheckboxA, bCheckboxB, bCheckboxC, bCheckboxD, bCheckboxE, bCheckboxF, bCheckboxG, bCheckboxH, bCheckboxI, bCheckboxJ, iAantalantwoorden);
                                        new Dbs_Conn().AddAntwoordTeksten(iVragenId, tbAntwoordA.Text, tbAntwoordB.Text, tbAntwoordC.Text, tbAntwoordD.Text, tbAntwoordE.Text, tbAntwoordF.Text, tbAntwoordG.Text, tbAntwoordH.Text, tbAntwoordI.Text, tbAntwoordJ.Text);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Je moet minstens één antwoord als goed aanvinken.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Niet alle antwoordvelden zijn ingevuld, vul deze in en probeer het opnieuw.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Deze naam voor de vraag bestaat al. Kies een andere, unieke, naam.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //HIER VERDER WERKEN AAN CHECKEN VAN VRAAGNAAM, MOET UNIEKE WAARDE ZIJN OM ID TE KRIJGEN VOOR ANDERE TABEL
                    
                    else
                    {
                        MessageBox.Show("Het veld waarin het aantal antwoorden moet worden aangegeven mag niet leeg zijn!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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

            //MessageBox.Show(KiesLesId.ToString());
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ConsulentenKeuzeMenu CKM = new ConsulentenKeuzeMenu();
            this.Close();
            CKM.Show();
        }

        private void lvVragen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisableCheckBoxes();
            if (lvVragen.SelectedItem != null)
            {
                VraagId = int.Parse(((Vragen)(lvVragen.SelectedItem)).VraagId);
                VulTekstWhenLVSelectionChanged();
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
            DisableCheckBoxes();
            ResetCheckboxSettings();
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

        private void btVerwijderVraag_Click(object sender, RoutedEventArgs e)
        {
            string sVraagNaam = ((Vragen)(lvVragen.SelectedItem)).VraagNaam;
            MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je de vraag '"+ sVraagNaam +"' wilt verwijderen?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);

            if (DeleteYesNo == MessageBoxResult.Yes)
            {
                new Dbs_Conn().DeleteVraagDBS(VraagId);
                FillLVVragen();
            }
        }

        private void btModifyVraag_Click(object sender, RoutedEventArgs e)
        {
            string sVraagTekst = new TextRange(rtbVraag.Document.ContentStart, rtbVraag.Document.ContentEnd).Text;
            string VraagNaam = tbVraagNaam.Text;
            int AantalAntwoorden = Convert.ToInt32(UdAantalAntwoorden.Value);
            DataTable dtCheckVraagNaam = new Dbs_Conn().CheckVraagNaam(VraagNaam);
            if (dtCheckVraagNaam.Rows.Count == 0 || Convert.ToInt32(dtCheckVraagNaam.Rows[0]["id"]) == VraagIdVulTekst)
            {
                new Dbs_Conn().ModifyVragen(sVraagTekst, VraagNaam, VraagIdVulTekst);
                FillLVVragen();
            }
            else
            {
                MessageBox.Show("Deze naam is al in gebruik. Kies een andere, unieke, naam.");
            }
        }
    }
}
