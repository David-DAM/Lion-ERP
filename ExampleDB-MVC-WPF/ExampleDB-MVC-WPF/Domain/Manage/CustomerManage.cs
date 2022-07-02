using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class CustomerManage
    {
        public List<Customer> list { get; set; }
        public List<Region> regions { get; set; }
        public List<State> states { get; set; }
        public List<City> cities { get; set; }
        public List<Zipcode> zipcodes { get; set; }

        public CustomerManage()
        {
            list = new List<Customer>();
            regions = new List<Region>();
            states = new List<State>();
            cities = new List<City>();
            zipcodes = new List<Zipcode>();
        }
        /// <summary>
        /// Reads all and added to a list.
        /// </summary>
        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from first100customers", "customers");

            DataTable table = data.Tables["customers"];

            Customer aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Customer();
                aux.id= Convert.ToInt32(row["Idcustomer"]);
                aux.name= Convert.ToString(row["Name"]);
                aux.surname= Convert.ToString(row["Surname"]);
                aux.adress= Convert.ToString(row["Address"]);
                aux.phone= Convert.ToString(row["Phone"]);
                aux.email= Convert.ToString(row["Email"]);
                aux.nif= Convert.ToString(row["Nif"]);
                aux.idzipcodescities =Convert.ToInt32(row["Refzipcodescities"]);

                list.Add(aux);
            }
        }
        /// <summary>
        /// Gets the name of the zipcode.
        /// </summary>
        /// <param name="refzipcode">The refzipcode.</param>
        /// <returns></returns>
        public int getZipcodeName(int refzipcode)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select zipcode from zipcodes where idzipcode=" + refzipcode + "", "zipcodes");

            DataTable table = data.Tables["zipcodes"];
            DataRow row = table.Rows[0];
            return Convert.ToInt32(row["zipcode"]);
        }

        /// <summary>
        /// Gets the zipcode.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public int getZipcode(Customer customer)
        {
            int refzipcode;
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select refzipcode from zipcodescities where idzipcodescities="+customer.idzipcodescities+"", "zipcodescities");

            DataTable table = data.Tables["zipcodescities"];
            DataRow row = table.Rows[0];
            refzipcode=Convert.ToInt32(row["refzipcode"]);

            return customer.getZipcodeName(refzipcode);
        }

        /// <summary>
        /// Gets the zipcode cities.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public void getZipcodeCities(Customer customer)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select idzipcodescities from zipcodescities where refcity="+customer.cities.id+" and refstate="+customer.state.id+" and refzipcode="+customer.zipcode.id+"", "zipcodescities");

            DataTable table = data.Tables["zipcodescities"];
            DataRow row = table.Rows[0];
            customer.idzipcodescities= Convert.ToInt32(row["idzipcodescities"]);
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void insertCustomer(Customer customer)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idcustomer)", "customers", "")) + 1;
            Search.setData("Insert into customers values (" + maximun + ",'" + customer.name + "','" + customer.surname + "','" + customer.adress + "','" + customer.phone + "','" + customer.email + "',0," + customer.idzipcodescities + ",'" + customer.nif + "')");
            customer.id = maximun;
        }
        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void deleteCustomer(Customer customer)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update Customers set deleted=1 where idcustomer=" + customer.id);
        }
        /// <summary>
        /// Modifies the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void modifyCustomer(Customer customer)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update Customers set name= '" + customer.name + "',surname= '" +customer.surname+ "',address= '" + customer.adress + "',phone= '" + customer.phone + "',email= '" + customer.email + "',refzipcodescities= " + customer.idzipcodescities + ",nif= '" + customer.nif + "' where idcustomer=" + customer.id);
        }
        /// <summary>
        /// Reads the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void readCustomer(Customer customer)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from customers where idcustomer=" + customer.id, "customers");

            DataTable table = data.Tables["customers"];
            DataRow row = table.Rows[0];
            customer.name = Convert.ToString(row["name"]);
        }

        /// <summary>
        /// Reads the region.
        /// </summary>
        /// <param name="region">The region.</param>
        public void readRegion(Region region)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from regions where idregion=" + region.id, "regions");

            DataTable table = data.Tables["regions"];
            DataRow row = table.Rows[0];
            region.name = Convert.ToString(row["region"]);
        }
        /// <summary>
        /// Reads the state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void readState(State state)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from states where idstate=" + state.id, "states");

            DataTable table = data.Tables["states"];
            DataRow row = table.Rows[0];
            state.name = Convert.ToString(row["state"]);
        }
        /// <summary>
        /// Reads the city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void readCity(City city)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from cities where idcity=" + city.id, "cities");

            DataTable table = data.Tables["cities"];
            DataRow row = table.Rows[0];
            city.name = Convert.ToString(row["city"]);
        }
        /// <summary>
        /// Reads the zipcode.
        /// </summary>
        /// <param name="zipcode">The zipcode.</param>
        public void readZipcode(Zipcode zipcode)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from zipcodes where zipcode='" + zipcode.name+"'", "zipcodes");

            DataTable table = data.Tables["zipcodes"];
            DataRow row = table.Rows[0];
            zipcode.id = Convert.ToInt32(row["idzipcode"]);
        }
        /// <summary>
        /// Loads the regions and added to a list.
        /// </summary>
        public void loadRegions()
        {
            Region r1;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select * from regions", "regions");
            DataTable table = data.Tables["regions"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idregion"]);
                name = Convert.ToString(row["region"]);
                r1 =new Region(id,name);
                regions.Add(r1);
            }
        }
        /// <summary>
        /// Loads the states of one region and added to a list.
        /// </summary>
        /// <param name="refreg">The refreg.</param>
        public void loadStates(int refreg)
        {
            State s1;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select * from states where refregion="+refreg+"", "states");
            DataTable table = data.Tables["states"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idstate"]);
                name = Convert.ToString(row["state"]);
                s1 = new State(id, name);
                states.Add(s1);
            }
        }
        /// <summary>
        /// Loads the cities of one state and added to a list.
        /// </summary>
        /// <param name="refstate">The refstate.</param>
        public void loadCities(int refstate)
        {
            City c1;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select  c.idcity,c.city from cities c,zipcodescities z where z.refstate="+refstate+" and z.refcity=c.idcity", "cities");
            DataTable table = data.Tables["cities"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idcity"]);
                name = Convert.ToString(row["city"]);
                c1 = new City(id, name);
                cities.Add(c1);
            }
        }
        /// <summary>
        /// Loads the zipcodes of one city and added to a list.
        /// </summary>
        /// <param name="refcity">The refcity.</param>
        public void loadZipcodes(int refcity)
        {
            Zipcode z1;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select z.idzipcode,z.zipcode from zipcodes z,zipcodescities zc where z.idzipcode=zc.refzipcode and zc.refcity="+refcity+"", "zipcodes");
            DataTable table = data.Tables["zipcodes"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idzipcode"]);
                name = Convert.ToString(row["zipcode"]);
                z1 = new Zipcode(id, name);
                zipcodes.Add(z1);
            }
        }
        /// <summary>
        /// Get the id of a region,state and city with a zipcode.
        /// </summary>
        /// <param name="zipcode">The zipcode.</param>
        /// <returns></returns>
        public int [] loadAllWithZipcode(String zipcode)
        {
            int [] refs= new int[3];
            int refstate,refregion,refcity;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select zc.refstate,s.refregion,zc.refcity from zipcodescities zc, states s, regions r, zipcodes z, cities c where zc.refstate = s.idstate and s.refregion = r.idregion and zc.refcity = c.idcity and zc.refzipcode = z.idzipcode and z.zipcode = '"+zipcode+"'", "zipcodescities");
            DataTable table = data.Tables["zipcodescities"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                refstate = Convert.ToInt32(row["refstate"]);
                refregion = Convert.ToInt32(row["refregion"]);
                refcity = Convert.ToInt32(row["refcity"]);
                refs[0]= refstate;
                refs[1] = refregion;
                refs[2] = refcity;
            }
            return refs;
        }
        /// <summary>
        /// Searches the customers and added to a list.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchCustomers(String filtro)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("select * from customers where deleted=0 and nif like '"+filtro+"%' or address like '%"+filtro+"%' or name like '"+filtro+ "%' order by idcustomer DESC", "customers");

            DataTable table = data.Tables["customers"];

            Customer aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Customer();
                aux.id = Convert.ToInt32(row["Idcustomer"]);
                aux.name = Convert.ToString(row["Name"]);
                aux.surname = Convert.ToString(row["Surname"]);
                aux.adress = Convert.ToString(row["Address"]);
                aux.phone = Convert.ToString(row["Phone"]);
                aux.email = Convert.ToString(row["Email"]);
                aux.nif = Convert.ToString(row["Nif"]);
                aux.idzipcodescities = Convert.ToInt32(row["Refzipcodescities"]);

                list.Add(aux);
            }
        }
        /// <summary>
        /// Inserts to fill.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void insertToFill(Customer customer)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Insert into customers values (" + customer.id + ",'" + customer.name + "','" + customer.surname + "','" + customer.adress + "','" + customer.phone + "','" + customer.email + "',0," + customer.idzipcodescities + ",'" + customer.nif + "')");
        }
    }
}
