using System;
using System.Collections.Generic;
using Data.Interfaces;
using Model;
using KillerApp.Data.SQL;
using System.Data.SqlClient;

namespace Data.Contexts
{
    public class GebruikerSqlContext : SqlCon, IGebruikerContext
    {

        public List<Gebruiker> GetAllGebruiks()
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
                                    list.Add(new Gebruiker
                                    {
                                        GebruikerID = Convert.ToInt32(sdr["GebruikerID"]),
                                        Gebruikersnaam = sdr["Gebruikersnaam"].ToString(),
                                        Wachtwoord = sdr["Wachtwoord"].ToString(),
                                        Voornaam = sdr["Voornaam"].ToString(),
                                        Achternaam = sdr["Achternaam"].ToString(),
                                        Gebortendatum = Convert.ToDateTime(sdr["Geboortedatum"]),
                                        Mobielnummer = Convert.ToInt32(sdr["MobielNummer"]),
                                        Geslacht = (Geslacht)Convert.ToInt32(sdr["Geslacht"]),
                                        Email = sdr["MailAdress"].ToString(),
                                        Studentenhuis = Convert.ToInt32(sdr["StudentenHuis"])
                                    });
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
    }    
    
}
