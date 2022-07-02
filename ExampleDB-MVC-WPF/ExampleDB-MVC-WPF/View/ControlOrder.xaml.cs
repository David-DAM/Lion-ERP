using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ExampleDB_MVC_WPF.Domain;
using MahApps.Metro.Controls;

namespace ExampleDB_MVC_WPF.View
{
    /// <summary>
    /// Lógica de interacción para ControlOrder.xaml
    /// </summary>
    public partial class ControlOrder : MetroWindow
    {
        Order order;
        Customer customerOrder;
        Product productOrder;
        User user;
        Invoice invoice;
        Boolean newOrder=false,newInvoice=false;
        String lang;
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlOrder"/> class to create a new order.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="invoice">if set to <c>true</c> [invoice].</param>
        public ControlOrder(User user,Boolean invoice,String languaje)
        {
            lang = languaje;
            InitializeComponent();
            order = new Order();
            this.user = user;
            newOrder = true;
            newInvoice = invoice;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);
            changeLanguaje();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlOrder"/> class to modify the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="user">The user.</param>
        public ControlOrder(Order order,User user, String languaje)
        {
            InitializeComponent();
            this.order = order;
            this.user = user;
            fillData();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);
            changeLanguaje();
        }
        /// <summary>
        /// Changes the languaje.
        /// </summary>
        public void changeLanguaje()
        {
            lblCustomer.Content = Res.Cliente;
            lblPaymentMethod.Content = Res.MetodoPago;
            lblPrepaid.Content = Res.Pagado;
            lblProduct.Content = Res.Producto;
            lblPrice.Content = Res.Precio;
            lblAmount.Content = Res.Cantidad;
            btnSearchCustomer.Content = Res.Buscar;
            btnSearchProduct.Content = Res.Buscar;
            btnAddProduct.Content = Res.Añadir;
            btnAddGenericProduct.Content = Res.AñadirOtro;
            btnDelteProduct.Content = Res.Borrar;
            btnSaveList.Content = Res.Guardar;
            btnCancel.Content = Res.Cerrar;
            btnSaveOrder.Content = Res.Guardar;
            dgtcName.Header = Res.Nombre;
            dgtcPrice.Header = Res.Precio;
            dgtcAmount.Header = Res.Cantidad;
        }

        /// <summary>
        /// Fills the data.
        /// </summary>
        public void fillData()
        {
            txbClient.Text = order.customer.name;
            cmbPaymenthmethod.SelectedItem = order.paymentmethod;
            txbPrepaid.Text = Convert.ToString(order.prepaid);

            order.readOrderProducts();
            dgvProductsOrder.ItemsSource = order.manage.products;
        }
        /// <summary>
        /// Handles the Initialized event of the cmbPaymenthmethod control to add the paymenthmethods.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbPaymenthmethod_Initialized(object sender, EventArgs e)
        {
            Paymentmethods p = new Paymentmethods();
            p.loadPaymentmethod();
            cmbPaymenthmethod.ItemsSource = p.manage.paymentmethods;
        }
        /// <summary>
        /// Handles the Click event of the btnCancel control to close the window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="c">The c.</param>
        public void getCustomer(Customer c)
        {
            customerOrder = c;
            txbClient.Text = c.name;
        }
        /// <summary>
        /// Handles the Click event of the btnSearchCustomer control to select a customer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            Tabcontrol tabcontrol=new Tabcontrol(1,lang);

            tabcontrol.getValueCustomer = getCustomer;

