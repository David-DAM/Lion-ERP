using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Suplier
    {
        public int id { get; set; }
        public String nif { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String phone { get; set; }
        public SuplierManage manage { get; set; }

        public Suplier()
        {
            manage = new SuplierManage();
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
    }
}
