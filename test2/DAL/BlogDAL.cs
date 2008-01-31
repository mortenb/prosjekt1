using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using DOTNETPROSJEKT1.Model;
using System.Configuration;

namespace DOTNETPROSJEKT1.DAL
{
    public static class BlogDAL
    {
        public static List<Blog> getBlogger()
        {
           
            string query = @"
                                SELECT *
                                FROM blogg
                            ";
            Console.WriteLine("BlogDAL.getBlogger()");
            List<Blog> blogger = new List<Blog>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
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
                            blogger.Add(BloggFraSqlReader(ref reader));
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

            return blogger;
        }

        public static Blog getBlog(int id)
        {
            Blog blogg = new Blog();

            string query = @"
                                SELECT *
                                FROM blogg
                                WHERE blogg.id = @id
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
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
                            blogg = BloggFraSqlReader(ref reader);
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

            return blogg;
        }

        public static void nyBlog(Blog blogg)
        {
            string query = @"
                                INSERT INTO blogg (id, eier, tittel) VALUES (@id, @eier, @tittel)
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", blogg.BlogID);
                    myCommand.Parameters.AddWithValue("@eier", blogg.Eier);
                    myCommand.Parameters.AddWithValue("@tittel", blogg.Tittel);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        blogg.BlogID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bruker.. Beklager");
                    }
                }
            }
        }

        private static Blog BloggFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Blog blogg = new Blog();

            if (reader["id"] != DBNull.Value)
            {
                blogg.BlogID = (int)reader["id"];
            }

            if (reader["eier"] != DBNull.Value)
            {
                blogg.Eier = (string)reader["eier"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                blogg.Tittel = (string)reader["tittel"];
            }

            return blogg;
        }




    }
}
