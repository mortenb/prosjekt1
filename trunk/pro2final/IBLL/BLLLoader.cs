using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using myApp.IBLL;

namespace myApp.IBLL
{
    public class BLLLoader
    {
        /// <summary>
        /// Look up the DAL implementation we should be using
        /// </summary>
        private static readonly string path = ConfigurationManager.AppSettings["BLLAssemblyNamespace"];

        /// <summary>
        /// Creates and returns an instance of the UserBLL implementation.
        /// </summary>
        /// <returns></returns>
       

        public static IAnmeldelseBLL GetAnmeldelseBLL()
        {
            string className = string.Format("{0}.AnmeldelseBLL", path);
            IAnmeldelseBLL ianm = (IAnmeldelseBLL)Assembly.Load(path).CreateInstance(className);
            return ianm;
        }

        public static IAnmeldelseBLL GetAnmeldelseBLLTester()
        {
            string className = "AnmeldelseBLL";
            string path2 = "BLL";
            return (IAnmeldelseBLL)Assembly.Load(path2).CreateInstance(className);
        }

        public static INyhetBLL GetNyhetBLL()
        {
            //string.Format();
            string className = string.Format("{0}.NyhetBLL", path);
            return (INyhetBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static IOrdreBLL GetOrdreBLL()
        {
            string className = string.Format("{0}.OrdreBLL", path);
            return (IOrdreBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static IOrdrelinjeBLL GetOrdrelinjeBLL()
        {
            string className = string.Format("{0}.OrdrelinjeBLL", path);
            return (IOrdrelinjeBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static IProduktBLL GetProduktBLL()
        {
            string className = string.Format("{0}.ProduktBLL", path);
            return (IProduktBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static IProduktkategoriBLL GetProduktkategoriBLL()
        {
            string className = string.Format("{0}.ProduktkategoriBLL", path);
            return (IProduktkategoriBLL)Assembly.Load(path).CreateInstance(className);
        }
    }
}
