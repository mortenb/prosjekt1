using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
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
        public static IAnmeldelseBLL GetAnmeldeseBLL()
        {
            string className = string.Format("{0}.AnmeldelseBLL", path);
            return (IAnmeldelseBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static INyhetBLL GetNyhetBLL()
        {
            string className = string.Format("{0}.NyhetBLL", path);
            return (INyhetBLL)Assembly.Load(path).CreateInstance(className);
        }

        public static IOrdreBLL GetOrdreBLL()
        {
            string className = string.Format("{0}.OrdreBLL", path);
            return (IOrdreBLL)Assembly.Load(path).CreateInstance(className);
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
