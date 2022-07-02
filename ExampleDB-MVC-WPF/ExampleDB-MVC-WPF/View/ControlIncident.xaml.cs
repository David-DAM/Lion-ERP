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
    /// Lógica de interacción para ControlIncident.xaml
    /// </summary>
    public partial class ControlIncident : MetroWindow
    {
        Incident incident;
        public ControlIncident(Incident i,String languaje)
        {
            InitializeComponent();
            incident = i;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);

            changeLanguaje();

            checks();

        }
        /// <summary>
        /// Check the type of responsability.
        /// </summary>
        public void checks()
        {
            if (incident.type.responsability == true)
            {
                responsability();
            }
            else
            {
                noResponsability();
            }

            if (incident.solved == 1)
            {
                btnFix.Visibility = Visibility.Hidden;
            }

            txbProduct.Text = incident.product.name;
            txbDescription.Text = incident.type.description;

            incident.order.readOrderProducts();
            dgvProductsOrder.ItemsSource = incident.order.manage.products;
        }
        /// <summary>
        /// Changes the languaje.
        /// </summary>
        public void changeLanguaje()
        {
            lblProduct.Content = Res.Producto;
            lblDescription.Content = Res.DescripcionIncidencia;
            lblOrder.Content = Res.ProductosPedido;
            lblResponsability.Content = Res.ResponsabilidadPagoCliente;
            dgtcAmount.Header = Res.Cantidad;
            dgtcName.Header = Res.Descripción;
            dgtcPrice.Header = Res.Precio;
            btnCancel.Content = Res.Cerrar;
            btnFix.Content = Res.EnviarProducto;

        }
        /// <summary>
        /// Change the color to green.
        /// </summary>
        public void responsability()
        {
            txbResponsability.Background = Brushes.Green;
        }
        /// <summary>
        /// Change the color to red.
        /// </summary>
        public void noResponsability()
        {
            txbResponsability.Background = Brushes.Red;
        }
        /// <summary>
        /// Handles the Click event of the btnFix control to fix the incident.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFix_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            OrderProducts product = new OrderProducts();
            Invoice invoice = new Invoice();

            order = incident.order;
            
            order.total = incident.product.price;

            order.prepaid = incident.product.price;
            
            order.confirmed = 1;
            order.labeled = 1;
            order.sent = 1;
            order.invoiced = 1;

            order.insertOrder();

            product.id = incident.product.id;
            product.product = incident.product;
            product.name = incident.product.name;
            product.priceSale = incident.product.price;
            product.amountSale = 1;

            order.manage.products.Add(product);

            order.insertOrderProducts();
           
            invoice.order = order;

            invoice.insertInvoice();
            invoice.insertOrderInvoice();

            incident.fixIncident();

            this.Close();
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
    }
}
