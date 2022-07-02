using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class IncidentManage
    {
        public List<Incident> incidents { get; set; }
        public List<IncidentType> types { get; set; }
        public List<Product> dataProduct { get; set; }
        public List<Product> dataProductReturned { get; set; }
        public List<Product> dataProductDefective { get; set; }
        public DataTable tincidents { get; set; }

        public IncidentManage()
        {
            incidents = new List<Incident>();
            types = new List<IncidentType>();
            dataProduct = new List<Product>();
            dataProductReturned = new List<Product>();
            dataProductDefective = new List<Product>();
            tincidents = new DataTable();
        }
        /// <summary>
        /// Reads all the incidents.
        /// </summary>
        public void readAll()
        {
            List<Incident> sorted;
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from incidents", "incidents");

            DataTable table = data.Tables["incidents"];

            Incident aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Incident();
                aux.id = Convert.ToInt32(row["id"]);
                aux.order = new Order(Convert.ToInt32(row["id_order"]));
                aux.order.readOrder();
                aux.product = new Product(Convert.ToInt32(row["id_product"]));
                aux.product.readProduct();
                aux.type = new IncidentType(Convert.ToInt32(row["id_incident_type"]));
                aux.type.readType();
                aux.solved = Convert.ToInt32(row["solved"]);

                incidents.Add(aux);
            }
            sorted = incidents.OrderByDescending(x => x.id).ToList();
            incidents = sorted;
        }
        /// <summary>
        /// Loads the table data incidents.
        /// </summary>
        public void loadTableDataIncidents()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT I.ID Id,p.description Product,il.name Type,I.SOLVED Solved FROM INCIDENTS I,PRODUCTS P,INCIDENT_LIST IL WHERE i.id_incident_type=il.id AND i.id_product=p.idproduct  ORDER BY I.ID DESC", "incidents");

            DataTable tmp = data.Tables["incidents"];

            tincidents.Columns.Add("Id", Type.GetType("System.String"));
            tincidents.Columns.Add("Product", Type.GetType("System.String"));
            tincidents.Columns.Add("Type", Type.GetType("System.String"));
            tincidents.Columns.Add("Solved", Type.GetType("System.String"));

            foreach (DataRow row in tmp.Rows)
            {
                tincidents.Rows.Add(new Object[] { row["Id"], row["Product"], row["Type"], row["Solved"] });
            }
        }
        /// <summary>
        /// Reads all the types of incidents.
        /// </summary>
        public void readAllTypesIncidents()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from incident_list", "incident_list");

            DataTable table = data.Tables["incident_list"];

            IncidentType aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new IncidentType();
                aux.id = Convert.ToInt32(row["id"]);
                aux.name = Convert.ToString(row["name"]);
                aux.description = Convert.ToString(row["description"]);

                if (Convert.ToInt32(row["payment_responsability"])==1)
                {
                    aux.responsability = true;
                }
                else
                {
                    aux.responsability = false;
                }
                
                types.Add(aux);
            }   
        }
        /// <summary>
        /// Reads the incident types.
        /// </summary>
        /// <param name="type">The type.</param>
        public void readIncidentTypes(IncidentType type)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from incident_list where id="+type.id+"", "incident_list");

            DataTable table = data.Tables["incident_list"];
            DataRow row = table.Rows[0];
            type.name = Convert.ToString(row["name"]);
            type.description = Convert.ToString(row["description"]);
            if (Convert.ToInt32(row["payment_responsability"]) == 1)
            {
                type.responsability = true;
            }
            else
            {
                type.responsability = false;
            }
        }
        /// <summary>
        /// Fixes the incident.
        /// </summary>
        /// <param name="incident">The incident.</param>
        public void fixIncident(Incident incident)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update incidents set solved=1 where id=" + incident.id + "");
        }
        /// <summary>
        /// Get the products that have more incidents.
        /// </summary>
        public void productMoreIncidents()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT COUNT(ID_PRODUCT) RECOUNT,p.description FROM INCIDENTS I,PRODUCTS P WHERE I.ID_PRODUCT=P.IDPRODUCT GROUP BY I.ID_PRODUCT,P.DESCRIPTION", "incidents");

            DataTable table = data.Tables["incidents"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product();
                aux.id = Convert.ToInt32(row["recount"]);
                aux.name = Convert.ToString(row["description"]);

                dataProduct.Add(aux);
            }
        }
        /// <summary>
        /// Get the products most returned.
        /// </summary>
        public void productMostReturned()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT COUNT(ID_PRODUCT) RECOUNT,p.description FROM INCIDENTS I,PRODUCTS P WHERE I.ID_PRODUCT=P.IDPRODUCT AND I.ID_INCIDENT_TYPE=3 GROUP BY I.ID_PRODUCT,P.DESCRIPTION", "incidents");

            DataTable table = data.Tables["incidents"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product();
                aux.id = Convert.ToInt32(row["recount"]);
                aux.name = Convert.ToString(row["description"]);

                dataProductReturned.Add(aux);
            }
        }
        /// <summary>
        /// Get the products most defective.
        /// </summary>
        public void productMostDefective()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT COUNT(ID_PRODUCT) RECOUNT,p.description FROM INCIDENTS I,PRODUCTS P WHERE I.ID_PRODUCT=P.IDPRODUCT AND I.ID_INCIDENT_TYPE=6 GROUP BY I.ID_PRODUCT,P.DESCRIPTION", "incidents");

            DataTable table = data.Tables["incidents"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product();
                aux.id = Convert.ToInt32(row["recount"]);
                aux.name = Convert.ToString(row["description"]);

                dataProductDefective.Add(aux);
            }
        }
        /// <summary>
        /// Orderses the responsability incidents business.
        /// </summary>
        /// <returns></returns>
        public int ordersResponsabilityIncidentsBusiness()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT COUNT(*) count FROM INCIDENTS I,incident_list il WHERE il.payment_responsability=0 and i.id_incident_type=il.id", "incidents");

            DataTable table = data.Tables["incidents"];

            int count=0;

            foreach (DataRow row in table.Rows)
            {
                count= Convert.ToInt32(row["count"]);
            }

            return count;
        }
        /// <summary>
        /// Orderses the responsability incidents customer.
        /// </summary>
        /// <returns></returns>
        public int ordersResponsabilityIncidentsCustomer()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT COUNT(*) count FROM INCIDENTS I,incident_list il WHERE il.payment_responsability=1 and i.id_incident_type=il.id", "incidents");

            DataTable table = data.Tables["incidents"];

            int count = 0;

            foreach (DataRow row in table.Rows)
            {
                count = Convert.ToInt32(row["count"]);
            }

            return count;
        }
        /// <summary>
        /// Get the total money of the incidents responsability.
        /// </summary>
        /// <returns></returns>
        public double moneyIncidentsResponsability()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("SELECT SUM(p.price) count FROM INCIDENTS I,products p,incident_list il WHERE i.id_product=p.idproduct and i.id_incident_type=il.id and il.payment_responsability=0", "incidents");

            DataTable table = data.Tables["incidents"];

            double count = 0.00;

            foreach (DataRow row in table.Rows)
            {
                count = Convert.ToDouble(row["count"]);
            }

            return count;
        }
    }
}
