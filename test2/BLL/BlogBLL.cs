using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class BlogBLL
    {
        public static int nyBlog(Blog b)
        {
            return BlogDAL.nyBlog(b);
        }

        public static List<Blog> getBlogger()
        {
            return BlogDAL.getBlogger();
        }

        public static Blog getBlog(int blogID)
        {
            return BlogDAL.getBlog(blogID);
        }

        public static Blog getBloggAvEier(string eier)
        {
            return BlogDAL.getBloggAvEier(eier);
        }


    }
}
