using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Zipcode
    {
        public int id { get; set; }
        public String name { get; set; }

        public CustomerManage manage { get; set; }

        public Zipcode()
        {
            manage = new CustomerManage();
        }

        public Zipcode(int id)
        {
            this.id = id;
            manage = new CustomerManage();
        }
        public Zipcode(String name)
        {
            this.name = name;
            manage = new CustomerManage();
        }
        public Zipcode(int id, String name)
        {
            this.id = id;
            this.name = name;
            manage = new CustomerManage();
        }
        /// <summary>
        /// Reads the zipcode.
        /// </summary>
        public void readZipcode()
        {
            manage.readZipcode(this);
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Zipcode zipcode &&
                   id == zipcode.id &&
                   name == zipcode.name;
        }
    }
}
