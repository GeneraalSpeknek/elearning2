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
    }
}