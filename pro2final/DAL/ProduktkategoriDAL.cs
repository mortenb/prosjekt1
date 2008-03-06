using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using myApp.Model;
using myApp.IDAL;

namespace myApp.DAL
{
    public class ProduktkategoriDAL : IProduktkategoriDAL
    {
        #region IProduktkategoriDAL Members

        public void nyProduktkategori(Produktkategori pk)
        {
            string query = @"
                                INSERT INTO ProduktKategori (id, navn) VALUES (@id, @navn)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", pk.ProduktkategoriID);
                    myCommand.Parameters.AddWithValue("@navn", pk.Navn);
                    

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        pk.ProduktkategoriID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        public void endreProduktkategori(Produktkategori pk)
        {
            string query = @"
                                UPDATE ProduktKategori 
                                SET navn=@navn
                                WHERE id = @produktKategoriID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", pk.ProduktkategoriID);
                    myCommand.Parameters.AddWithValue("@navn", pk.Navn);                    

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        pk.ProduktkategoriID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        public List<Produktkategori> getProduktkategorier()
        {
            string query = @"
                                SELECT *
                                FROM ProduktKategori
                            ";

            List<Produktkategori> pker = new List<Produktkategori>();
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
                            pker.Add(GetProduktkategoriFraSqlReader(ref reader));
                        }
                    }
                    /*
                     * No catch block, let exceptions be handled in the higher layers.
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
            return pker;
        }

        //Trenger kanskje ProduktKategoriFraSqlReader() metode her nede også?
        //For vi trenger jo kanskje en metode for å vise frem kategorier på en sidebar eller no
        //Så det kan værra lurt, ja ;)

        private Produktkategori GetProduktkategoriFraSqlReader(ref SqlDataReader reader)
        {
            Produktkategori pk = new Produktkategori();

            if (reader["id"] != DBNull.Value)
            {
                pk.ProduktkategoriID = (int)reader["id"];
            }

            if (reader["navn"] != DBNull.Value)
            {
                pk.Navn = (string)reader["navn"];
            }

            return pk;
        }

        #endregion
    }
}
