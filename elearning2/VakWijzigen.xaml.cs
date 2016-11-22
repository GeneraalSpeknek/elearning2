﻿using System;
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
        int iPopulateLB = 0;
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
            if (iPopulateLB <1)
            {
                lbVakken.Items.Clear();
                iPopulateLB++;
            }
            
            DataTable dtVakken = new Dbs_Conn().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { Id = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            lbVakken.ItemsSource = lstVakken;
        }

        private void btDeleteVak_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je het vak '" + tbVak.Text + "' wilt verwijderen?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (DeleteYesNo == MessageBoxResult.Yes)
            {
                new Dbs_Conn().DeleteVak(IdVak);
                IdVak = ((Vakken)(lbVakken.SelectedItem)).Id;
                PopulateLB();
                tbVak.Text = "";
            }
            else if (DeleteYesNo == MessageBoxResult.No)
            {
                //do something else
            }
        }

        private void lbVakken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbVakken.SelectedItem != null)
            {
                IdVak = ((Vakken)(lbVakken.SelectedItem)).Id;
                tbVak.Text = ((Vakken)(lbVakken.SelectedItem)).VakNaam;
            }
        }
    }
}
