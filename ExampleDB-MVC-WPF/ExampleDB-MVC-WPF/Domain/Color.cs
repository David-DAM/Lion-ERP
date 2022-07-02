using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Color
    {
        public int id { get; set; }
        public String name { get; set; }

        public ProductManage manage { get; set; }

        public Color()
        {
            manage = new ProductManage();
        }

        public Color(int id)
        {
            this.id = id;
            manage = new ProductManage();
        }
        public Color(int id,String name)
        {
            this.id = id;
            this.name = name;
            manage = new ProductManage();
        }
        /// <summary>
        /// Reads the color.
        /// </summary>
        public void readColor()
        {
            manage.readColor(this);
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
            return obj is Color color &&
                   id == color.id &&
                   name == color.name;
        }
    }
}
