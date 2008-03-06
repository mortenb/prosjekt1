using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace myApp.IDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class DALLoader
    {
        /// <summary>
        /// Look up the DAL implementation we should be using
        /// </summary>
        private static readonly string path = ConfigurationManager.AppSettings["DALAssemblyNamespace"];

        /// <summary>
        /// Creates and returns an instance of the UserDAL implementation.
        /// </summary>
        /// <returns></returns>
      

        public static IAnmeldelseDAL getAnmeldelseDAL()
        {
            string className = string.Format("{0}.AnmeldelseDAL", path);
            return (IAnmeldelseDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static INyhetDAL getNyhetDAL()
        {
            string className = string.Format("{0}.NyhetDAL", path);
            return (INyhetDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IOrdreDAL getOrdreDAL()
        {
            string className = string.Format("{0}.OrdreDAL", path);
            return (IOrdreDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IOrdrelinjeDAL getOrdrelinjeDAL()
        {
            string className = string.Format("{0}.OrdrelinjeDAL", path);
            return (IOrdrelinjeDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IProduktDAL getProduktDAL()
        {
            string className = string.Format("{0}.ProduktDAL", path);
            return (IProduktDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IProduktkategoriDAL getProduktKategoriDAL()
        {
            string className = string.Format("{0}.ProduktKategoriDAL", path);
            return (IProduktkategoriDAL)Assembly.Load(path).CreateInstance(className);
        }

    }
}
