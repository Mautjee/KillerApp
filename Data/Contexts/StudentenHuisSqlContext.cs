using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using KillerApp.Data.Interfaces;
using KillerApp.Data.SQL;
using KillerApp.Model;
using Model;
using static Model.Gebruiker;

namespace KillerApp.Data.Contexts
{
    public class StudentenHuisSqlContext : IStudentenhuisContext
    {
        private SqlCon sqlcon = new SqlCon();
        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            List<Bewonersaldo> ret = new List<Bewonersaldo>();

            

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select GebruikerID, Voornaam, Saldo from vwActiveStudentenhuisGebruikers WHERE studenthuisid = 1";

                        cmd.CommandText = query;
                        cmd.Connection = conn;

                        cmd.Parameters.AddWithValue("@studentenhuisid", studentenhuisId);

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    ret.Add(new Bewonersaldo()
                                    {
                                        GebruikerID = (int)sdr["GebruikerID"],
                                        Saldo = (int)sdr["Saldo"],
                                        Voornaam = (string)sdr["Voornaam"]
                                    });
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                //OOPS
            }

            return ret;
        }

        public StudentenHuis GetAllBewoners(int studenthuisId)
        {
            StudentenHuis huis = new StudentenHuis();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select * FROM Table_Gebruiker Where StudentenhuisID = {studenthuisId}";

                        cmd.CommandText = query;


                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    huis.VoegBewonerToe(new Gebruiker(
                                       sdr["Gebruikersnaam"].ToString(),
                                        sdr["Voornaam"].ToString(),
                                         sdr["Achternaam"].ToString(),
                                        Convert.ToDateTime(sdr["Geboortedatum"]),
                                        sdr["MobielNummer"].ToString(),
                                        (Geslacht)Convert.ToInt32(sdr["Geslacht"]),
                                       sdr["MailAdress"].ToString(),
                                       Convert.ToInt32(sdr["GebruikerID"]),
                                       Convert.ToInt32(sdr["StudentenhuisID"])));

                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // write to log
                Console.WriteLine(ex.Message);
            }

            return huis;
           
        }

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            List<StudentenHuis> sh = new List<StudentenHuis>();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select * FROM Table_Studentenhuis";

                        cmd.CommandText = query;


                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    sh.Add(new StudentenHuis());
                                }
                            }

                        }
                    }
                }
            }
            catch(Exception EX)
            {
                Console.Write(EX.Message);
            }
            return sh;
        }

        public StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebruikerid)
        {
            StudentenHuis sthu = new StudentenHuis();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = "Select top 1 StudenthuisID, NaamHuis from vwActiveStudentenhuisGebruikers WHERE GebruikerID = @gebruikerID";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@gebruikerID", gebruikerid);

                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {

                                sdr.Read();

                                sthu.StudentenhuisID = (int)sdr["StudenthuisID"];
                                sthu.Naam = (string)sdr["NaamHuis"]; 
                            }

                        }
                        return sthu;
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message);
            }

            return new StudentenHuis();
        }

        public bool verwijderBewoner(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public bool voegBewonertoe(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }
    }
}
