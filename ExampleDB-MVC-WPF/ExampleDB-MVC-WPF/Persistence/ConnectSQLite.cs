using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ExampleDB_MVC_WPF.Persistence
{
    public class ConnectSQLite
    {
        static string databasename = "usuarios.db";
        static string folderpath = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug","\\db\\"); 
        public static string databasepath = System.IO.Path.Combine(folderpath, databasename);
    }
}
