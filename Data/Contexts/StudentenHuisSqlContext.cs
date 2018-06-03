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

        public BewonerInfo GetStudentenHuisGebruiker(int id)
        {
            string query = $"Select s.NaamHuis From [Table_Studentenhuis] s, [Table_Gebruiker_Activiteit] ga " +
                            $"WHERE s.StudentenhuisID = ga.StudenthuisID " +
                            $"AND s.StudentenhuisID = {id} And ga.[Out] is NULL;";
            throw new NotImplementedException();
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
