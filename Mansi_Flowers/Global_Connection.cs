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
        
        public static String path=Environment.CurrentDirectory;
        public static String conn = "Data Source=|DataDirectory|\\Lilies.sdf";
               
       
    }
    
}
