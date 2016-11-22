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
    /// Interaction logic for VakWijzigen.xaml
    /// </summary>
    public partial class VakWijzigen : Window
    {
        string IdVak = "";
        struct Vakken
        {
            public string Id { get; set; }
            public string VakNaam { get; set; }
        }

        //public string WhichButtons { get; set; }
        public VakWijzigen()
        {
            InitializeComponent();
            PopulateLB();
        }

        private void PopulateLB()
        {
            lbVakken.Items.Clear();
            DataTable dtVakken = new Dbs_Conn().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { Id = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            lbVakken.ItemsSource = lstVakken;
        }
    }
}
