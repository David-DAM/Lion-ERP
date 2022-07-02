using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class Region
    {
        public int id { get; set; }
        public String name { get; set; }

        public CustomerManage manage { get; set; }

        public Region()
        {
            manage = new CustomerManage();
        }

        public Region(int idregion)
        {
            this.id = idregion;
            manage = new CustomerManage();
        }
        public Region(int idregion,String name)
        {
            this.id = idregion;
            this.name = name;
            manage = new CustomerManage();
        }
        /// <summary>
        /// Reads the region.
        /// </summary>
        public void readRegion()
        {
            manage.readRegion(this);
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
            return obj is Region region &&
                   id == region.id &&
                   name == region.name;
        }
    }
}
