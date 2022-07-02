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
    /// Lógica de interacción para PrintIncidents.xaml
    /// </summary>
    public partial class PrintIncidents : MetroWindow
    {
       
        public PrintIncidents()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Loaded event of the Grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Incident i = new Incident();
            i.loadDatatableIncidents();
            CrystalReportIncidents mireporte = new CrystalReportIncidents();
            mireporte.Database.Tables["Incidents"].SetDataSource(i.manage.tincidents);
            cr1.ViewerCore.ReportSource = mireporte;
        }
    }
}
