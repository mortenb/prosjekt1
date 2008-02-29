using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class ProduktkategoriDAL : Prosjekt2.IDAL.IProduktkategoriDAL
    {
        #region IProduktkategoriDAL Members

        public void nyProduktkategori(Prosjekt2.Modell.Produktkategori pk)
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

        public void endreProduktkategori(Prosjekt2.Modell.Produktkategori pk)
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

        //Trenger kanskje ProduktKategoriFraSqlReader() metode her nede også?
        //For vi trenger jo kanskje en metode for å vise frem kategorier på en sidebar eller no
        //Så det kan værra lurt, ja ;)
        #endregion
    }
}
