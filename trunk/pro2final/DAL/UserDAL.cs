using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

using myApp.Model;
using myApp.IDAL;

namespace myApp.DAL
{
    /// <summary>
    /// Summary description for UserDAL
    /// </summary>
    public class UserDAL : IUserDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            string query = @"
                                SELECT *
                                FROM Users
                            ";

            List<User> users = new List<User>();
            using(SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            users.Add(GetUserFromSqlReader(ref reader));
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
            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            string query = @"
                                SELECT *
                                FROM Users
                                WHERE Id = @UserId
                            ";

            User user = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@UserId", userId);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            /*
                             * Risky, but acceptable.
                             * we assume, from our knowledge of the database 
                             * (Id is primary key) that there can be only on row.
                             */
                            user = GetUserFromSqlReader(ref reader); // reuse of code as function
                        }
                        else
                        {
                            /*
                             * Shuld be custom Exceptions, subclasses of ApplicationException,
                             * That describe the exception: Like NonExistentUserEsception.
                             */
                            throw new ApplicationException("Error geting user!");
                        }
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Pass objects, rather then every parameter as in AddUser(string FirstName, string LastName, string Email, string Password)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            string query = @"
                                INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", user.Firstname);
                    myCommand.Parameters.AddWithValue("@LastName", user.Lastname);
                    myCommand.Parameters.AddWithValue("@Email", user.Username);
                    myCommand.Parameters.AddWithValue("@Password", user.Password);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        user.Id = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Error creating new user!");
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Mapping function that puts one line of data from a SqlDataReader into a MyApp.Model.User object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private User GetUserFromSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            User user = new User();

            if(reader["Id"] != DBNull.Value)
            {
                user.Id = (int) reader["Id"];
            }

            if (reader["FirstName"] != DBNull.Value)
            {
                user.Firstname = (string) reader["FirstName"];
            }

            if (reader["LastName"] != DBNull.Value)
            {
                user.Lastname = (string)reader["LastName"];
            }

            if (reader["Email"] != DBNull.Value)
            {
                user.Username = (string)reader["Email"];
            }

            if (reader["PassWord"] != DBNull.Value)
            {
                user.Password = (string)reader["PassWord"];
            }

            return user;
        }
    }
}
