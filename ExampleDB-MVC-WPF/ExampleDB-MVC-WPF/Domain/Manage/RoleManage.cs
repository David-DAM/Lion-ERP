using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain.Manage
{
    public class RoleManage
    {
        public List<Role> list { get; set; }

        public RoleManage()
        {
            list = new List<Role>();
        }
        /// <summary>
        /// Fill the List of roles with all the roles.
        /// </summary>
        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;

            data = Search.getData("Select idrole from Roles", "roles");

            DataTable table = data.Tables["roles"];

            Role aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Role(Convert.ToInt32(row["IDROLE"]));
                readRole(aux);
                list.Add(aux);
            }
        }
        /// <summary>
        /// Reads the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void readRole(Role role)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("Select * from Roles where idrole=" + role.idrole, "roles");

            DataTable table = data.Tables["roles"];
            DataRow row = table.Rows[0];
            role.description = Convert.ToString(row["Description"]);
        }

        /// <summary>
        /// Inserts the role user.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="iduser">The iduser.</param>
        public void insertRole_User(Role role,int iduser)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Insert into USERS_ROLES values ("+iduser+","+role.idrole+")");
        }
        /// <summary>
        /// Modifies the role user.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="iduser">The iduser.</param>
        public void modifyRole_User(Role role,int iduser)
        {
            ConnectOracle Search = ConnectOracle.Instance;
            Search.setData("Update USERS_ROLES set idrole="+role.idrole+" where iduser="+iduser+"");
        }
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public List<String> getPermissions(Role role)
        {
            List<String> permissions=new List<string>();

            DataSet data = new DataSet();
            ConnectOracle Search = ConnectOracle.Instance;
            data = Search.getData("SELECT P.DESCRIPTION FROM permissions P,roles_permissions rp WHERE rp.idrole = "+role.idrole+" and p.idpermissions = rp.idpermissions group by p.description", "roles_permissions");
            DataTable table = data.Tables["roles_permissions"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                permissions.Add(Convert.ToString(row["Description"]));
            }

            return permissions;
        }

    }
}
