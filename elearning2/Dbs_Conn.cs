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

        #region VragenWijzigen

        public void AddVraag(string sVraag, string sNaam, int LesId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO vragen (naam,lesid,vraag) VALUES (@naam,@lesid,@vraag)", cnn);
                cmd.Parameters.AddWithValue("@vraag", sVraag);
                cmd.Parameters.AddWithValue("@naam", sNaam);
                cmd.Parameters.AddWithValue("@lesid", LesId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        public void ModifyVragen(string sVraagTekst, string sVraagNaam, int VraagId)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE `vragen` SET `naam`= @vraagnaam,`vraag`= @vraagtekst WHERE `id`= @id", cnn);
                cmd.Parameters.AddWithValue("@vraagnaam", sVraagNaam);
                cmd.Parameters.AddWithValue("@vraagtekst", sVraagTekst);
                cmd.Parameters.AddWithValue("@id", VraagId);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }
        public void AddAntwoordTeksten(int ivraagid, string sAntwoorda, string sAntwoordb, string sAntwoordc, string sAntwoordd, string sAntwoorde, string sAntwoordf, string sAntwoordg, string sAntwoordh, string sAntwoordi, string sAntwoordj)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO antwoordentekst (vraagid,antwoorda,antwoordb,antwoordc,antwoordd,antwoorde,antwoordf,antwoordg,antwoordh,antwoordi,antwoordj) VALUES (@vraagid,@antwoorda,@antwoordb,@antwoordc,@antwoordd,@antwoorde,@antwoordf,@antwoordg,@antwoordh,@antwoordi,@antwoordj)", cnn);
                cmd.Parameters.AddWithValue("@vraagid", ivraagid);
                cmd.Parameters.AddWithValue("@antwoorda", sAntwoorda);
                cmd.Parameters.AddWithValue("@antwoordb", sAntwoordb);
                cmd.Parameters.AddWithValue("@antwoordc", sAntwoordc);
                cmd.Parameters.AddWithValue("@antwoordd", sAntwoordd);
                cmd.Parameters.AddWithValue("@antwoorde", sAntwoorde);
                cmd.Parameters.AddWithValue("@antwoordf", sAntwoordf);
                cmd.Parameters.AddWithValue("@antwoordg", sAntwoordg);
                cmd.Parameters.AddWithValue("@antwoordh", sAntwoordh);
                cmd.Parameters.AddWithValue("@antwoordi", sAntwoordi);
                cmd.Parameters.AddWithValue("@antwoordj", sAntwoordj);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public DataTable CheckVraagNaam(string sVraagNaam)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vragen WHERE naam = '" + sVraagNaam + "'", cnn);
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
        public DataTable GetVragenId(string sVraagNaam)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vragen WHERE naam = '" + sVraagNaam + "'", cnn);
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
        public void AddVraagAntwoorden(int iVraagId, int bCheckboxA, int bCheckboxB, int bCheckboxC, int bCheckboxD, int bCheckboxE, int bCheckboxF, int bCheckboxG, int bCheckboxH, int bCheckboxI, int bCheckboxJ, int iAantalAntwoorden)
        {
            try
            {
                OpenConnection();
                MySqlConnection cnn = new MySqlConnection(strcnn);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO antwoorden(vraagid, goedantwoorda, goedantwoordb, goedantwoordc, goedantwoordd, goedantwoorde, goedantwoordf, goedantwoordg, goedantwoordh, goedantwoordi, goedantwoordj, aantalantwoorden)VALUES(@vraagid, @Checkboxa, @Checkboxb, @Checkboxc, @Checkboxd, @Checkboxe, @Checkboxf, @Checkboxg, @Checkboxh, @Checkboxi, @Checkboxj, @aantalantwoorden)", cnn);
                cmd.Parameters.AddWithValue("@vraagid", iVraagId);
                cmd.Parameters.AddWithValue("@Checkboxa", bCheckboxA);
                cmd.Parameters.AddWithValue("@Checkboxb", bCheckboxB);
                cmd.Parameters.AddWithValue("@Checkboxc", bCheckboxC);
                cmd.Parameters.AddWithValue("@Checkboxd", bCheckboxD);
                cmd.Parameters.AddWithValue("@Checkboxe", bCheckboxE);
                cmd.Parameters.AddWithValue("@Checkboxf", bCheckboxF);
                cmd.Parameters.AddWithValue("@Checkboxg", bCheckboxG);
                cmd.Parameters.AddWithValue("@Checkboxh", bCheckboxH);
                cmd.Parameters.AddWithValue("@Checkboxi", bCheckboxI);
                cmd.Parameters.AddWithValue("@Checkboxj", bCheckboxJ);
                cmd.Parameters.AddWithValue("@aantalantwoorden", iAantalAntwoorden);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception)
            {

            }
        }

        public DataTable GetVragenVW(int LesId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vragen WHERE lesid = @id", cnn);
                cmd.Parameters.AddWithValue("@Id", LesId);
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
        public DataTable GetAntwoorden(int VraagId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM antwoorden WHERE vraagid = @id", cnn);
                cmd.Parameters.AddWithValue("@Id", VraagId);
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

        public DataTable GetAntwoordTekst(int VraagId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM antwoordentekst WHERE vraagid = @id", cnn);
                cmd.Parameters.AddWithValue("@Id", VraagId);
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

        public void DeleteVraag(int VraagId)
        {
            DeleteVraagDBS(VraagId);

        }
        public void DeleteVraagDBS(int VraagId)
        {
        try
        {
            OpenConnection();
            MySqlCommand cmdDeleteVraag = new MySqlCommand("DELETE FROM vragen WHERE id = @Id", cnn);
            cmdDeleteVraag.Parameters.AddWithValue("@Id", VraagId);
            cmdDeleteVraag.ExecuteNonQuery();
            MySqlCommand cmdDeleteAntwoorden = new MySqlCommand("DELETE FROM antwoorden WHERE vraagid = @Id", cnn);
            cmdDeleteAntwoorden.Parameters.AddWithValue("@Id", VraagId);
            cmdDeleteAntwoorden.ExecuteNonQuery();
            MySqlCommand cmdDeleteAntwoordTeksten = new MySqlCommand("DELETE FROM antwoordentekst WHERE vraagid = @Id", cnn);
            cmdDeleteAntwoordTeksten.Parameters.AddWithValue("@Id", VraagId);
            cmdDeleteAntwoordTeksten.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception)
        {

        }
    }
        

        public DataTable GetLessenVW(int LesonderwerpId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM les WHERE lesonderwerpid = @id", cnn);
                cmd.Parameters.AddWithValue("@Id", LesonderwerpId);
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

        public DataTable GetLesonderwerpenVW(int VakId)
        {
            DataTable tbl = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM lesonderwerp WHERE vakid = @id", cnn);
                cmd.Parameters.AddWithValue("@Id", VakId);
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

        #endregion

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
                MySqlCommand cmd = new MySqlCommand("UPDATE lesonderwerp SET naamlesonderwerp=@Naam WHERE id=@Id", cnn);
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