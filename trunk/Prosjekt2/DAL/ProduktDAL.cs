using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class ProduktDAL : IProduktDAL
    {
        #region IProduktDAL Members

        public List<Produkt> getProdukter()
        {
            string query = @"
                                SELECT *
                                FROM Produkt
                            ";

            List<Produkt> prod = new List<Produkt>();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
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

        public List<Produkt> getProduktTilbud()
        {
            //Denne m� fortsatt st� p� TODO-lista
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyttProdukt(Produkt p)
        {
            //Hva gj�r vi med antallPaaLager ?
            string query = @"
                                INSERT INTO Produkt (id, tittel, beskrivelse, bildeURL, pris, FKproduktKategori) 
                                VALUES (@id, @tittel, @beskrivelse, @bildeURL, @pris, @FKproduktKategori)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", p.ProduktID);
                    myCommand.Parameters.AddWithValue("@tittel", p.Tittel);
                    myCommand.Parameters.AddWithValue("@beskrivelse", p.Beskrivelse);
                    myCommand.Parameters.AddWithValue("@bildeURL", p.BildeURL);
                    myCommand.Parameters.AddWithValue("@pris", p.Pris);
                    myCommand.Parameters.AddWithValue("@FKproduktKategori", p.ProduktkategoriID);
                  

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
                                SET tittel=@tittel,beskrivelse=@beskrivelse,bildeURL=@bildeURL,pris=@pris,FKproduktKategori=@FKproduktKategori
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
                    
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        p.ProduktID = Convert.ToInt32(myCommand.ExecuteScalar());
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