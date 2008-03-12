using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using myApp.Model;
using myApp.IDAL;


namespace myApp.DAL
{
    public class AnmeldelseDAL : IAnmeldelseDAL
    {
        #region IAnmeldelseDAL Members

        public List<Anmeldelse> getAnmeldelser(int produktID)
        {
            //TODO: Implementere med produktID
            string query = @"
                                SELECT *
                                FROM Anmeldelse
                                WHERE produktID = @produktID
                            ";

            List<Anmeldelse> anm = new List<Anmeldelse>();
            using(SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til produktID i spørringen
                    myCommand.Parameters.AddWithValue("@produktID", produktID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();

                    

                    try
                    {
                        while (reader.Read())
                        {
                            anm.Add(GetAnmeldelseFraSqlReader(ref reader));
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
            return anm;
        }

        public Anmeldelse getAnmeldelse(int anmID)
        {
            //TODO: Implementere med produktID
            string query = @"
                                SELECT *
                                FROM Anmeldelse
                                WHERE id = @id
                            ";

            Anmeldelse anm = new Anmeldelse();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til produktID i spørringen
                    myCommand.Parameters.AddWithValue("@id", anmID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();



                    try
                    {
                        anm = GetAnmeldelseFraSqlReader(ref reader);
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
            return anm;
        }

        public void nyAnmeldelse(Anmeldelse anm)
        {
            string query = @"
                                INSERT INTO Anmeldelse (tittel,tekst,karakter,produktID) VALUES (@tittel, @tekst, @karakter, @produktID)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {

                    myCommand.Parameters.AddWithValue("@tittel", anm.Tittel);
                    myCommand.Parameters.AddWithValue("@tekst", anm.Tekst);
                    myCommand.Parameters.AddWithValue("@karakter", anm.Karakter);
                    myCommand.Parameters.AddWithValue("@produktID", anm.ProduktID);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        //Dette er strengt tatt ikke nødvendig, siden vi ikke skal returnere objektet
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        anm.NyhetsID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette nyhet!");
                    }
                }
            }
        }

        private Anmeldelse GetAnmeldelseFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Anmeldelse anm = new Anmeldelse();

            if (reader["id"] != DBNull.Value)
            {
                anm.NyhetsID = (int)reader["id"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                anm.Tittel = (string)reader["tittel"];
            }

            if (reader["tekst"] != DBNull.Value)
            {
                anm.Tekst = (string)reader["tekst"];
            }

            if (reader["karakter"] != DBNull.Value)
            {
                anm.Karakter = (int)reader["karakter"];
            }

            if (reader["produktID"] != DBNull.Value)
            {
                anm.ProduktID = (int)reader["produktID"];
            }

            return anm;
        }
        #endregion
    }
}
