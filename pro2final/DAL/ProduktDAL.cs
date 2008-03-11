using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using myApp.Model;
using myApp.IDAL;

namespace myApp.DAL
{
    public class ProduktDAL : IProduktDAL
    {
        #region IProduktDAL Members

        public List<Produkt> getProdukter(int produktkategoriID)
        {
            string query = @"
                                SELECT *
                                FROM Produkt
                                WHERE FKproduktKategori = @produktkategoriID
                            ";

            List<Produkt> prod = new List<Produkt>();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    myCommand.Parameters.AddWithValue("@produktkategoriID", produktkategoriID);
                    SqlDataReader reader = myCommand.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            prod.Add(GetProduktFraSqlReader(ref reader));
                        }
                    }
                    /*
                     * No catch block, let exceptions be handles in the higher layers.
                     */
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                    }
                }
            }
            return prod;
        }

        public List<Produkt> getKjoepteProdukter(string brukernavn)
        {
            //Denne metoden tar i mot et brukernavn og returnere en liste over alle kjøpte produkter som brukeren har kjøpt
            List<Produkt> produkter = new List<Produkt>();

            string query = @"SELECT Produkt.id, Produkt.tittel, Produkt.antallPaaLager, Produkt.beskrivelse, Produkt.bildeURL, Produkt.pris, Produkt.FKproduktKategori 
                            FROM Produkt, Ordre 
                            WHERE Ordre.brukernavn = @brukernavn";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@brukernavn", brukernavn);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            produkter.Add(GetProduktFraSqlReader(ref reader));
                        }
                    }
                    /*
                     * No catch block, let exceptions be handles in the higher layers.
                     */
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                    }
                }
            }
            return produkter;
        }

        public Produkt getNyesteProduktAvKategori(string brukernavn)
        {
            //Denne metoden henter de 10 nyeste produktene i en produktkategori
            string query = @"
                                SELECT Produkt.FKproduktKategori, count(Produkt.*) as produktAntall 
                                FROM Produkt, Ordre, OrdreLinje 
                                WHERE (SELECT OrdreLinje.produktID FROM OrdreLinje WHERE FKOrdreID IN (SELECT id FROM Ordre WHERE brukernavn = @brukernavn))
                                GROUP BY FKproduktKategori 
                                ORDER BY produktAntall 
                                DESC LIMIT 1
                            ";

            Produkt prod = new Produkt();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    myCommand.Parameters.AddWithValue("@brukernavn", brukernavn);
                    SqlDataReader reader = myCommand.ExecuteReader();

                    try
                    {
                            prod = GetProduktFraSqlReader(ref reader);                    }
                    /*
                     * No catch block, let exceptions be handles in the higher layers.
                     */
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                    }
                }
            }
            return prod;
        }

        public Produkt getProdukt(int produktID)
        {
            Produkt p = new Produkt();
            string query = @"
                                SELECT *
                                FROM Produkt where id = @id
                            ";
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", produktID);
                     
                    SqlDataReader reader = myCommand.ExecuteReader();

                    try
                    {
                        while (reader.Read() )
                        {
                            p = GetProduktFraSqlReader(ref reader);
                        }
                    }
                    /*
                     * No catch block, let exceptions be handles in the higher layers.
                     */
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                        
                        }

                    }

                    
                  
                }
                return p;
           
        }

        public List<Produkt> getProduktTilbud()
        {
            //Denne må fortsatt stå på TODO-lista
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyttProdukt(Produkt p)
        {
            //Hva gjør vi med antallPaaLager ?
            string query = @"
                                INSERT INTO Produkt ( tittel, antallPaaLager, beskrivelse, bildeURL, pris, FKproduktKategori) 
                                VALUES ( @tittel, @AntallPaaLager, @beskrivelse, @bildeURL, @pris, @FKproduktKategori)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@tittel", p.Tittel);
                    myCommand.Parameters.AddWithValue("@beskrivelse", p.Beskrivelse);
                    myCommand.Parameters.AddWithValue("@bildeURL", p.BildeURL);
                    myCommand.Parameters.AddWithValue("@pris", p.Pris);
                    myCommand.Parameters.AddWithValue("@FKproduktKategori", p.ProduktkategoriID);
                    myCommand.Parameters.AddWithValue("@AntallPaaLager", p.AntallPaaLager);                 
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        p.ProduktID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette produkt!");
                    }
                }
            }
        }

        public void endreProdukt(Produkt p)
        {
            string query = @"
                                UPDATE Produkt 
                                SET tittel=@tittel,antallPaaLager=@AntallPaaLager,beskrivelse=@beskrivelse,bildeURL=@bildeURL,pris=@pris,FKproduktKategori=@FKproduktKategori
                                WHERE id=@produktID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@produktID", p.ProduktID);
                    myCommand.Parameters.AddWithValue("@tittel", p.Tittel);
                    myCommand.Parameters.AddWithValue("@beskrivelse", p.Beskrivelse);
                    myCommand.Parameters.AddWithValue("@bildeURL", p.BildeURL);
                    myCommand.Parameters.AddWithValue("@pris", p.Pris);
                    myCommand.Parameters.AddWithValue("FKproduktKategori", p.ProduktkategoriID);
                    myCommand.Parameters.AddWithValue("@AntallPaaLager", p.AntallPaaLager);                 
                  
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                       // myCommand.CommandText = "SELECT @@IDENTITY";
                       //p.ProduktID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        private Produkt GetProduktFraSqlReader(ref SqlDataReader reader)
        {
            Produkt produkt = new Produkt();

            if (reader["id"] != DBNull.Value)
            {
                produkt.ProduktID = (int)reader["id"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                produkt.Tittel = (string)reader["tittel"];
            }

            if (reader["beskrivelse"] != DBNull.Value)
            {
                produkt.Beskrivelse = (string)reader["beskrivelse"];
            }

            if (reader["bildeURL"] != DBNull.Value)
            {
                produkt.BildeURL = (string)reader["bildeURL"];
            }

            if (reader["pris"] != DBNull.Value)
            {
                produkt.Pris = (int)reader["pris"];
            }

            if (reader["FKproduktKategori"] != DBNull.Value)
            {
                produkt.ProduktkategoriID = (int)reader["FKproduktKategori"];
            }

            return produkt;
        }

        #endregion
    }
}
