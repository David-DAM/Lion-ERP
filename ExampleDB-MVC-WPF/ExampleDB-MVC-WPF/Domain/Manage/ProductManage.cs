using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class ProductManage
    {
        public List<Product> list { get; set; }
        public List<Color> colors { get; set; }
        public List<Measure> measures { get; set; }

        public ProductManage()
        {
            list = new List<Product>();
            colors = new List<Color>();
            measures = new List<Measure>();
        }
        /// <summary>
        /// Reads all and added to a list.
        /// </summary>
        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from first100products", "products");

            DataTable table = data.Tables["products"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product();
                aux.id = Convert.ToInt32(row["Idproduct"]);
                aux.name = Convert.ToString(row["Description"]);
                aux.price = Convert.ToDouble(row["Price"]);
                aux.color=new Color(Convert.ToInt32(row["Color"]));
                aux.color.readColor();
                aux.measure=new Measure(Convert.ToInt32(row["Measure"]));
                aux.measure.readMeasure();

                list.Add(aux);
            }
        }
        /// <summary>
        /// Reads the product.
        /// </summary>
        /// <param name="p">The p.</param>
        public void readProduct(Product p)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select * from products where idproduct=" + p.id + "", "products");

            DataTable table = data.Tables["products"];
            DataRow row = table.Rows[0];
            p.name = Convert.ToString(row["description"]);
            p.price = Convert.ToDouble(row["price"]);
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void insertProduct(Product product)
        {
            String price = Convert.ToString(product.price).Replace(",", ".");
            ConnectOracle Search = ConnectOracle.Instance;
            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idproduct)", "products", "")) + 1;
            Search.setData("Insert into products values (" + maximun + ",'" + product.name + "'," + product.measure.id + "," + price + ",0," + product.color.id +")");
            product.id = maximun;
        }
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void deleteProduct(Product product)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update products set deleted=1 where idproduct=" + product.id);
        }
        /// <summary>
        /// Modifies the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void modifyProduct(Product product)
        {
            String price = Convert.ToString(product.price).Replace(",",".");
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update products set description= '" + product.name + "',measure= " + product.measure.id + ",price= " + price + ",color= " + product.color.id + " where idproduct=" + product.id);
        }

        /// <summary>
        /// Reads the color.
        /// </summary>
        /// <param name="color">The color.</param>
        public void readColor(Color color)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Colors where idcolor=" + color.id, "colors");

            DataTable table = data.Tables["colors"];
            DataRow row = table.Rows[0];
            color.name = Convert.ToString(row["name"]);
        }
        /// <summary>
        /// Reads the measure.
        /// </summary>
        /// <param name="measure">The measure.</param>
        public void readMeasure(Measure measure)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Measures where idmeasure=" + measure.id, "measures");

            DataTable table = data.Tables["measures"];
            DataRow row = table.Rows[0];
            measure.name = Convert.ToString(row["name"]);
        }
        /// <summary>
        /// Loads the colors and added to a list.
        /// </summary>
        public void loadColors()
        {
            Color c;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select * from colors", "colors");
            DataTable table = data.Tables["colors"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idcolor"]);
                name = Convert.ToString(row["name"]);
                c = new Color(id, name);
                colors.Add(c);
            }
        }
        /// <summary>
        /// Loads the measures and added to a list.
        /// </summary>
        public void loadMeasures()
        {
            Measure m;
            int id;
            String name;

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("select * from measures", "measures");
            DataTable table = data.Tables["measures"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row["idmeasure"]);
                name = Convert.ToString(row["name"]);
                m = new Measure(id, name);
                measures.Add(m);
            }
        }
        /// <summary>
        /// Searches the product.
        /// </summary>
        /// <param name="filtro">The filtro.</param>
        public void searchProduct(String filtro)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select idproduct,description,measure,price,color from products where deleted=0 and description like '%"+filtro+"%' order by idproduct desc", "products");

            DataTable table = data.Tables["products"];

            Product aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Product();
                aux.id = Convert.ToInt32(row["Idproduct"]);
                aux.name = Convert.ToString(row["Description"]);
                aux.price = Convert.ToDouble(row["Price"]);
                aux.color = new Color(Convert.ToInt32(row["Color"]));
                aux.color.readColor();
                aux.measure = new Measure(Convert.ToInt32(row["Measure"]));
                aux.measure.readMeasure();

                list.Add(aux);
            }
        }
        /// <summary>
        /// Inserts to fill.
        /// </summary>
        /// <param name="product">The product.</param>
        public void insertToFill(Product product)
        {
            String price = Convert.ToString(product.price).Replace(",", ".");
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Insert into products values (" + product.id + ",'" + product.name + "'," + product.measure.id + "," + price + ",0," + product.color.id + ")");
        }
    }
}
