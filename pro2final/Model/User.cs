using System;


namespace myApp.Model
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
        public User()
        {
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
