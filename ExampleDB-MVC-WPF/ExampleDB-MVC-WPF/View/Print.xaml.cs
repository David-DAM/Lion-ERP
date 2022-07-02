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
    /// Lógica de interacción para Print.xaml
    /// </summary>
    public partial class Print : MetroWindow
    {
        Invoice selected;
        /// <summary>
        /// Initializes a new instance of the <see cref="Print"/> class.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public Print(Invoice invoice)
        {
            InitializeComponent();
            selected = invoice;
        }
        /// <summary>
        /// Handles the Loaded event of the Grid control to load values in the Report.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            selected.loadTableDataInvoices();
            selected.loadTableProductsInvoices();
            
            CrystalReport1 mireporte = new CrystalReport1();
            mireporte.Database.Tables["Data"].SetDataSource(selected.manage.tinvoices);
            mireporte.Database.Tables["Products"].SetDataSource(selected.manage.tProductsinvoices);
            cr1.ViewerCore.ReportSource = mireporte;
            
        }
    }
}
