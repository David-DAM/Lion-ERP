using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class IncidentType
    {
        public int id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public bool responsability { get; set; }
        public IncidentManage manage { get; set; }

        public IncidentType()
        {
            manage = new IncidentManage();
        }

        public IncidentType(int id)
        {
            this.id = id;
            manage = new IncidentManage();
        }
        /// <summary>
        /// Reads the type.
        /// </summary>
        public void readType()
        {
            manage.readIncidentTypes(this);
        }
    }
}
