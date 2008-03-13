using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using myApp.Model;
using myApp.IDAL;

namespace myApp.DAL
{
    public class NyhetDAL : INyhetDAL
    {
        #region INyhetDAL Members

        public List<Nyhet> getNyheter()
        {
            string query = @"
                                SELECT *
                                FROM Nyhet Order by id DESC
                            ";

            List<Nyhet> nyheter = new List<Nyhet>();
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
                            nyheter.Add(GetNyhetFraSqlReader(ref reader));
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
            return nyheter;
        }

        public Nyhet getNyhet(int nyhetID)
        {
            string query = @"
                                SELECT *
                                FROM Nyhet
                                WHERE id = @nyhetID
                            ";

            Nyhet nyhet = new Nyhet();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i sp�rringen
                    myCommand.Parameters.AddWithValue("@nyhetID", nyhetID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            nyhet = GetNyhetFraSqlReader(ref reader);
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
            return nyhet;
        }

        public void nyNyhet(Nyhet n)
        {
            string query = @"
                                INSERT INTO Nyhet (tittel, tekst) VALUES (@tittel, @tekst)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    
                    myCommand.Parameters.AddWithValue("@tittel", n.Tittel);
                    myCommand.Parameters.AddWithValue("@tekst", n.Tekst);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        n.NyhetsID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        public void endreNyhet(Nyhet n)
        {
            //Veldig usikker p� kommende sqlsp�rringsyntaks
            //Vennligst sjekk dette ut s� fort som mulig
            string query = @"
                                UPDATE Nyhet 
                                SET tittel=@tittel,tekst=@tekst
                                WHERE id = @nyhetID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", n.NyhetsID);
                    myCommand.Parameters.AddWithValue("@tittel", n.Tittel);
                    myCommand.Parameters.AddWithValue("@tekst", n.Tekst);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        n.NyhetsID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        private Nyhet GetNyhetFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Nyhet nyhet = new Nyhet();

            if (reader["id"] != DBNull.Value)
            {
                nyhet.NyhetsID = (int)reader["id"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                nyhet.Tittel = (string)reader["tittel"];
            }

            if (reader["tekst"] != DBNull.Value)
            {
                nyhet.Tekst = (string)reader["tekst"];
            }
            return nyhet;
        }

        #endregion
    }
}
