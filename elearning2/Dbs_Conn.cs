using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace elearning2
{
    class Dbs_Conn
    {
        string strcnn = "Server=localhost;Database=elearning;uid=root;pwd=;";
        MySqlConnection cnn;

        private void OpenConnection()
        {
            cnn = new MySqlConnection(strcnn);
            try
            {
                cnn.Open();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Er kan op dit moment geen verbinding worden gemaakt met de database. Probeer het later opnieuw.","Foutmelding");
            }
        }

        #region Lesonderwerp

        public void DeleteLesonderwerp(string IdVak)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM lesonderwerp WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", IdVak);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        public void AddLesonderwerp(string NewLesonderwerp, string idVak)
        {
            try
            {
                OpenConnection();
                MySqlConnection cnn = new MySqlConnection(strcnn);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO lesonderwerp(naamlesonderwerp, vakid) VALUES('" + NewLesonderwerp + "', " + idVak + ")", cnn);
                cmd.Parameters.AddWithValue("@lesonderwerp", NewLesonderwerp);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        public DataTable GetLesonderwerpen()
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM lesonderwerp", cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                tbl.Load(rdr);
                cnn.Close();
            }
            catch (Exception)
            {

                return null;
            }
            return tbl;
        }

        public void ChangeLesonderwerp(string IdLesonderwerp, string NaamLesonderwerp)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE lesonderwerp SET naamlesonderwerp = @Naam WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Naam", NaamLesonderwerp);
                cmd.Parameters.AddWithValue("@Id", IdLesonderwerp);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {
            
            }
        }
        #endregion
        #region Login
        public DataTable LoginCheck(string usrname, string pwd)
        {
            DataTable dtLoginCheck = new DataTable();
            OpenConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM inloginfo WHERE usrname = '" + usrname + "' AND pass = '" + pwd + "'", cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                dtLoginCheck.Load(rdr);
                cnn.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return dtLoginCheck;
        }

   
        #endregion
        #region Vak aanpassen
        public DataTable GetVakken()
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vak", cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                tbl.Load(rdr);
                cnn.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return tbl;
        }

        public void DeleteVak(string IdVak)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM vak WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", IdVak);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public void AddVak(string vak)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO vak (naam) VALUES (@vak)", cnn);
                cmd.Parameters.AddWithValue("@vak", vak);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {
             
            }
        }

        public void ChangeVak(string IdVak, string vak)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE vak SET naam = @vaknaam WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@vaknaam", vak);
                cmd.Parameters.AddWithValue("@Id", IdVak);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}