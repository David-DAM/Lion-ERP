using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Order
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        public User user { get; set; }
        public DateTime date { get; set; }
        public Paymentmethods paymentmethod { get; set; }
        public double total { get; set; }
        public double prepaid { get; set; }
        public int delete { get; set; }
        public int confirmed { get; set; }
        public int labeled { get; set; }
        public int sent { get; set; }
        public int invoiced { get; set; }
        public OrderManage manage { get; set; }

        public Order()
        {
            manage = new OrderManage();
        }
        public Order(int id)
        {
            this.id = id;
            manage = new OrderManage();
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
        /// <summary>
        /// Reads the order.
        /// </summary>
        public void readOrder()
        {
            manage.readOrder(this);
        }
        /// <summary>
        /// Reads the order products.
        /// </summary>
        public void readOrderProducts()
        {
            manage.readOrderProducts(this);
        }
        /// <summary>
        /// Inserts the order.
        /// </summary>
        public void insertOrder()
        {
            manage.insertOrder(this);
        }
        /// <summary>
        /// Inserts the order products.
        /// </summary>
        public void insertOrderProducts()
        {
            manage.insertOrderProducts(this);
        }
        /// <summary>
        /// Modifies the order.
        /// </summary>
        public void modifyOrder()
        {
            manage.modifyOrder(this);
        }
        /// <summary>
        /// Modifies the order status.
        /// </summary>
        public void modifyOrderStatus()
        {
            manage.modifyOrderStatus(this);
        }
        /// <summary>
        /// Deletes the order.
        /// </summary>
        public void deleteOrder()
        {
            manage.deleteOrder(this);
        }
        /// <summary>
        /// Deletes the order products.
        /// </summary>
        public void deleteOrderProducts()
        {
            manage.deleteOrderProducts(this);
        }
        /// <summary>
        /// Searches the order.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchOrder(String filtro)
        {
            manage.searchOrder(filtro);
        }
        /// <summary>
        /// Inserts to fill test data.
        /// </summary>
        public void insertToFill()
        {
            manage.insertToFill(this);
        }

    }
}
