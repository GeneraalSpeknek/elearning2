using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace elearning2
{ //string sVoornaam, string sTussenvoegsel, string sAchternaam, string sTelefoonnummer, string sEmail, string sKamerNummer, string sUserInfoId
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

        #region persoon aanpassen
        public DataTable CheckUserName(string sUserName)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM inloginfo WHERE usrname = '" + sUserName + "'", cnn);
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
        public void DeleteUserInloginfo(string UserId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM inloginfo WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", UserId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteUserUserInfo(string UserId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM userinfo WHERE id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", UserId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        public DataTable GetUserCredentials(string sInlogId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM inloginfo WHERE id = '" + sInlogId + "'", cnn);
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

        public DataTable GetUser()
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM userinfo", cnn);
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

        public void AddUser(string sUsername, string sPass, string sRol)
        {
            try
            {
                OpenConnection();
                MySqlConnection cnn = new MySqlConnection(strcnn);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO inloginfo(usrname, pass, rol)VALUES(@username, @pass, @rol)", cnn);
                cmd.Parameters.AddWithValue("@username", sUsername);
                cmd.Parameters.AddWithValue("@pass", sPass);
                cmd.Parameters.AddWithValue("@rol", sRol);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public DataTable GetUserLoginId(string sUsername)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM inloginfo WHERE usrname = '" + sUsername + "'", cnn);
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

        public void ChangeInlogGegevens(string sUsername, string sPassword, string sRol, string sInlogInfoId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE `inloginfo` SET `usrname`= @username,`pass`= @pass,`rol`= @rol WHERE `id`= @id", cnn);
                cmd.Parameters.AddWithValue("@username", sUsername);
                cmd.Parameters.AddWithValue("@pass", sPassword);
                cmd.Parameters.AddWithValue("@rol", sRol);
                cmd.Parameters.AddWithValue("@id", sInlogInfoId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        /*public void ChangeUserInlogInfo(string sUsername, string sPassword, string sRol, string sInlogInfoId)
        {
            MySqlConnection cnn = new MySqlConnection(strcnn);
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE `inloginfo` SET `usrname`='test1',`pass`='test2',`rol`='test3' WHERE `id`=16", cnn);
                cmd.Parameters.AddWithValue("@username", sUsername);
                cmd.Parameters.AddWithValue("@pass", sPassword);
                cmd.Parameters.AddWithValue("@rol", sRol);
                cmd.Parameters.AddWithValue("@id", sInlogInfoId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }*/

        public void ChangeUserUserinfo(string sVoornaam, string sTussenvoegsel, string sAchternaam, string sTelefoonnummer, string sEmail, string sKamerNummer, string sUserInfoId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE userinfo SET voornaam=@voornaam,tussenvoegsel=@tussenvoegsel,achternaam=@achternaam,kamernummer=@kamernummer,telefoonnummer=@telefoonnummer,email=@email WHERE id = @id", cnn);
                cmd.Parameters.AddWithValue("@voornaam", sVoornaam);
                cmd.Parameters.AddWithValue("@tussenvoegsel", sTussenvoegsel);
                cmd.Parameters.AddWithValue("@achternaam", sAchternaam);
                cmd.Parameters.AddWithValue("@telefoonnummer", sTelefoonnummer);
                cmd.Parameters.AddWithValue("@email", sEmail);
                cmd.Parameters.AddWithValue("@kamernummer", sKamerNummer);
                cmd.Parameters.AddWithValue("@id", sUserInfoId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public void AddPerson(string sVoornaam, string sTussenvoegsel, string sAchternaam, string sTelefoonnummer, string sEmail, string sKamerNummer, string sUserInlogId)
        {
            try
            {
                OpenConnection();
                MySqlConnection cnn = new MySqlConnection(strcnn);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO userinfo(voornaam, tussenvoegsel, achternaam, telefoonnummer, email, kamernummer, inloginfoid) VALUES(@voornaam, @tussenvoegsel, @achternaam, @telefoonnummer, @email, @kamernummer, @userinlogid)", cnn);
                cmd.Parameters.AddWithValue("@voornaam", sVoornaam);
                cmd.Parameters.AddWithValue("@tussenvoegsel", sTussenvoegsel);
                cmd.Parameters.AddWithValue("@achternaam", sAchternaam);
                cmd.Parameters.AddWithValue("@telefoonnummer", sTelefoonnummer);
                cmd.Parameters.AddWithValue("@email", sEmail);
                cmd.Parameters.AddWithValue("@kamernummer", sKamerNummer);
                cmd.Parameters.AddWithValue("@userinlogid", sUserInlogId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        #endregion

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
                MySqlCommand cmd = new MySqlCommand("UPDATE vak SET naam = @vaknaam WHERE id = @id", cnn);
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