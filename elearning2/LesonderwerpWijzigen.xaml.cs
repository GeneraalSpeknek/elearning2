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
    /// Interaction logic for LesonderwerpWijzigen.xaml
    /// </summary>
    public partial class LesonderwerpWijzigen : Window
    {
        string IdVak = "";
        string SelectedVakNaam = "";

        string IdLesonderwerp = "";
        string SelectedLesonderwerpNaam = "";
        struct Vakken
        {
            public string vakId { get; set; }
            public string VakNaam { get; set; }
        }

        struct Lesonderwerpen
        {
            public string LesonderwerpId { get; set; }
            public string LesonderwerpNaam { get; set; }
        }
        public LesonderwerpWijzigen()
        {
            InitializeComponent();
            FillComboBoxVakken();
            FillLBLesonderwerpen();

        }

        private void FillLBLesonderwerpen()
        {
            DataTable dtLesonderwerpen = new Dbs_Conn().GetLesonderwerpen();
            List<Lesonderwerpen> lstVakken = new List<Lesonderwerpen>();

            foreach (DataRow drLesonderwerpen in dtLesonderwerpen.Rows)
            {
                lstVakken.Add(new Lesonderwerpen() { LesonderwerpId = drLesonderwerpen[0].ToString(), LesonderwerpNaam = drLesonderwerpen[1].ToString() });
            }
            lbLesonderwerp.ItemsSource = lstVakken;

        }
        private void FillComboBoxVakken()
        {
            DataTable dtVakken = new Dbs_Conn().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { vakId = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            cbWelkVak.ItemsSource = lstVakken;
        }

        private void cbWelkVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbWelkVak.SelectedItem != null)
            {
                IdVak = ((Vakken)(cbWelkVak.SelectedItem)).vakId;
                tbLesonderwerp.Text = ((Vakken)(cbWelkVak.SelectedItem)).VakNaam;
                SelectedVakNaam = ((Vakken)(cbWelkVak.SelectedItem)).VakNaam;
            }
            //MessageBox.Show("..." + IdVak + "..."+ SelectedVakNaam +"...");
        }
    }
}
