using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class UserManage
    {
        public List<User> list { get; set; }

        public UserManage ()
        {
            list = new List<User>();
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select idUser from Users where deleted=0 and iduser>1", "users");

            DataTable table = data.Tables["users"];

            User aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new User(Convert.ToInt32(row["IDUSER"]));
                readUser(aux);
                list.Add(aux);
            }
        }
        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void readUser(User user)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Users where idUser=" + user.iduser, "users");

            DataTable table = data.Tables["users"];
            DataRow row = table.Rows[0];
            user.name = Convert.ToString(row["Name"]);
        }
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void insertUser (User user)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idUser)", "Users", "")) + 1;
            Search.setData("Insert into USERS values ("+maximun+",'"+user.name+"','"+ resources.useful.ComputeSha256Hash(user.password)  + "',0)");
        }
        /// <summary>
        /// Checks the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public Boolean checkUser(User user)
        {
            Boolean found = false;
            ConnectOracle Search = ConnectOracle.Instance;
            int count = Convert.ToInt32(Search.DLookUp("count(idUser)","Users","name='" + user.name + "' and password='" +resources.useful.ComputeSha256Hash(user.password) + "'"));
            if (count == 1)
                found = true;
            return found;
        }
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void deleteUser (User user)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update Users set deleted=1 where iduser=" + user.iduser );
        }
        /// <summary>
        /// Modifies the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void modifyUser(User user)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update Users set name= '"+user.name+"',password= '"+resources.useful.ComputeSha256Hash(user.password)+"' where iduser=" + user.iduser);
        }
        /// <summary>
        /// Checks the user with sqlite.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public Boolean checkUserSQLite(User user)
        {
            Boolean found = false;
            SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(Persistence.ConnectSQLite.databasepath);
            var count = connection.Query<User>("select NAME,PASSWORD from USERS WHERE NAME='" + user.name + "' AND PASSWORD='" +resources.useful.ComputeSha256Hash(user.password) + "'");
            if (count.Count==1)
                found = true;
            return found;
        }
        /// <summary>
        /// Gets the iduser.
        /// </summary>
        /// <param name="user">The user.</param>
        public void getIduser(User user)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Users where name='" + user.name+"' AND password='"+resources.useful.ComputeSha256Hash(user.password)+"'", "users");
            DataTable table = data.Tables["users"];
            DataRow row = table.Rows[0];
            user.iduser = Convert.ToInt32(row["Iduser"]);
        }

        /// <summary>
        /// Get all the roles of one user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int [] getRole(User user)
        {
            int[] idroles;
            List<Int32> ids=new List<int>();
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select idrole from users_roles where iduser="+user.iduser, "users_roles");
            DataTable table = data.Tables["users_roles"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                ids.Add(Convert.ToInt32(row["Idrole"]));
            }
            idroles = ids.ToArray();
            
            return idroles;

        }
        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="user">The user.</param>
        public void deleteRoles(User user)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Delete from USERS_ROLES where iduser="+user.iduser +"");
        }


    }
}
