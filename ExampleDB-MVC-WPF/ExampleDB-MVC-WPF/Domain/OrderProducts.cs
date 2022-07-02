using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class OrderProducts
    {
        public int id { get; set; }
        public Product product { get; set; }
        public String name { get; set; }
        public int amountSale { get; set; }
        public double priceSale { get; set; }
        public OrderManage manage { get; set; }
        public OrderProducts()
        {
            manage = new OrderManage();
        }

        
    }
}
