using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB_MVC_WPF.Domain.Manage;

namespace ExampleDB_MVC_WPF.Domain
{
    public class State
    {
        public int id { get; set; }
        public String name { get; set; }

        public int refregion { get; set; }

        public CustomerManage manage { get; set; }

        public State()
        {
            manage = new CustomerManage();
        }

        public State(int id)
        {
            this.id = id;
            manage = new CustomerManage();
        }
        public State(int id, String name)
        {
            this.id = id;
            this.name = name;
            manage = new CustomerManage();
        }
        /// <summary>
        /// Reads the state.
        /// </summary>
        public void readState()
        {
            manage.readState(this);
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
            return obj is State state &&
                   id == state.id &&
                   name == state.name;
        }
    }
}
