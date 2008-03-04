using System;
using System.Collections.Generic;

using myApp.IBLL;
using myApp.IDAL;
using myApp.Model;

namespace myApp.BLL
{
    /// <summary>
    /// Summary description for UserBLL
    /// </summary>
    public class UserBLL : IUserBLL
    {
        /// <summary>
        /// Load the implementation of the DAL
        /// </summary>
        private IUserDAL userDAL = DALLoader.GetUserDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        { 
            List<User> users = userDAL.GetUsers();

            /* 
             *   BLL Methods often does not DO much, or eanything at all, 
             *   in an early phase of an applications lifecycle. 
             * 
             *   They do however, in the cause of the develpoment, provide us with 
             *   an excellent extention point.
             *
             *    Further more we have a place to put code that might be used by several 
             *    web pages, services or even windows desktop applications.
             */

            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            /*
             * May look stupid, but may later be used to enforce rules.
             * 
             * Like "No anonymous email providers" e.g. Hotmail.
             * 
             * Or "Credit checks" for commerce applictions.
             * 
             */
            return userDAL.AddUser(user);
        }
    }
}