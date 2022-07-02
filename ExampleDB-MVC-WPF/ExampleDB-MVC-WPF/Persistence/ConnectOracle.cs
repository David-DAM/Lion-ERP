using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ExampleDB_MVC_WPF.Persistence;

namespace ExampleDB_MVC_WPF  
{
    public class ConnectOracle
    {
        ////////////////////////////////////////////////////////////
        ////////////////////  DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST)(PORT = 1521)))"
        + "(CONNECT_DATA = (SERVICE_NAME = PDB18C))); "
        + "User Id=LITTLE_ERP; Password=LITTLE_ERP;";

        private static ConnectOracle instance = null;
        private OracleConnection objConexion;
        public static ConnectOracle Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectOracle();
                }
                return instance;
            }
        }
        //Constructor//
        private ConnectOracle()
        {
            objConexion = new OracleConnection(driver);
        }

        ////////////////////////////////////////////////////////////

        /**
         * Method to retrieve a set of data
         * Parameter: Query
         * Parameter: Table
         */
        public DataSet getData(String query, String table)
        {
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            objConexion.Open();
            objComando = new OracleDataAdapter(query, objConexion);
            objComando.Fill(requestQuery, table);
            objConexion.Close();

            return requestQuery;
        }

        /**
         * Method to insert data in a table
         * Parameter: Sentence 
         */
        public void setData(String sentencia)
        {
            OracleCommand objComando;

            objConexion.Open();
            objComando = new OracleCommand(sentencia, objConexion);

            objComando.ExecuteNonQuery();
            objComando.Connection.Close();
        }

        /**
         * Method to retrieve only one value
         * Parameter: column
         * Parameter: Table
         * Parameter: Condition
         */
        public Object DLookUp(String columna, String tabla, String condicion)
        {
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            Object resultado;
            objConexion.Open();

            if (condicion.Equals(""))
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla, objConexion);
            }
            else
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla + " where " + condicion, objConexion);
            }

            objComando.Fill(requestQuery);
            resultado = requestQuery.Tables[0].Rows[0][requestQuery.Tables[0].Columns.IndexOf(columna)];
            objConexion.Close();
            return resultado;
        }

    }
}
