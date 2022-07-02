using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class SuplierManage
    {
        public List<Suplier> list;

        public SuplierManage()
        {
            list = new List<Suplier>();
        }
        /// <summary>
        /// Read all the supliers from a JSON file.
        /// </summary>
        public void readAll()
        {
            String json = System.IO.File.ReadAllText(@"Suplier.json");
            list = JsonConvert.DeserializeObject<List<Suplier>>(json);

        }
    }
}
