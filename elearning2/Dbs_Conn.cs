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

        #region Lesonderwerp
        public void AddLesonderwerp(string NewLesonderwerp, string idVak)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO lesonderwerp(naamlesonderwerp, vakid) VALUES('"+ NewLesonderwerp +"', "+ idVak +")", cnn);
            cmd.Parameters.AddWithValue("@lesonderwerp", NewLesonderwerp);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetLesonderwerpen()
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM lesonderwerp", cnn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(rdr);
            cnn.Close();
            return tbl;
        }
        #endregion
        #region Login
        public DataTable LoginCheck(string usrname, string pwd)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM inloginfo WHERE usrname = '"+usrname+"' AND pass = '"+pwd+"'", cnn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dtLoginCheck = new DataTable();
            dtLoginCheck.Load(rdr);
            cnn.Close();
            return dtLoginCheck;
        }

        public DataTable RolChecker(string usrname)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT rol FROM inloginfo WHERE usrname = '" + usrname + "'", cnn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dtRolChecker = new DataTable();
            dtRolChecker.Load(rdr);
            cnn.Close();
            return dtRolChecker;
        }
        #endregion
        #region Vak aanpassen
        public DataTable GetVakken()
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM vak", cnn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(rdr);
            cnn.Close();
            return tbl;
        }

        public void DeleteVak(string IdVak)
        {
            //archive voor deleted items maken
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM vak WHERE id = @Id", cnn);
            cmd.Parameters.AddWithValue("@Id", IdVak);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void AddVak(string vak)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO vak (naam) VALUES (@vak)", cnn);
            cmd.Parameters.AddWithValue("@vak", vak);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void ChangeVak(string IdVak, string vak)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE vak SET naam = @vaknaam WHERE id = @Id", cnn);
            cmd.Parameters.AddWithValue("@vaknaam", vak);
            cmd.Parameters.AddWithValue("@Id", IdVak);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        #endregion
    }
}