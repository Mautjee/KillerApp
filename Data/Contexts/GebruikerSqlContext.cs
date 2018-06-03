using System;
using System.Collections.Generic;
using Model;
using KillerApp.Data.Interfaces;
using KillerApp.Data.SQL;
using System.Data.SqlClient;
using static Model.Gebruiker;


namespace Data.Contexts
{
    public class GebruikerSqlContext : SqlCon, IGebruikerContext
    {


        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> list = new List<Gebruiker>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = @"USE [Mauro_SQL];
                                        Select* FROM Table_Gebruiker;";

                        cmd.CommandText = query;


                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    list.Add(new Gebruiker(sdr["Gebruikersnaam"].ToString(),
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

            return list;
        }

        public Gebruiker GetbyID(int id)
        {
            Gebruiker gebr = new Gebruiker();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select * FROM Table_Gebruiker WHERE GebruikerID = {id};";

                        cmd.CommandText = query;


                        cmd.Connection = conn;

                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                           
                            if (sdr.HasRows)
                            {
                                sdr.Read();

                                gebr = new Gebruiker(
                                       sdr["Gebruikersnaam"].ToString(),
                                        sdr["Voornaam"].ToString(),
                                         sdr["Achternaam"].ToString(),
                                        Convert.ToDateTime(sdr["Geboortedatum"]),
                                        sdr["MobielNummer"].ToString(),
                                        (Geslacht)Convert.ToInt32(sdr["Geslacht"]),
                                       sdr["MailAdress"].ToString(),
                                       Convert.ToInt32(sdr["GebruikerID"]),
                                       Convert.ToInt32(sdr["StudentenhuisID"]));

                                gebr.SetWachtwoord(sdr["wachtwoord"].ToString());
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

            return gebr;
        }
        public QueryFeedback AddGebruiker(Gebruiker g)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                    
                        string qry = $"INSERT INTO Table_Gebruiker(Gebruikersnaam,Wachtwoord,Voornaam,Achternaam,Geboortedatum,MobielNummer,MailAdress,StudentenhuisID,Geslacht)" +
                                        $" VALUES('{g.Gebruikersnaam}','{g.Wachtwoord}','{g.Voornaam}','{g.Achternaam}'" +
                                        $",'{g.Geboortedatum.ToString("yyMMdd")}','{g.Mobielnummer}','{g.Email}'," +
                                        $"'{g.StudentenhuisID}','{(int)g.hetGeslacht}')";

                        cmd.CommandText = qry;


                        cmd.Connection = conn;

                        conn.Open();

                        cmd.ExecuteNonQuery();
                        feedback.Gelukt = true;
                        return feedback;
                        
                    }
                }
            }
            catch(Exception ex)
            {
                feedback.Gelukt = false;
                feedback.Message = ex.Message;
                return feedback;
            }
            
        }

        public QueryFeedback updateGebruiker(Gebruiker g)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = $"UPDATE Table_Gebruiker SET Gebruikersnaam = '{g.Gebruikersnaam}',Voornaam = '{g.Voornaam}',Achternaam = '{g.Achternaam}'," +
                                        $"Geboortedatum = '{g.Geboortedatum}',MobielNummer = '{g.Mobielnummer}',MailAdress = '{g.Email}',Geslacht = '{(int)g.hetGeslacht}'" +
                                            $"WHERE GebruikerID = {g.GebruikerID}";

                        cmd.CommandText = qry;


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
            }
            
        }

        public QueryFeedback CheckLogin(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }
    }
}
