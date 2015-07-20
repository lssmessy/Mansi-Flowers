using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mansi_Flowers
{
    public static class Global_Connection
    {
        
        
        //public static String path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); 
        public static String path=Environment.CurrentDirectory;
        //public static String conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "\\Lili_Master.accdb";
        public static String conn = "Data Source=" + path + "\\Lilies.sdf";
       
    }
}
