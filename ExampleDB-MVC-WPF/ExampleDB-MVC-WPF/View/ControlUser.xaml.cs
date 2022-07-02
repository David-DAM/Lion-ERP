using ExampleDB_MVC_WPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ExampleDB_MVC_WPF.View
{
    /// <summary>
    /// Lógica de interacción para ControlUser.xaml
    /// </summary>
    public partial class ControlUser : MetroWindow
    {
        Boolean add=false;
        int id;
        int[] idroles;
        Role role,allowed;
        //Constructor to add a new User
        public ControlUser(String languaje)
        {
            List<Role> lista = new List<Role>();

            InitializeComponent();
            role = new Role();
            dataAllowed(role);
            dgvAssigned.ItemsSource = lista;
            add = true;

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);
            changeLanguaje();
        }
        //Constructor to modify a User 
        public ControlUser(User user, String languaje)
        {
            InitializeComponent();
            txtName.IsEnabled = false;
            txtName.Text = user.name;
            id = user.iduser;
            idroles = user.getRole();
            dataAssigned();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languaje);
            changeLanguaje();
        }
        /// <summary>
        /// Changes the languaje.
        /// </summary>
        public void changeLanguaje()
        {
            lblName.Content = Res.Nombre;
            lblPassword.Content = Res.Contraseña;
            dgtcAssigned.Header = Res.RolesAsignados;
            dgtcAllowed.Header = Res.RolesPermitidos;
            btnCancel.Content = Res.Cerrar;
            btnOk.Content = Res.Guardar;
            btnSend.Content = Res.EnviarEmail;
        }
        /// <summary>
        /// Put the allowed roles in the datagrid.
        /// </summary>
        /// <param name="role">The role.</param>
        public void dataAllowed(Role role)
        {
            role.readAll();
            dgvAllowed.ItemsSource = role.manage.list;
        }
        /// <summary>
        /// Put the assigned roles in the datagrid.
        /// </summary>
        public void dataAssigned()
        {
            allowed = new Role();
            dataAllowed(allowed);

            List<Role> lista = new List<Role>();

            for (int i = 0; i < idroles.Length; i++)
            {
                if (idroles[i]==1)
                {
                    dgvAllowed.IsEnabled = false;
                    dgvAssigned.IsEnabled = false;
                    btnLeft.IsEnabled = false;
                    btnRight.IsEnabled = false;
                }
                role = new Role(idroles[i]);
                role.readRole();
                lista.Add(role);
                allowed.manage.list.Remove(role);
            }
            dgvAssigned.ItemsSource = lista;
        }
        /// <summary>
        /// Handles the Click event of the btnLeft control to move role from allowed to assigned.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            List<Role> data = new List<Role>();
            List<Role> asigned = new List<Role>();
            int indice = 0;

            if (dgvAllowed.SelectedItems.Count > 0)
            {
                data = (List<Role>)dgvAllowed.ItemsSource;
                asigned = (List<Role>)dgvAssigned.ItemsSource;

                for (int i = 0; i < dgvAllowed.SelectedItems.Count; i++)
                {
                    indice = dgvAllowed.Items.IndexOf(dgvAllowed.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Role row = (Role)dgvAllowed.SelectedItems[i];
                    asigned.Add(row);
                }
                dgvAllowed.ItemsSource = null;
                dgvAllowed.ItemsSource = data;

                dgvAssigned.ItemsSource = null;
                dgvAssigned.ItemsSource = asigned;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Handles the Click event of the btnRight control to move role from assigned to allowed .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            List<Role> data = new List<Role>();
            List<Role> asigned = new List<Role>();
            int indice = 0;

            if (dgvAssigned.SelectedItems.Count > 0)
            {
                data = (List<Role>)dgvAllowed.ItemsSource;
                asigned = (List<Role>)dgvAssigned.ItemsSource;

                for (int i = 0; i < dgvAssigned.SelectedItems.Count; i++)
                {
                    indice = dgvAssigned.Items.IndexOf(dgvAssigned.SelectedItems[i]);
                    asigned.RemoveAt(indice);
                    Role row = (Role)dgvAssigned.SelectedItems[i];
                    data.Add(row);
                }
                dgvAllowed.ItemsSource = null;
                dgvAllowed.ItemsSource = data;

                dgvAssigned.ItemsSource = null;
                dgvAssigned.ItemsSource = asigned;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }

        }
        /// <summary>
        /// Handles the Click event of the btnSend control to show a message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email send to this User");
        }
        /// <summary>
        /// Handles the Click event of the btnCancel control to close the window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the btnOk control to add or modify one user.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            if (dgvAssigned.Items.Count>0)
            {
                
                if (add)
                {
                    user.name = txtName.Text;
                    user.password = "12345";
                    user.insert();
                    user.getIduser();

                    for (int i = 0; i < dgvAssigned.Items.Count; i++)
                    {
                        Role row = (Role)dgvAssigned.Items.GetItemAt(i);
                        row.insertRole_User(user.iduser);
                    }
                       
                }
                else
                {
                    user.iduser = id;

                    user.deleteRoles();
                    for (int i = 0; i < dgvAssigned.Items.Count; i++)
                    {
                        Role row = (Role)dgvAssigned.Items.GetItemAt(i);
                        row.insertRole_User(user.iduser);
                    }
                   
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Error, you must have at least one role assigned");
            }
        }
    }
}
