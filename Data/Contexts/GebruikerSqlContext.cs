﻿using System;
using System.Collections.Generic;
using Model;
using KillerApp.Data.Interfaces;
using KillerApp.Data.SQL;
using System.Data.SqlClient;
using static Model.Gebruiker;
using KillerApp.Model;

namespace Data.Contexts
{
    public class GebruikerSqlContext : IGebruikerContext
    {

        private SqlCon sqlcon = new SqlCon();
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> list = new List<Gebruiker>();


            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
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
                                    list.Add(new Gebruiker(
                                        sdr["Gebruikersnaam"].ToString(),
                                        sdr["Voornaam"].ToString(),
                                        sdr["Achternaam"].ToString(), 
                                        sdr["MailAdress"].ToString(), 
                                        Convert.ToInt32(sdr["GebruikerID"])));
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
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
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
                                       sdr["MailAdress"].ToString(),
                                       Convert.ToInt32(sdr["GebruikerID"]));

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
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                    
                        string qry = @"INSERT INTO Table_Gebruiker(Gebruikersnaam,Wachtwoord,Voornaam,Achternaam,MailAdress) 
                                        VALUES(@gebruikersnaam,@wachtwoord,@voornaam,@achternaam,@email)";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@gebruikersnaam", g.Gebruikersnaam);
                        cmd.Parameters.AddWithValue("@wachtwoord", g.Wachtwoord);

                        cmd.Parameters.AddWithValue("@voornaam", g.Voornaam);
                        cmd.Parameters.AddWithValue("@achternaam", g.Achternaam);

                        cmd.Parameters.AddWithValue("@email", g.Email);





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
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = @"UPDATE Table_Gebruiker SET Gebruikersnaam = @gebruikersnaam ,Voornaam = @voornaam ,Achternaam = @achternaam, MailAdress = @mailadress  
                                            WHERE GebruikerID = @gebruikerid";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@gebruikersnaam", g.Gebruikersnaam);
                        cmd.Parameters.AddWithValue("@voornaam", g.Voornaam);
                        cmd.Parameters.AddWithValue("@achternaam", g.Achternaam);

                        cmd.Parameters.AddWithValue("gebruikerid", g.GebruikerID);
                        cmd.Parameters.AddWithValue("@mailadress", g.Email);


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

        public Gebruiker CheckLogin(Gebruiker gebruiker)
        {
            Gebruiker gebr = new Gebruiker();


            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = $"Select * from Table_Gebruiker WHere Gebruikersnaam = @gebrnaam and Wachtwoord = @passw";

                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@gebrnaam", gebruiker.Gebruikersnaam);
                        cmd.Parameters.AddWithValue("@passw", gebruiker.Wachtwoord);

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
                                    sdr["MailAdress"].ToString(),
                                    Convert.ToInt32(sdr["GebruikerID"]));

                                gebr.SetWachtwoord(sdr["wachtwoord"].ToString());
                            }
                            else
                            {
                                gebr = new Gebruiker();
                                

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

        public QueryFeedback VoegActifiteitToe(Activiteit activiteit)
        {
            QueryFeedback feedback = new QueryFeedback();
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon.connectionstring()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string qry = "Insert INTO [dbo].[Table_Activiteit] Values(@ingelogdegebruiker,@studentenhuisid,@datum,@beschrijving,@bedrag,@tegengebruiker)";

                        cmd.CommandText = qry;

                        cmd.Parameters.AddWithValue("@ingelogdegebruiker",activiteit.IngelogdeGebruiker);
                        cmd.Parameters.AddWithValue("@studentenhuisid", activiteit.StudentenhuisID);
                        cmd.Parameters.AddWithValue("@datum", activiteit.Datum);
                        cmd.Parameters.AddWithValue("@beschrijving", activiteit.Beschrijving);
                        cmd.Parameters.AddWithValue("@bedrag", activiteit.Bedrag);
                        cmd.Parameters.AddWithValue("@tegengebruiker", activiteit.TegenGebruiker);


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
    }
}
