using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Product
    {
        public int id { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public Color color { get; set; }
        public Measure measure { get; set; }

        public ProductManage manage { get; set; }

        public Product()
        {
            manage = new ProductManage();
        }
        public Product(int id)
        {
            this.id = id;
            manage = new ProductManage();
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
        /// <summary>
        /// Reads the product.
        /// </summary>
        public void readProduct()
        {
            manage.readProduct(this);
        }
        /// <summary>
        /// Inserts the product.
        /// </summary>
        public void insertProduct()
        {
            manage.insertProduct(this);
        }
        /// <summary>
        /// Inserts to fill.
        /// </summary>
        public void insertToFill()
        {
            manage.insertToFill(this);
        }
        /// <summary>
        /// Deletes the product.
        /// </summary>
        public void deleteProduct()
        {
            manage.deleteProduct(this);
        }
        /// <summary>
        /// Modifies the product.
        /// </summary>
        public void modifyProduct()
        {
            manage.modifyProduct(this);
        }
        /// <summary>
        /// Loads the colors.
        /// </summary>
        public void loadColors()
        {
            manage.loadColors();
        }
        /// <summary>
        /// Loads the measures.
        /// </summary>
        public void loadMeasures()
        {
            manage.loadMeasures();
        }
        /// <summary>
        /// Searches the product.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchProduct(String filtro)
        {
            manage.searchProduct(filtro);
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
            return obj is Product product &&
                   id == product.id;
        }
    }
}
