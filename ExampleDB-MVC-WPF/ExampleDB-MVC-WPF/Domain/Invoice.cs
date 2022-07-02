using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Invoice
    {
        public int id { get; set; }
        public Order order { get; set; }
        public DateTime date { get; set; }
        public int accounted { get; set; }

        public OrderManage manage { get; set; }

        public Invoice()
        {
            manage = new OrderManage();
        }
        /// <summary>
        /// Reads all invoices.
        /// </summary>
        public void readAllInvoices()
        {
            manage.readAllInvoices();
        }
        /// <summary>
        /// Reads the identifier invoice order.
        /// </summary>
        public void readIdInvoiceOrder()
        {
            manage.readIdInvoiceOrder(this);
        }
        /// <summary>
        /// Checks the order invoice.
        /// </summary>
        /// <returns></returns>
        public Boolean checkOrderInvoice()
        {
            return manage.checkOrderInvoice(this);
        }
        /// <summary>
        /// Inserts the invoice.
        /// </summary>
        public void insertInvoice()
        {
            manage.insertInvoice(this);
        }
        /// <summary>
        /// Inserts the order invoice.
        /// </summary>
        public void insertOrderInvoice()
        {
            manage.insertOrderInvoice(this);
        }
        /// <summary>
        /// Accounts the invoice.
        /// </summary>
        public void accountInvoice()
        {
            manage.accountInvoice(this);
        }
        /// <summary>
        /// Deletes the invoice.
        /// </summary>
        public void deleteInvoice()
        {
            manage.deleteInvoice(this);
        }
        /// <summary>
        /// Recovers the invoice.
        /// </summary>
        public void recoverInvoice()
        {
            manage.recoverInvoice(this);
        }
        /// <summary>
        /// Modifies the accounted.
        /// </summary>
        public void modifyAccounted()
        {
            manage.modifyAccounted(this);
        }
        /// <summary>
        /// Reads the idorder invoice.
        /// </summary>
        public void readIdorderInvoice()
        {
            manage.readIdorderInvoice(this); ;
        }
        /// <summary>
        /// Loads the table data invoices.
        /// </summary>
        public void loadTableDataInvoices()
        {
            manage.loadTableDataInvoices(this);
        }
        /// <summary>
        /// Loads the table products invoices.
        /// </summary>
        public void loadTableProductsInvoices()
        {
            manage.loadTableProductsInvoices(this);
        }
    }
}
