using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public class BlogBLL
    {
        public static List<Blog> getBlogger()
        {
            List<Blog> blogger = BlogDAL.getBlogger();
            Console.WriteLine("BlogDAL.getBlogger()");
            //Trenger logikk for å kun hente ut tittel
            // return titler;
            //Oppdatert: Dette gjøres i GUI
            return blogger;
        }

        public static List<Blog> getBlog(int blogID)
        {
            Blog blog = BlogDAL.getBlog(blogID);

            List<Blog> blogger = new List<Blog>();
            blogger.Add(blog);

            return blogger;
        }


    }
}
