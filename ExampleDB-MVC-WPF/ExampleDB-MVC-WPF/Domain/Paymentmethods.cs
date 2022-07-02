using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Paymentmethods
    {
        public int id { get; set; }
        public string name { get; set; }
        public int deleted { get; set; }
        public OrderManage manage { get; set; }

        public Paymentmethods()
        {
            manage = new OrderManage();
        }

        public Paymentmethods(int id)
        {
            this.id = id;
            manage = new OrderManage();
        }
        public Paymentmethods(int id,String name)
        {
            this.id = id;
            this.name = name;
            manage = new OrderManage();
        }
        /// <summary>
        /// Reads the paymentmethod.
        /// </summary>
        public void readPaymentmethod()
        {
            manage.readPaymentmethod(this);
        }
        /// <summary>
        /// Loads the paymentmethod.
        /// </summary>
        public void loadPaymentmethod()
        {
            manage.loadPaymentmethods();
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
            return obj is Paymentmethods paymentmethods &&
                   id == paymentmethods.id &&
                   name == paymentmethods.name;
        }
    }
}
