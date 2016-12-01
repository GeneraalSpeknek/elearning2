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
        }

        private void FillCBLessen()
        {
            DataTable dtLessen = new Dbs_Conn().GetLessenVW(KiesLesonderwerpId);
            List<Lessen> lstLessen = new List<Lessen>();

            foreach (DataRow drLessen in dtLessen.Rows)
            {
                lstLessen.Add(new Lessen() { LesId = drLessen[0].ToString(), LesNaam = drLessen[1].ToString() });
            }
            cbLesKiezen.ItemsSource = lstLessen;
        }

        private void cbKiesVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesVak.SelectedItem != null)
            {
                KiesVakId = Int32.Parse(((Vakken)(cbKiesVak.SelectedItem)).vakId);
                FillCBLesonderwerpen();
                cbLesonderwerpKiezen.IsEnabled = true;
            }  
        }

        private void cbLesonderwerpKiezen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLesonderwerpKiezen.SelectedItem != null)
            {
                KiesLesonderwerpId = Int32.Parse(((LesOnderwerpen)(cbLesonderwerpKiezen.SelectedItem)).LesOnderwerpId);
                FillCBLesonderwerpen();
                cbLesKiezen.IsEnabled = true;
            }
        }
    }
}
