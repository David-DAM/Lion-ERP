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
    /// Lógica de interacción para DataIncidents.xaml
    /// </summary>
    public partial class DataIncidents : MetroWindow
    {
        public DataIncidents(String languaje)
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);
            changeLanguaje();
            chargeData();
        }
        /// <summary>
        /// Changes the languaje.
        /// </summary>
        public void changeLanguaje()
        {
            lblOrdersBusinessResponsability.Content = Res.IncidenciasCompañiaPedidos;
            lblMoneyResponsability.Content = Res.DineroGastadoIncidencias;
            lblOrdersCustomerResponsability.Content = Res.IncidenciasClientePedidos;
            lblProductsIncidents.Content = Res.Productos+" "+ Res.Incidencias;
            dgtcCountProduct.Header = Res.Cantidad;
            dgtcNameProduct.Header = Res.Nombre;
            lblProductsReturnes.Content = Res.ProductosMasDevueltos;
            dgtcCountProductReturned.Header = Res.Cantidad;
            dgtcNameProductReturned.Header = Res.Nombre;
            lblProductsDefectives.Content = Res.ProductosMasDefectuosos;
            dgtcCountProductDefectives.Header = Res.Cantidad;
            dgtcNameProductDefectives.Header = Res.Nombre;

        }
        /// <summary>
        /// Charges the data.
        /// </summary>
        public void chargeData()
        {
            Incident incident = new Incident();

            incident.getProductMoreIncident();

            dgvProductsIncidents.ItemsSource = incident.manage.dataProduct;

            txbCountOrdersResponsability.Text = incident.getOrdersResponsabilityBusiness().ToString();

            txbMoneyResponsability.Text = incident.getmoneyIncidentsResponsability().ToString()+"€";

            txbCountOrdersCustomerResponsability.Text = incident.getOrdersResponsabilityCustomer().ToString();

            incident.getProductMostReturned();

            dgvProductsReturned.ItemsSource = incident.manage.dataProductReturned;

            incident.getProductMostDefective();

            dgvProductsDefectives.ItemsSource = incident.manage.dataProductDefective;
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
