using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExampleDB_MVC_WPF.Domain
{
    public class User
    {
        public int iduser { get; set; }
        public String name { get; set; }
        public String password { get; set; }

        public Manage.UserManage manage { get; set; }

        public User ()
        {
            manage = new Manage.UserManage();
        }

        public User (int idUser)
        {
            manage = new Manage.UserManage();
            this.iduser = idUser; 
        }
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            manage.insertUser(this);
        }
        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <returns></returns>
        public Boolean check()
        {
            return manage.checkUser(this);
        }
        /// <summary>
        /// Checks the sq lite.
        /// </summary>
        /// <returns></returns>
        public Boolean checkSQLite()
        {
            return manage.checkUserSQLite(this);
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll ()
        {
            manage.readAll();
        }
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void delete()
        {
            manage.deleteUser(this);
        }
        /// <summary>
        /// Reads the user.
        /// </summary>
        public void readUser()
        {
            manage.readUser(this);
        }
        /// <summary>
        /// Modifies the user.
        /// </summary>
        public void modifyUser()
        {
            manage.modifyUser(this);
        }
        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <returns></returns>
        public int [] getRole()
        {
            return manage.getRole(this);
        }
        /// <summary>
        /// Gets the iduser.
        /// </summary>
        public void getIduser()
        {
            manage.getIduser(this);
        }
        /// <summary>
        /// Deletes the roles.
        /// </summary>
        public void deleteRoles()
        {
            manage.deleteRoles(this);
        }
       
    }
}
