using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class OrderManage
    {
        public List<Order> list { get; set; }
        public List<OrderProducts> products { get; set; }
        public List<Paymentmethods> paymentmethods { get; set; }
        public List<Invoice> invoices { get; set; }
        public DataTable tinvoices { get; set; }
        public DataTable tProductsinvoices { get; set; }

        public OrderManage()
        {
            list = new List<Order>();
            products = new List<OrderProducts>();
            paymentmethods = new List<Paymentmethods>();
            invoices = new List<Invoice>();
            tinvoices = new DataTable();
            tProductsinvoices = new DataTable();
        }
        /// <summary>
        /// Read all the orders and put them in a list
        /// </summary>
        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from FIRST100ORDERS", "orders");

            DataTable table = data.Tables["orders"];

            Order aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Order();
                aux.id = Convert.ToInt32(row["Idorder"]);
                aux.customer =new Customer(Convert.ToInt32(row["refcustomer"]));
                aux.customer.readCustomer();
                aux.user = new User(Convert.ToInt32(row["refuser"]));
                aux.date = Convert.ToDateTime(row["datetime"]);
                aux.paymentmethod = new Paymentmethods(Convert.ToInt32(row["refpaymentmethod"]));
                aux.paymentmethod.readPaymentmethod();
                aux.total= Convert.ToDouble(row["total"]);
                aux.prepaid = Convert.ToDouble(row["prepaid"]);
                aux.confirmed = Convert.ToInt32(row["confirmed"]);
                aux.labeled = Convert.ToInt32(row["labeled"]);
                aux.sent = Convert.ToInt32(row["sent"]);
                aux.invoiced = Convert.ToInt32(row["invoiced"]);


                list.Add(aux);
            }
        }
        /// <summary>
        /// Read all the orderproducts and put them in a list
        /// </summary>
        /// <param name="order">The order.</param>
        public void readOrderProducts(Order order)
        {
            int id;
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("select o.refproduct,p.description,o.amount,o.pricesale from products p,ordersproducts o where p.idproduct=o.refproduct and o.reforder=" + order.id+" union select -1,description,amount,priceofsale from genericproducts where idorder="+order.id+"", "ordersproducts");

            DataTable table = data.Tables["ordersproducts"];

            OrderProducts aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new OrderProducts();

                aux.id= Convert.ToInt32(row["refproduct"]);
                aux.name = Convert.ToString(row["description"]);
                aux.priceSale = Convert.ToDouble(row["pricesale"]);
                aux.amountSale = Convert.ToInt32(row["amount"]);
                
                products.Add(aux);
            }
        }
        /// <summary>
        /// Inserts the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void insertOrder(Order order)
        {
            String total = Convert.ToString(order.total).Replace(",", ".");
            String prepaid = Convert.ToString(order.prepaid).Replace(",", ".");
            ConnectOracle Search = ConnectOracle.Instance;
            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idorder)", "orders", "")) + 1;
            Search.setData("Insert into orders values("+maximun+","+order.customer.id+","+order.user.iduser+ ",SYSDATE," + order.paymentmethod.id+","+total+","+prepaid+",0,"+order.confirmed+"," +order.labeled+ "," +order.sent+ "," +order.invoiced+")");
            order.id = maximun;
        }
        /// <summary>
        /// Inserts the order products.
        /// </summary>
        /// <param name="order">The order.</param>
        public void insertOrderProducts(Order order)
        {
            int id,maximunOP, maximunGP;
            String price;
            ConnectOracle Search = ConnectOracle.Instance;

            for (int i = 0; i < order.manage.products.Count; i++)
            {
                price = Convert.ToString(order.manage.products[i].priceSale).Replace(",", ".");
                maximunOP = Convert.ToInt32("0" + Search.DLookUp("max(idorderproduct)", "ordersproducts", "")) + 1;
                id = order.manage.products[i].id;

                if (id==-1)
                {
                    maximunGP = Convert.ToInt32("0" + Search.DLookUp("max(id)", "genericproducts", "")) + 1;
                    Search.setData("Insert into genericproducts values("+maximunGP+"," + order.id + ",'" + order.manage.products[i].name + "'," + order.manage.products[i].amountSale + "," + price + ")");
                }
                else
                {
                    Search.setData("Insert into ordersproducts values(" + maximunOP + "," + order.id + "," + order.manage.products[i].id + "," + order.manage.products[i].amountSale + "," + price + ")");
                }

            }
        }
        /// <summary>
        /// Modifies the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void modifyOrder(Order order)
        {
            String total = Convert.ToString(order.total).Replace(",", ".");
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update orders set refcustomer=" + order.customer.id + ",refuser=" + order.user.iduser + ",datetime=SYSDATE,refpaymentmethod=" + order.paymentmethod.id + ",total= " +total+ ",prepaid= " + order.prepaid + ",confirmed=" + order.confirmed + ",labeled=" + order.labeled + ",sent=" + order.sent + ",invoiced=" + order.invoiced + " where idorder=" + order.id+"");
        }
        /// <summary>
        /// Modifies the order status.
        /// </summary>
        /// <param name="order">The order.</param>
        public void modifyOrderStatus(Order order)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update orders set confirmed= " + order.confirmed + ",labeled= " + order.labeled + ",sent= " + order.sent+ ",invoiced= " + order.invoiced + " where idorder=" + order.id);
        }
        /// <summary>
        /// Deletes the order products.
        /// </summary>
        /// <param name="order">The order.</param>
        public void deleteOrderProducts(Order order)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Delete from ordersproducts where reforder=" + order.id);
            Search.setData("Delete from genericproducts where idorder=" + order.id);
        }
        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void deleteOrder(Order order)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update orders set deleted=1 where idorder=" + order.id);
        }
        /// <summary>
        /// Reads the paymentmethod.
        /// </summary>
        /// <param name="p">The p.</param>
        public void readPaymentmethod(Paymentmethods p)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Paymentmethods where idpaymentmethod=" + p.id, "Paymentmethods");

            DataTable table = data.Tables["Paymentmethods"];
            DataRow row = table.Rows[0];
            p.name = Convert.ToString(row["Paymentmethod"]);
        }
        /// <summary>
        /// Loads the paymentmethods and put them in a list.
        /// </summary>
        public void loadPaymentmethods()
        {
            Paymentmethods p;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select * from Paymentmethods", "Paymentmethods");
            DataTable table = data.Tables["Paymentmethods"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idpaymentmethod"]);
                name = Convert.ToString(row["Paymentmethod"]);
                p = new Paymentmethods(id, name);
                paymentmethods.Add(p);
            }
        }
        /// <summary>
        /// Searches the order.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchOrder(String filtro)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select o.idorder,o.refcustomer,o.refuser,o.datetime,o.refpaymentmethod ,o.total,o.prepaid,o.confirmed,o.labeled,o.sent,o.invoiced from orders o,paymentmethods p where o.deleted=0 and o.refpaymentmethod=p.idpaymentmethod and p.paymentmethod like '%" + filtro+ "%' order by o.idorder desc", "orders");

            DataTable table = data.Tables["orders"];

            Order aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Order();
                aux.id = Convert.ToInt32(row["Idorder"]);
                aux.customer = new Customer(Convert.ToInt32(row["refcustomer"]));
                aux.customer.readCustomer();
                aux.user = new User(Convert.ToInt32(row["refuser"]));
                aux.date = Convert.ToDateTime(row["datetime"]);
                aux.paymentmethod = new Paymentmethods(Convert.ToInt32(row["refpaymentmethod"]));
                aux.paymentmethod.readPaymentmethod();
                aux.total = Convert.ToDouble(row["total"]);
                aux.prepaid = Convert.ToDouble(row["prepaid"]);
                aux.confirmed = Convert.ToInt32(row["confirmed"]);
                aux.labeled = Convert.ToInt32(row["labeled"]);
                aux.sent = Convert.ToInt32(row["sent"]);
                aux.invoiced = Convert.ToInt32(row["invoiced"]);


                list.Add(aux);
            }
        }
        /// <summary>
        /// Reads all invoices and put them in a list.
        /// </summary>
        public void readAllInvoices()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            List<Invoice> sorted;

            data = Search.getData("Select * from invoices where deleted=0", "invoices");

            DataTable table = data.Tables["invoices"];

            Invoice aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Invoice();
                aux.id = Convert.ToInt32(row["id"]);
                aux.readIdorderInvoice();
                aux.order.readOrder();
                aux.date = Convert.ToDateTime(row["dateinvoice"]);
                aux.accounted = Convert.ToInt32(row["accounted"]);

                invoices.Add(aux);
            }
            sorted = invoices.OrderByDescending(x => x.id).ToList();
            invoices = sorted;
        }
        /// <summary>
        /// Reads the idorder invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void readIdorderInvoice(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select idorder from order_invoice where idinvoice="+invoice.id+"", "order_invoice");

            DataTable table = data.Tables["order_invoice"];
            DataRow row = table.Rows[0];
            invoice.order =new Order( Convert.ToInt32(row["idorder"]));
        }
        /// <summary>
        /// Reads the identifier invoice order.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void readIdInvoiceOrder(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select idinvoice from order_invoice where idorder=" + invoice.order.id + "", "order_invoice");

            DataTable table = data.Tables["order_invoice"];
            DataRow row = table.Rows[0];
            invoice.id = Convert.ToInt32(row["idinvoice"]);
        }
        /// <summary>
        /// Checks the order invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        public Boolean checkOrderInvoice(Invoice invoice)
        {
            Boolean found = false;
            ConnectOracle Search = ConnectOracle.Instance;
            int count = Convert.ToInt32(Search.DLookUp("count(idorder)", "order_invoice", "idorder=" + invoice.order.id + ""));
            if (count == 1)
                found = true;
            return found;
        }
        /// <summary>
        /// Modifies the accounted.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void modifyAccounted(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update invoices set accounted="+invoice.accounted+" where id=" + invoice.id);
        }
        /// <summary>
        /// Inserts the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void insertInvoice(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(id)", "idtable", "")) + 1;
            invoice.id = maximun;
            Search.setData("Insert into invoices values(" + maximun + ",SYSDATE,0,0)");
            Search.setData("Update idtable set id=id+1");
        }
        /// <summary>
        /// Inserts the order invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void insertOrderInvoice(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Insert into order_invoice values("+invoice.order.id+","+invoice.id+")");
        }
        /// <summary>
        /// Accounts the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void accountInvoice(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update invoices set accounted=1 where id="+invoice.id+"");
        }

        /// <summary>
        /// Deletes the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void deleteInvoice(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update invoices set deleted=1 where id=" + invoice.id);
        }
        /// <summary>
        /// Recovers the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void recoverInvoice(Invoice invoice)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update invoices set deleted=0 where id=" + invoice.id);
        }
        /// <summary>
        /// Reads the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void readOrder(Order order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from orders where idorder="+order.id+"", "orders");

            DataTable table = data.Tables["orders"];

            DataRow row = table.Rows[0];

            order.customer = new Customer(Convert.ToInt32(row["refcustomer"]));
            order.customer.readCustomer();
            order.user = new User(Convert.ToInt32(row["refuser"]));
            order.date = Convert.ToDateTime(row["datetime"]);
            order.paymentmethod = new Paymentmethods(Convert.ToInt32(row["refpaymentmethod"]));
            order.paymentmethod.readPaymentmethod();
            order.total = Convert.ToDouble(row["total"]);
            order.prepaid = Convert.ToDouble(row["prepaid"]);
            order.confirmed = Convert.ToInt32(row["confirmed"]);
            order.labeled = Convert.ToInt32(row["labeled"]);
            order.sent = Convert.ToInt32(row["sent"]);
            order.invoiced = Convert.ToInt32(row["invoiced"]);
             
        }
        /// <summary>
        /// Loads the table data invoices.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void loadTableDataInvoices(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT O.TOTAL,OI.IDINVOICE,C.NIF,C.NAME,C.SURNAME,C.ADDRESS FROM ORDER_INVOICE OI, CUSTOMERS C, ORDERS O WHERE OI.IDORDER = "+ invoice.order.id+" AND C.IDCUSTOMER = O.REFCUSTOMER AND O.IDORDER = OI.IDORDER", "orders");

            DataTable tmp = data.Tables["orders"];
            
            tinvoices.Columns.Add("Total", Type.GetType("System.String"));
            tinvoices.Columns.Add("Idinvoice", Type.GetType("System.String"));
            tinvoices.Columns.Add("Nif", Type.GetType("System.String"));
            tinvoices.Columns.Add("Name", Type.GetType("System.String"));
            tinvoices.Columns.Add("Surname", Type.GetType("System.String"));
            tinvoices.Columns.Add("Address", Type.GetType("System.String"));

            foreach (DataRow row in tmp.Rows)
            {
                tinvoices.Rows.Add(new Object[] { row["Total"], row["Idinvoice"], row["Nif"], row["Name"], row["Surname"], row["Address"] });
            }
        }
        /// <summary>
        /// Loads the table products invoices.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void loadTableProductsInvoices(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("select p.description,o.amount,o.pricesale from products p,ordersproducts o where p.idproduct=o.refproduct and o.reforder="+ invoice.order.id + " union select description, amount, priceofsale from genericproducts where idorder = "+ invoice.order.id + "", "ordersproducts");

            DataTable tmp = data.Tables["ordersproducts"];


            tProductsinvoices.Columns.Add("Description", Type.GetType("System.String"));
            tProductsinvoices.Columns.Add("Amount", Type.GetType("System.String"));
            tProductsinvoices.Columns.Add("Pricesale", Type.GetType("System.String"));

            foreach (DataRow row in tmp.Rows)
            {
                tProductsinvoices.Rows.Add(new Object[] { row["Description"], row["Amount"], row["Pricesale"] });
            }


        }
        /// <summary>
        /// Inserts to fill.
        /// </summary>
        /// <param name="order">The order.</param>
        public void insertToFill(Order order)
        {
            String price;
            String total = Convert.ToString(order.total).Replace(",", ".");
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Insert into orders values(" + order.id + "," + order.customer.id + "," + order.user.iduser + ",SYSDATE," + order.paymentmethod.id + "," + total + "," + order.prepaid + ",0," + order.confirmed + "," + order.labeled + "," + order.sent + "," + order.invoiced + ")");

            for (int i = 0; i < order.manage.products.Count; i++)
            {
                price = Convert.ToString(order.manage.products[i].priceSale).Replace(",", ".");
                
                Search.setData("Insert into ordersproducts values(" + order.id + "," + order.id + "," + order.manage.products[i].id + "," + order.manage.products[i].amountSale + "," + price + ")");
            }
        }
    }
}
