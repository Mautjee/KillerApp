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
    public class StudentenHuisSqlContext : SqlCon , IStudentenhuisContext
    {
        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            List<Bewonersaldo> ret = new List<Bewonersaldo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select Voornaam, Saldo from vwActiveStudentenhuisGebruikers WHERE studenthuisid = @studentenhuisid";

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
                using (SqlConnection conn = new SqlConnection(connectionstring()))
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
                using (SqlConnection conn = new SqlConnection(connectionstring()))
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

        public int GetActiveStudentenhuisBijGebruiker(int id)
        {        
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = "Select top 1 StudenthuisID from vwActiveStudentenhuisGebruikers WHERE GebruikerID = @gebruikerID";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@gebruikerID", id);

                        cmd.Connection = conn;

                        conn.Open();

                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message);
            }

            return 0;
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
