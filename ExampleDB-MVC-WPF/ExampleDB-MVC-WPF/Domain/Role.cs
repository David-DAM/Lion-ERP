using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB_MVC_WPF.Domain
{
    public class Role
    {
        public int idrole { get; set; }
        public String description { get; set; }

        public Manage.RoleManage manage { get; set; }

        public Role()
        {
            manage = new Manage.RoleManage();
        }

        public Role(int idrole)
        {
            manage = new Manage.RoleManage();
            this.idrole = idrole;
        }
        /// <summary>
        /// Reads all.
        /// </summary>
        public void readAll()
        {
            manage.readAll();
        }
        /// <summary>
        /// Reads the role.
        /// </summary>
        public void readRole()
        {
            manage.readRole(this);
        }
        /// <summary>
        /// Inserts the role user.
        /// </summary>
        /// <param name="iduser">The iduser.</param>
        public void insertRole_User(int iduser)
        {
            manage.insertRole_User(this,iduser);
        }
        /// <summary>
        /// Modifies the role user.
        /// </summary>
        /// <param name="iduser">The iduser.</param>
        public void modifyRole_User(int iduser)
        {
            manage.modifyRole_User(this,iduser);
        }
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns></returns>
        public List<String> getPermissions()
        {
            return manage.getPermissions(this);
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
            return obj is Role role &&
                   idrole == role.idrole &&
                   description == role.description;
        }
    }
}
