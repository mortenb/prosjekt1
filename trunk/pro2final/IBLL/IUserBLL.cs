using System;
using System.Collections.Generic;
using System.Text;

using myApp.Model;

namespace myApp.IBLL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User AddUser(User user);
    }
}
