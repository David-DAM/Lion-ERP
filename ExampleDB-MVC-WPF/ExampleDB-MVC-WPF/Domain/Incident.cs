using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Incident
    {
        public int id { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
        public IncidentType type { get; set; }
        public int solved { get; set; }

        public IncidentManage manage { get; set; }

        public Incident()
        {
            manage = new IncidentManage();
        }
        public Incident(int id)
        {
            this.id = id;
            manage = new IncidentManage();
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
        /// <summary>
        /// Loads the datatable with incidents.
        /// </summary>
        public void loadDatatableIncidents()
        {
            manage.loadTableDataIncidents();
        }
        /// <summary>
        /// Fixes the incident.
        /// </summary>
        public void fixIncident()
        {
            manage.fixIncident(this);
        }
        /// <summary>
        /// Gets the product more incident.
        /// </summary>
        public void getProductMoreIncident()
        {
            manage.productMoreIncidents();
        }
        /// <summary>
        /// Gets the products most returned.
        /// </summary>
        public void getProductMostReturned()
        {
            manage.productMostReturned();
        }
        /// <summary>
        /// Gets the products most defectives.
        /// </summary>
        public void getProductMostDefective()
        {
            manage.productMostDefective();
        }
        /// <summary>
        /// Get count of the orders responsability by the company.
        /// </summary>
        /// <returns></returns>
        public int getOrdersResponsabilityBusiness()
        {
            return manage.ordersResponsabilityIncidentsBusiness();
        }
        /// <summary>
        ///  Get count of the orders responsability by the customer.
        /// </summary>
        /// <returns></returns>
        public int getOrdersResponsabilityCustomer()
        {
            return manage.ordersResponsabilityIncidentsCustomer();
        }
        /// <summary>
        /// Get the money of the incidents responsability by the company.
        /// </summary>
        /// <returns></returns>
        public double getmoneyIncidentsResponsability()
        {
            return manage.moneyIncidentsResponsability();
        }
    }
}
