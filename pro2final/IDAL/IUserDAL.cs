using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User AddUser(User user);
    }
}
