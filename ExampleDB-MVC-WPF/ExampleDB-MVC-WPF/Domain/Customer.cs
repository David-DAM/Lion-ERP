using ExampleDB_MVC_WPF.Domain.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Customer
    {
        public int id { get; set; }
        public State state { get; set; }
        public Region region { get; set; }
        public City cities { get; set; }
        public Zipcode zipcode { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String nif { get; set; }
        public String adress { get; set; }
        public int idzipcodescities { get; set; }

        public CustomerManage manage { get; set; }

        public Customer()
        {
            manage = new CustomerManage();
        }

        public Customer(int id)
        {
            manage = new CustomerManage();
            this.id = id;
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
        /// <summary>
        /// Gets the name of the zipcode.
        /// </summary>
        /// <param name="refzipcode">The refzipcode.</param>
        /// <returns></returns>
        public int getZipcodeName(int refzipcode)
        {
            return manage.getZipcodeName(refzipcode);
        }
        /// <summary>
        /// Gets the zipcode cities.
        /// </summary>
        /// <returns></returns>
        public void getZipcodeCities()
        {
           manage.getZipcodeCities(this);
        }
        /// <summary>
        /// Gets the zipcode.
        /// </summary>
        /// <returns></returns>
        public int getZipcode()
        {
            return manage.getZipcode(this);
        }
        /// <summary>
        /// Inserts the customer.
        /// </summary>
        public void insertCustomer()
        {
            manage.insertCustomer(this);
        }
        /// <summary>
        /// Inserts to fill.
        /// </summary>
        public void insertToFill()
        {
            manage.insertToFill(this);
        }
        /// <summary>
        /// Deletes the customer.
        /// </summary>
        public void deleteCustomer()
        {
            manage.deleteCustomer(this);
        }
        /// <summary>
        /// Modifies the customer.
        /// </summary>
        public void modifyCustomer()
        {
            manage.modifyCustomer(this);
        }
        /// <summary>
        /// Reads the customer.
        /// </summary>
        public void readCustomer()
        {
            manage.readCustomer(this);
        }
        /// <summary>
        /// Loads the regions.
        /// </summary>
        public void loadRegions()
        {
            manage.loadRegions();
        }
        /// <summary>
        /// Loads the states.
        /// </summary>
        /// <param name="refregion">The refregion.</param>
        public void loadStates(int refregion)
        {
            manage.loadStates(refregion);
        }
        /// <summary>
        /// Loads the cities.
        /// </summary>
        /// <param name="refstate">The refstate.</param>
        public void loadCities(int refstate)
        {
            manage.loadCities(refstate);
        }
        /// <summary>
        /// Loads the zipcodes.
        /// </summary>
        /// <param name="refcity">The refcity.</param>
        public void loadZipcodes(int refcity)
        {
            manage.loadZipcodes(refcity);
        }
        /// <summary>
        /// Loads all with zipcodes.
        /// </summary>
        /// <param name="zipcode">The zipcode.</param>
        /// <returns></returns>
        public int [] loadAllWithZipcodes(String zipcode)
        {
            return manage.loadAllWithZipcode(zipcode);
        }
        /// <summary>
        /// Searches the customer.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchCustomer(String filtro)
        {
            manage.searchCustomers(filtro);
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   id == customer.id;
        }
    }
}