            tabcontrol.ShowDialog();

        }
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="p">The p.</param>
        public void getProduct(Product p)
        {
            productOrder = p;
            txbProduct.Text = p.name;
            txbPrice.Text = Convert.ToString(p.price);
        }
        /// <summary>
        /// Handles the Click event of the btnSearchProduct control to select a product.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            Tabcontrol tabcontrol = new Tabcontrol(2,lang);

            tabcontrol.getValueProduct = getProduct;

            tabcontrol.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the btnDelteProduct control to delete a product from the datagrid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDelteProduct_Click(object sender, RoutedEventArgs e)
        {
            int indice = 0;

            if (dgvProductsOrder.SelectedItems.Count > 0)
            {
               
                for (int i = 0; i < dgvProductsOrder.SelectedItems.Count; i++)
                {
                    indice = dgvProductsOrder.Items.IndexOf(dgvProductsOrder.SelectedItems[i]);
                    
                    order.manage.products.RemoveAt(indice);
                    
                }
                dgvProductsOrder.ItemsSource = null;
                dgvProductsOrder.ItemsSource = order.manage.products;

            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Handles the Click event of the btnAddProduct control to clear the data to add a new product.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            txbProduct.Clear();
            txbProduct.Visibility = Visibility.Visible;
            lblProduct.Visibility = Visibility.Visible;

            txbDescription.Clear();
            txbDescription.IsEnabled = false;
            txbDescription.Visibility = Visibility.Hidden;
            lblGenericProduct.Visibility = Visibility.Hidden;

            txbPrice.Clear();
            txbPrice.IsEnabled = true;

            txbAmount.Clear();
            txbAmount.IsEnabled = true;

            btnSaveList.IsEnabled = true;
            btnSearchProduct.IsEnabled = true;
            btnSearchProduct.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Handles the Click event of the btnAddGenericProduct control to clear the data to add a new generic product.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddGenericProduct_Click(object sender, RoutedEventArgs e)
        {
            txbProduct.Clear();
            txbProduct.Visibility = Visibility.Hidden;
            lblProduct.Visibility = Visibility.Hidden;

            txbDescription.Clear();
            txbDescription.IsEnabled = true;
            txbDescription.Visibility = Visibility.Visible;
            lblGenericProduct.Visibility = Visibility.Visible;

            txbPrice.Clear();
            txbPrice.IsEnabled = true;

            txbAmount.Clear();
            txbAmount.IsEnabled = true;

            btnSaveList.IsEnabled = true;
            btnSearchProduct.IsEnabled = false;
            btnSearchProduct.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Handles the Click event of the btnSaveList control to save a product in a list to orderproducts.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSaveList_Click(object sender, RoutedEventArgs e)
        {
            OrderProducts products = new OrderProducts();
            OrderProducts aux =(OrderProducts)dgvProductsOrder.SelectedItem;

            if (productOrder==null && aux==null)
            {
                products.id = -1;
                products.name = txbDescription.Text;
            }
            else if (aux!=null && aux.id!=-1)
            {
                products.id = aux.id;
                products.name = txbProduct.Text;
            }
            else if (aux != null && aux.id == -1)
            {
                products.id = aux.id;
                products.name = txbDescription.Text;
            }
            else
            {
                products.id = productOrder.id;
                products.name = productOrder.name;
            }
            
            products.priceSale = Convert.ToDouble(txbPrice.Text);
            products.amountSale = Convert.ToInt32(txbAmount.Text);

            if (aux!=null)
            {
                order.manage.products.Remove(aux);
                order.manage.products.Add(products);
            }
            else
            {
                order.manage.products.Add(products);
            }

            dgvProductsOrder.ItemsSource = null;
            dgvProductsOrder.ItemsSource = order.manage.products;

            productOrder = null;

            txbProduct.Clear();
            txbDescription.Clear();
            txbPrice.Clear();
            txbAmount.Clear();

        }
        /// <summary>
        /// Handles the Click event of the btnSaveOrder control to create or modify the order.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (customerOrder!=null)
            {
                order.customer = customerOrder;
            }

            order.user =user;
            order.date = DateTime.Now;
            order.paymentmethod = (Paymentmethods)cmbPaymenthmethod.SelectedItem;
            order.total =calculateTotal();

            if (txbPrepaid.Text.Equals(""))
            {
                order.prepaid = 0;
            }
            else
            {
                order.prepaid = Convert.ToDouble(txbPrepaid.Text);
            }
            
            order.delete =0;

            if (newInvoice)
            {
                order.confirmed = 1;
                order.labeled = 1;
                order.sent = 1;
                order.invoiced = 1;
            }
            else
            {
                if (order.paymentmethod.id == 2)
                {
                    order.confirmed = 1;
                }
                else
                {
                    order.confirmed = 0;
                }

                order.labeled = 0;
                order.sent = 0;
                order.invoiced = 0;
            }

            if ( order.user!=null && order.customer!=null && order.paymentmethod!=null && order.total>order.prepaid)
            {
                if (newOrder)
                {
                    order.insertOrder();
                    order.insertOrderProducts();

                    if (newInvoice)
                    {
                        invoice = new Invoice();
                        invoice.order = order;

                        invoice.insertInvoice();
                        invoice.insertOrderInvoice();
                    }
                }
                else
                {
                    order.modifyOrder();
                    order.deleteOrderProducts();
                    order.insertOrderProducts();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Enter the correct data");
            }
        }
        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <returns></returns>
        public double calculateTotal()
        {
            double total = 0.00;

            for (int i = 0; i < order.manage.products.Count; i++)
            {
                total += order.manage.products[i].priceSale * order.manage.products[i].amountSale;
            }

            return total;
        }
        /// <summary>
        /// Handles the KeyDown event of the txbPrice control to check that only numbers are allowed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void txbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dgvProductsOrder control to fill the data with the selected product.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgvProductsOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderProducts products = (OrderProducts)dgvProductsOrder.SelectedItem;
            if (products!=null)
            {
                if (products.id != -1)
                {
                    txbProduct.Text = products.name;
                    txbProduct.Visibility = Visibility.Visible;
                    lblProduct.Visibility = Visibility.Visible;

                    txbDescription.Clear();
                    txbDescription.IsEnabled = false;
                    txbDescription.Visibility = Visibility.Hidden;
                    lblGenericProduct.Visibility = Visibility.Hidden;

                    btnSearchProduct.IsEnabled = true;
                    btnSearchProduct.Visibility = Visibility.Visible;
                }
                else
                {
                    txbProduct.Clear();
                    txbProduct.Visibility = Visibility.Hidden;
                    lblProduct.Visibility = Visibility.Hidden;

                    txbDescription.Text = products.name;
                    txbDescription.IsEnabled = true;
                    txbDescription.Visibility = Visibility.Visible;
                    lblGenericProduct.Visibility = Visibility.Visible;

                    btnSearchProduct.IsEnabled = false;
                    btnSearchProduct.Visibility = Visibility.Hidden;
                }


                txbPrice.Text = Convert.ToString(products.priceSale);
                txbPrice.IsEnabled = true;

                txbAmount.Text = Convert.ToString(products.amountSale); ;
                txbAmount.IsEnabled = true;

                btnSaveList.IsEnabled = true;
            }
        }
    }
}
