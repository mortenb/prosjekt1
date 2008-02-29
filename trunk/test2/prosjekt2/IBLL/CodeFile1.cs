using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using IBLL;

namespace IBLL
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
        public static IAnmeldelsesBLL GetAnmeldesesBLL()
        {
            string className = string.Format("{0}.AnmeldelsesBLL", path);
            return (IAnmeldelsesBLL)Assembly.Load(path).CreateInstance(className);
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

        public static IProduktKategoriBLL GetProduktKategoriBLL()
        {
            string className = string.Format("{0}.ProduktKategoriBLL", path);
            return (IProduktKategoriBLL)Assembly.Load(path).CreateInstance(className);
        }
    }
}
