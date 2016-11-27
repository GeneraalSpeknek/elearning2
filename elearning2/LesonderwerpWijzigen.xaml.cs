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
                SelectedVakNaam = ((Vakken)(cbWelkVak.SelectedItem)).VakNaam;
            }
        }

        private void btAddLesonderwerp_Click(object sender, RoutedEventArgs e)
        {
            if (cbWelkVak.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een vak waaraan het nieuwe lesonderwerp moet worden toegevoegd.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tbLesonderwerp.Text == "")
            {
                MessageBox.Show("Voer een naam in voor het nieuwe lesonderwerp!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                new Dbs_Conn().AddLesonderwerp(tbLesonderwerp.Text, IdVak);
                FillLBLesonderwerpen();
            }
        }

        private void lbLesonderwerp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLesonderwerp.SelectedItem != null)
            {
                IdLesonderwerp = ((Lesonderwerpen)(lbLesonderwerp.SelectedItem)).LesonderwerpId;
                tbLesonderwerp.Text = ((Lesonderwerpen)(lbLesonderwerp.SelectedItem)).LesonderwerpNaam;
                SelectedLesonderwerpNaam = ((Lesonderwerpen)(lbLesonderwerp.SelectedItem)).LesonderwerpNaam;
            }
        }

        private void btChangeLesonderwerp_Click(object sender, RoutedEventArgs e)
        {
            if (tbLesonderwerp.Text == "")
            {
                MessageBox.Show("Voer in hoe je het lesonderwerp wilt noemen. Dit veld mag niet leeg zijn!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je het lesonderwerp '" + SelectedLesonderwerpNaam + "' wilt wijzigen naar '" + tbLesonderwerp.Text + "'?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if(DeleteYesNo == MessageBoxResult.Yes)
                {
                    new Dbs_Conn().ChangeLesonderwerp(IdLesonderwerp, tbLesonderwerp.Text);
                    tbLesonderwerp.Text = "";
                }
            }
            FillLBLesonderwerpen();
        }

        private void btDeleteLesonderwerp_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je het lesonderwerp '" + SelectedLesonderwerpNaam + " wil verwijderen?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (DeleteYesNo == MessageBoxResult.Yes)
            {
                new Dbs_Conn().DeleteLesonderwerp(IdLesonderwerp);
                tbLesonderwerp.Text = "";
                FillLBLesonderwerpen();
            }
        }
    }
}
