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
                        string query = $"Select GebruikerID, Voornaam, Saldo from vwActiveStudentenhuisGebruikers WHERE studenthuisid = @studentenhuisid";

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
                        string query = $"Select * FROM Table_Gebruiker Where StudentenhuisID = @studentenhuisID";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@studentenhuisID", studenthuisId);

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
                                       sdr["MailAdress"].ToString(),
                                       Convert.ToInt32(sdr["GebruikerID"])
                                      ));

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
                                    sh.Add(new StudentenHuis
                                    {
                                        StudentenhuisID = (int)sdr["StudentenhuisID"],
                                        Naam = (string)sdr["NaamHuis"]
                                    });
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

        public QueryFeedback voegBewonertoe(int gebruikerID,int studentenhuisID)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = $"update Table_Gebruiker_Activiteit SET StudenthuisID = @studentenhuisID, [In] = (Select Convert (date, GETDATE())) Where GebruikerID = @gebruikerID";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@studentenhuisID", studentenhuisID);
                        cmd.Parameters.AddWithValue("@gebruikerID", gebruikerID);
                        cmd.Connection = conn;

                        conn.Open();

                        cmd.ExecuteNonQuery();
                        feedback.Gelukt = true;
                        return feedback;

                    }
                }
            }
            catch (Exception ex)
            {
                feedback.Gelukt = false;
                feedback.Message = ex.Message;
                return feedback;
            };
        }

        public QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = $"INSERT INTO Table_Studentenhuis Values(@niewenaamhuis)";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@niewenaamhuis", naamniewestudentenhuis);

                        cmd.Connection = conn;

                        conn.Open();

                        cmd.ExecuteNonQuery();
                        feedback.Gelukt = true;
                        return feedback;

                    }
                }
            }
            catch (Exception ex)
            {
                feedback.Gelukt = false;
                feedback.Message = ex.Message;
                return feedback;
            };
        }

        public List<Activiteit> GetListAtiviteitStudentenhuis(int studentenhuisID)
        {
            List<Activiteit> activiteiten = new List<Activiteit>();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = @"SELECT GebruikerId, TegenGebruikerID,Datum,Beschrijving,Bedrag 
                            From Table_Activiteit 
                            Where StudentenhuisID = @studentenhuisID
                            Order by ActiviteitID desc";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@studentenhuisID", studentenhuisID);

                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    activiteiten.Add(new Activiteit
                                    {
                                        Datum = (DateTime)sdr["Datum"],
                                        Beschrijving = (string)sdr["Beschrijving"],
                                        Bedrag = (int)sdr["Bedrag"],
                                        TegenGebruiker = (int)sdr["TegenGebruikerID"],
                                        IngelogdeGebruiker = (int)sdr["GebruikerID"]
                                    });
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception EX)
            {
                Console.Write(EX.Message);
            }
            return activiteiten;
        }

        public Vraag GetVraagBijStudentenhuis(int studentenhuisID)
        {
            Vraag devraag = new Vraag();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = @"SELECT DeVraag,HetAntwoord FROM Table_Vraag Where StudentenhuisID = @studentenhuisID";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@studentenhuisID", studentenhuisID);

                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    devraag = new Vraag
                                    {
                                        Antwoord = (string)sdr["HetAntwoord"],
                                        DeVraag = (string)sdr["DeVraag"]
                                    };
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception EX)
            {
                Console.Write(EX.Message);
            }
            return devraag;
        }

        public QueryFeedback AddVraagBijStudentenhuis(int studentenhuisID,Vraag devraag)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = $"INSERT INTO Table_Vraag Values(@niewenaamhuis,@devraag,@hetantwoord)";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@niewenaamhuis", studentenhuisID);
                        cmd.Parameters.AddWithValue("@devraag", devraag.DeVraag);
                        cmd.Parameters.AddWithValue("@hetantwoord", devraag.Antwoord);

                        cmd.Connection = conn;

                        conn.Open();

                        cmd.ExecuteNonQuery();
                        feedback.Gelukt = true;
                        return feedback;

                    }
                }
            }
            catch (Exception ex)
            {
                feedback.Gelukt = false;
                feedback.Message = ex.Message;
                return feedback;
            };
        }

        public StudentenHuis GetStudentenhuisIdByStudentenhuisName(string StudentenhuisName)
        {
            StudentenHuis huis = new StudentenHuis();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select * FROM Table_Gebruiker Where NaamHuis = @naamhuis";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@naamhuis", StudentenhuisName);

                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                huis.StudentenhuisID = (int)sdr["StudentnehuisID"];
                                huis.Naam = (string)sdr["NaamHuis"];
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

        public QueryFeedback CheckAntwoordOpDeVraag(int studenenthuisID, string hetAntwoord)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = $"Select * from Table_Vraag where StudentenhuisID = @studentenhuisID AND HetAntwoord = @hetantwoord";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@studentenhuisID", studenenthuisID);
                        cmd.Parameters.AddWithValue("@hetantwoord", hetAntwoord);

                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                feedback.Gelukt = true;
                                feedback.Message = "Het antwoord is goed";
                                return feedback;
                            }
                            feedback.Gelukt = false;
                            feedback.Message = "Het antwoord is fout";
                            return feedback;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                feedback.Gelukt = false;
                feedback.Message = ex.Message;
                return feedback;
            };
        }
    }
}
