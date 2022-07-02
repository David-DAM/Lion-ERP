using ExampleDB_MVC_WPF.Domain;
using ExampleDB_MVC_WPF.Domain.Manage;
using ExampleDB_MVC_WPF.View;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ExampleDB_MVC_WPF
{
    /// <summary>
    /// Lógica de interacción para Tabcontrol.xaml
    /// </summary>
    public partial class Tabcontrol : MetroWindow
    {
        User profile;
        Role permissions;
        Boolean newCustomer=false,newProduct = false;
        Boolean getCustomer = false, getProduct = false;
        Boolean writing = false;
        String languaje = "en-US";
        /// <summary>
        ///  Delegate objects
        /// </summary>
        public GetCustomer getValueCustomer;
        /// <summary>
        ///  Delegate objects
        /// </summary>
        public GetProduct getValueProduct;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user"></param>
        public Tabcontrol(User user)
        {
            InitializeComponent();
            profile = user;
            inicialice(user);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            changeLanguage();
        }

        /// <summary>
        /// Constructor to get customer or product
        /// </summary>
        /// <param name="opcion"></param>
        public Tabcontrol(int opcion,String lang)
        {
            InitializeComponent();
            
            switch (opcion)
            {
                case 1:
                    getCustomer = true;

                    tbiCustomers.IsSelected = true;
                    tbiHome.Visibility = Visibility.Collapsed;
                    tbiProfile.Visibility = Visibility.Collapsed;
                    tbiUsers.Visibility = Visibility.Collapsed;
                    tbiProducts.Visibility = Visibility.Collapsed;
                    tbiSupliers.Visibility = Visibility.Collapsed;
                    tbiOrders.Visibility = Visibility.Collapsed;
                    tbiInvoices.Visibility = Visibility.Collapsed;
                    tbiIncidents.Visibility = Visibility.Collapsed;

                    lblDate.Visibility = Visibility.Hidden;
                    lblUser.Visibility = Visibility.Hidden;
                    lblLanguaje.Visibility = Visibility.Hidden;
                    imgLanguaje2.Visibility = Visibility.Hidden;
                    imgLanguaje3.Visibility = Visibility.Hidden;
                    txtDate.Visibility = Visibility.Hidden;
                    txtName.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    getProduct = true;

                    tbiProducts.IsSelected = true;
                    tbiHome.Visibility = Visibility.Collapsed;
                    tbiProfile.Visibility = Visibility.Collapsed;
                    tbiUsers.Visibility = Visibility.Collapsed;
                    tbiCustomers.Visibility = Visibility.Collapsed;
                    tbiSupliers.Visibility = Visibility.Collapsed;
                    tbiOrders.Visibility = Visibility.Collapsed;
                    tbiInvoices.Visibility = Visibility.Collapsed;
                    tbiIncidents.Visibility = Visibility.Collapsed;

                    lblDate.Visibility = Visibility.Hidden;
                    lblUser.Visibility = Visibility.Hidden;
                    lblLanguaje.Visibility = Visibility.Hidden;
                    imgLanguaje2.Visibility = Visibility.Hidden;
                    imgLanguaje3.Visibility = Visibility.Hidden;
                    txtDate.Visibility = Visibility.Hidden;
                    txtName.Visibility = Visibility.Hidden;
                    break;
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            changeLanguage();
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the imgLanguaje3 control to put Spanish.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void imgLanguaje3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
            changeLanguage();
            languaje = "";
        }
        /// <summary>
        /// Handles the MouseLeftButtonDown event of the imgLanguaje2 control to put Emglish.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void imgLanguaje2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            changeLanguage();
            languaje = "en-US";
        }
        /// <summary>
        /// Changes the language.
        /// </summary>
        private void changeLanguage()
        {
            lblWelcome.Content = Res.Bienvenido;

            lblDate.Content = Res.Fecha;
            lblUser.Content = Res.Usuario;
            lblLanguaje.Content = Res.Idioma;

            lblPrevious.Content = Res.PreviaContraseña;
            lblNew.Content = Res.NuevaContraseña;
            lblRepeat.Content = Res.RepetirContraseña;
            btnOk.Content = Res.Guardar;

            btnAdd.Content = Res.Añadir;
            btnModify.Content = Res.Modificar;
            btnDelete.Content = Res.Borrar;
            dgtcNameUser.Header = Res.Nombre;

            btnNewCustomer.Content = Res.Añadir;
            btnDeleteCustomer.Content = Res.Borrar;
            btnSaveCustomer.Content = Res.Guardar;
            lblNameCustomer.Content = Res.Nombre;
            lblSurnameCustomer.Content = Res.Apellido;
            lblEmailCustomer.Content = Res.Correo;
            lblPhoneCustomer.Content = Res.Telefono;
            lblAddresCustomer.Content = Res.Dirección;
            lblRegionCustomer.Content = Res.Región;
            lblStateCustomer.Content = Res.Estado;
            lblCityCustomer.Content = Res.Ciudad;
            lblZipcodeCustomer.Content = Res.CodigoPostal;
            dgtcNameCustomer.Header = Res.Nombre;
            dgtcSurnameCustomer.Header = Res.Apellido;
            dgtcAddresCustomer.Header = Res.Dirección;
            dgtcPhoneCustomer.Header = Res.Telefono;
            dgtcEmailCustomer.Header = Res.Correo;

            btnNewProduct.Content = Res.Añadir;
            btnDeleteProduct.Content = Res.Borrar;
            btnSaveProduct.Content = Res.Guardar;
            lblPriceProduct.Content = Res.Precio;
            lblDescriptionProduct.Content = Res.Descripción;
            lblMeasureProduct.Content = Res.Medida;
            lblColorProduct.Content = Res.Color;
            dgtcNameProduct.Header = Res.Descripción;
            dgtcMeasureProduct.Header = Res.Medida;
            dgtcColorProduct.Header = Res.Color;
            dgtcPriceProduct.Header = Res.Precio;

            lblNameSuplier.Content = Res.Nombre;
            lblSurnameSuplier.Content = Res.Apellido;
            lblPhoneSuplier.Content = Res.Telefono;
            dgtcNameSuplier.Header = Res.Nombre;
            dgtcSurnameSuplier.Header = Res.Apellido;
            dgtcPhoneSuplier.Header = Res.Telefono;

            btnNewOrder.Content = Res.Añadir;
            btnDeleteOrder.Content = Res.Borrar;
            btnZoomOrder.Content = Res.Modificar;
            dgtcCustomerOrder.Header = Res.Nombre +" "+Res.Cliente;
            dgtcDateOrder.Header = Res.Fecha;
            dgtcPaymentMethodOrder.Header = Res.MetodoPago;
            dgtcConfirmedOrder.Header = Res.Confirmado;
            dgtcLabeledOrder.Header = Res.Etiquetado;
            dgtcSentOrder.Header = Res.Enviado;
            dgtcInvoicedOrder.Header = Res.Facturado;

            btnNewInvoice.Content = Res.Añadir;
            btnDeleteInvoice.Content = Res.Borrar;
            btnZoomInvoice.Content = Res.Modificar;
            btnPrintInvoice.Content = Res.Imprimir;
            dtcInvoicesDate.Header = Res.Fecha;

            tbiHome.Header = Res.Inicio;
            tbiUsers.Header = Res.Usuarios;
            tbiProducts.Header = Res.Productos;
            tbiCustomers.Header = Res.Clientes;
            tbiSupliers.Header = Res.Proveedores;
            tbiOrders.Header = Res.Pedidos;
            tbiInvoices.Header = Res.Facturas;
            tbiProfile.Header = Res.Perfil;

            tbiIncidents.Header = Res.Incidencias;
            btnZoomIncident.Content = Res.Modificar;
            btnDataIncident.Content = Res.Datos;
            btnPrintIncidents.Content = Res.Imprimir;
            dtcIncidentsOrder.Header = "Id " + Res.Pedidos;
            dtcIncidentsProduct.Header = Res.Producto;
            dtcIncidentsType.Header = Res.TipoIncidencia;
        }

        /// <summary>
        /// Check the permissions of the user and restrict their actions
        /// </summary>
        /// <param name="user"></param>
        public void inicialice(User user)
        {
            int [] role;
            List<String> lista;
            List<String> acumulada=new List<string>();

            txtName.Text = user.name;
            txtDate.Text = fecha();
           
            role = user.getRole();
            for (int i = 0; i < role.Length; i++)
            {
                permissions = new Role(role[i]);
                lista=permissions.getPermissions();
                acumulada.AddRange(lista);

                if (!acumulada.Contains("show_user"))
                {
                    tbiUsers.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_user"))
                {
                    btnModify.Click -= btnModify_Click;
                    btnModify.Click += NotPermissions;

                    btnDelete.Click -= btnDelete_Click;
                    btnDelete.Click += NotPermissions;
                }
                if (!acumulada.Contains("add_user"))
                {
                    btnAdd.Click -= btnAdd_Click;
                    btnAdd.Click += NotPermissions;
                }
                if (!acumulada.Contains("show_client") )
                {
                    tbiCustomers.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_client"))
                {
                    btnDeleteCustomer.Click -= btnDeleteCustomer_Click;
                    btnDeleteCustomer.Click += NotPermissions;

                    btnSaveCustomer.Click -= btnSaveCustomer_Click;
                    btnSaveCustomer.Click += NotPermissions;
                }
                if (!acumulada.Contains("add_client"))
                {
                    btnNewCustomer.Click -= btnNewCustomer_Click;
                    btnNewCustomer.Click += NotPermissions;
                }
                if (!acumulada.Contains("show_product"))
                {
                    tbiProducts.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_product"))
                {
                    btnDeleteProduct.Click -= btnDeleteProduct_Click;
                    btnDeleteProduct.Click += NotPermissions;

                    btnSaveProduct.Click -= btnSaveProduct_Click;
                    btnSaveProduct.Click += NotPermissions;
                }
                if (!acumulada.Contains("add_product"))
                {
                    btnNewProduct.Click -= btnNewProduct_Click;
                    btnNewProduct.Click += NotPermissions;
                }

                if (!acumulada.Contains("show_order"))
                {
                    tbiOrders.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_order"))
                {
                    btnDeleteOrder.Click -= btnDeleteOrder_Click;
                    btnDeleteOrder.Click += NotPermissions;

                    btnZoomOrder.Click -= btnZoomOrder_Click;
                    btnZoomOrder.Click += NotPermissions;

                    dgvOrders.MouseDoubleClick -= dgvOrders_MouseDoubleClick;
                    dgvOrders.MouseDoubleClick += NotPermissions;
                }
                if (!acumulada.Contains("add_order"))
                {
                    btnNewOrder.Click -= btnNewOrder_Click;
                    btnNewOrder.Click += NotPermissions;
                }
                if (!acumulada.Contains("show_invoice"))
                {
                    tbiInvoices.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_invoice"))
                {
                    btnDeleteInvoice.Click -= btnDeleteInvoice_Click;
                    btnDeleteInvoice.Click += NotPermissions;

                    btnZoomInvoice.Click -= btnZoomInvoice_Click;
                    btnZoomInvoice.Click += NotPermissions;

                    btnPrintInvoice.Click -= btnPrintInvoice_Click;
                    btnPrintInvoice.Click += NotPermissions;

                    dgvInvoices.MouseDoubleClick -= dgvInvoices_MouseDoubleClick;
                    dgvInvoices.MouseDoubleClick += NotPermissions;
                }
                if (!acumulada.Contains("add_invoice"))
                {
                    btnNewInvoice.Click -= btnNewInvoice_Click;
                    btnNewInvoice.Click += NotPermissions;
                }
                if (!acumulada.Contains("show_incident"))
                {
                    tbiIncidents.Visibility = Visibility.Collapsed;
                }
                if (!acumulada.Contains("edit_incident"))
                {
                    btnZoomIncident.Click -= btnZoomIncident_Click;
                    btnZoomIncident.Click += NotPermissions;

                    btnDataIncident.Click -= btnDataIncident_Click;
                    btnDataIncident.Click += NotPermissions;

                    btnPrintIncidents.Click -= btnPrintIncidents_Click;
                    btnPrintIncidents.Click += NotPermissions;
                }
            }

           
            
        }
        /// <summary>
        /// Show a message when some user try to do something without enought permissions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotPermissions(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You don´t have enought permissions");
        }
        /// <summary>
        /// Put a list of users in the datagrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiUsers_Initialized(object sender, EventArgs e)
        {
            User user = new User();
            user.readAll();
            dgvUsers.ItemsSource = user.manage.list;
        }

        /// <summary>
        /// Put the actual date
        /// </summary>
        /// <returns></returns>
        public string fecha()
        {
            String fecha;

            DateTime time = DateTime.Now;

            fecha = time.ToString();
            
            return fecha;
        }
        /// <summary>
        /// Delete a number of users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(Object sender, RoutedEventArgs e)
        {
            List<User> data = new List<User>();
            int indice = 0;

            if (dgvUsers.SelectedItems.Count > 0)
            {
                data = (List<User>)dgvUsers.ItemsSource;

                for (int i = 0; i < dgvUsers.SelectedItems.Count; i++)
                {
                    indice = dgvUsers.Items.IndexOf(dgvUsers.SelectedItems[i]);
                    data.RemoveAt(indice);
                    User row = (User)dgvUsers.SelectedItems[i];
                    row.delete();
                }
                dgvUsers.ItemsSource = null;
                dgvUsers.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Open the window to add one user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            ControlUser control = new ControlUser(languaje);

            control.ShowDialog();

            user.readAll();
            dgvUsers.ItemsSource = null;
            dgvUsers.ItemsSource = user.manage.list;
        }
        /// <summary>
        /// Open the window to modify one user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            ControlUser controlUser;
            List<User> data = new List<User>();
            

            if (dgvUsers.SelectedItems.Count==1)
            {
                
                data = (List<User>)dgvUsers.ItemsSource;

                
                User row = (User)dgvUsers.SelectedItems[0];
                
                controlUser = new ControlUser(row,languaje);
                controlUser.ShowDialog();

                user.readAll();
                dgvUsers.ItemsSource = null;
                dgvUsers.ItemsSource = user.manage.list;
                
            }
            else
            {
                MessageBox.Show("You must select one row");
            }
        }
        /// <summary>
        /// Change the password of the User profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            profile.password = psbPrevious.Password;

            Boolean exist = profile.check();

            if (exist)
            {
                profile.password = psbNew.Password;

                if (psbNew.Password==psbRepeat.Password && psbNew.Password.Length>0)
                {
                    profile.modifyUser();

                    psbPrevious.Clear();
                    psbNew.Clear();
                    psbRepeat.Clear();
                    tbiHome.IsSelected=true;
                    MessageBox.Show("Password changed");
                }
                else
                {
                    MessageBox.Show("The password is not the same");
                }
            }
            else
            {
                MessageBox.Show("Password invalid");
            }
        }
        /// <summary>
        /// Put a list of customers in the datagrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiCustomers_Initialized(object sender, EventArgs e)
        {
            Customer c1 = new Customer();
            c1.readAll();
            dgvCustomers.ItemsSource = c1.manage.list;
        }

        /// <summary>
        /// Handles the KeyDown event of the txbPhone control to only put numbers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void txbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Handles the KeyDown event of the txbPrice control to only put prices.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void txbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Clear the data and charge the regions to create a new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer();
            c.loadRegions();

            txbNameCustomer.IsEnabled = true;
            txbNameCustomer.Clear();
            txbNifCustomer.IsEnabled = true;
            txbNifCustomer.Clear();
            txbSurnameCustomer.IsEnabled = true;
            txbSurnameCustomer.Clear();
            txbZipcode.IsEnabled = true;
            txbZipcode.Clear();
            txbEmail.IsEnabled = true;
            txbEmail.Clear();
            txbPhone.IsEnabled = true;
            txbPhone.Clear();
            txbAdress.IsEnabled = true;
            txbAdress.Clear();
            cmbRegiones.IsEnabled = true;
            cmbRegiones.ItemsSource = null;
            cmbRegiones.ItemsSource = c.manage.regions;
            cmbStates.IsEnabled = false;
            cmbStates.ItemsSource = null;
            cmbCity.IsEnabled = false;
            cmbCity.ItemsSource = null;
            cmbZipCode.IsEnabled = false;
            cmbZipCode.ItemsSource = null;
            btnSaveCustomer.IsEnabled = true;

            newCustomer = true;
        }
        /// <summary>
        /// Load the states of a region and limits some combobox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c1 = new Customer();
            Region r1 = (Region)cmbRegiones.SelectedItem;

            if (r1!=null)
            {
                c1.loadStates(r1.id);
                cmbStates.ItemsSource = c1.manage.states;
                cmbStates.IsEnabled = true;

                cmbCity.IsEnabled = false;
                cmbCity.ItemsSource = null;

                cmbZipCode.IsEnabled = false;
                cmbZipCode.SelectedItem = null;
            }

        }
        /// <summary>
        /// Load the cities of a state and limits some combobox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c1 = new Customer();
            State s1 = (State)cmbStates.SelectedItem;

            if (s1!=null)
            {
                c1.loadCities(s1.id);
                cmbCity.ItemsSource = c1.manage.cities;
                cmbCity.IsEnabled = true;

                cmbZipCode.IsEnabled = false;
                cmbZipCode.SelectedItem = null;
            }
            
        }
        /// <summary>
        /// Load the zipcodes of a city and limits some combobox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c1 = new Customer();
            City c = (City)cmbCity.SelectedItem;

            if (c!=null)
            {
                c1.loadZipcodes(c.id);
                cmbZipCode.ItemsSource = c1.manage.zipcodes;
                cmbZipCode.IsEnabled = true;
            }
            
        }


        /// <summary>
        /// Load the region,state and city with some zipcode 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbZipcode_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Customer c1 = new Customer();

            if (txbZipcode.Text.Length==4 && !writing)
            {
                txbZipcode.Text = "0" + txbZipcode.Text;
            }

            writing = true;

            int [] refs = c1.loadAllWithZipcodes(txbZipcode.Text);

            if (!refs.Contains(0))
            {
                c1.loadRegions();
                writing=false;

                Region r = new Region(refs[1]);
                r.readRegion();
                State s = new State(refs[0]);
                s.readState();
                City c = new City(refs[2]);
                c.readCity();
                Zipcode z = new Zipcode(txbZipcode.Text);
                z.readZipcode();

                cmbRegiones.ItemsSource = c1.manage.regions;
                cmbRegiones.SelectedItem = r;

                cmbStates.SelectedItem = s;

                cmbCity.SelectedItem = c;

                cmbZipCode.SelectedItem = z;

                cmbRegiones.IsEnabled = true;
                cmbStates.IsEnabled = true;
                cmbCity.IsEnabled = true;
            }

        }
        /// <summary>
        /// Load the info of the selected customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c = (Customer)dgvCustomers.SelectedItem;

            if (c!=null)
            {
                txbNifCustomer.IsEnabled = true;
                txbNameCustomer.IsEnabled = true;
                txbSurnameCustomer.IsEnabled = true;
                txbEmail.IsEnabled = true;
                txbPhone.IsEnabled = true;
                txbAdress.IsEnabled = true;
                cmbRegiones.IsEnabled = true;
                cmbStates.IsEnabled = true;
                cmbCity.IsEnabled = true;
                txbZipcode.IsEnabled = true;
                btnSaveCustomer.IsEnabled = true;

                txbNameCustomer.Text = c.name;
                txbNifCustomer.Text = c.nif;
                txbSurnameCustomer.Text = c.surname;
                txbEmail.Text = c.email;
                txbPhone.Text = c.phone;
                txbAdress.Text = c.adress;
                txbZipcode.Text = Convert.ToString(c.getZipcode());
                
                newCustomer = false;
            }
            
        }
        /// <summary>
        /// Update or insert one customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer c=new Customer();
            Customer aux = (Customer)dgvCustomers.SelectedItem;
            int index;
            if (!newCustomer)
            {
                c.id = aux.id;
            }
            c.nif = txbNifCustomer.Text;
            c.name = txbNameCustomer.Text;
            c.surname = txbSurnameCustomer.Text;
            c.email=txbEmail.Text;
            c.phone = txbPhone.Text;
            c.adress = txbAdress.Text;
            c.region = (Region)cmbRegiones.SelectedItem;
            c.state = (State)cmbStates.SelectedItem;
            c.cities= (City)cmbCity.SelectedItem;
            c.zipcode= (Zipcode)cmbZipCode.SelectedItem;
            String zipcode = txbZipcode.Text;

            if (!c.nif.Equals("") && !c.name.Equals("") && !c.surname.Equals("") && !c.email.Equals("") && !c.phone.Equals("") && !c.adress.Equals("") && c.region != null && c.state != null && c.zipcode != null)
            {
                if (newCustomer)
                {
                    c.getZipcodeCities();
                    c.insertCustomer();
                    newCustomer = false;

                    c.manage.list= (List<Customer>)dgvCustomers.ItemsSource;
                    c.manage.list.Add(c);
                    c.manage.list=c.manage.list.OrderByDescending(x => x.id).ToList();
                }
                else
                {
                    c.getZipcodeCities();
                    c.modifyCustomer();

                    c.manage.list = (List<Customer>)dgvCustomers.ItemsSource;
                    index=c.manage.list.IndexOf(c);
                    c.manage.list.RemoveAt(index);
                    c.manage.list.Insert(index,c);
                    c.manage.list = c.manage.list.OrderByDescending(x => x.id).ToList();
                }

                dgvCustomers.ItemsSource = null;
                dgvCustomers.ItemsSource = c.manage.list;

                disableAndClear();
            }
            else
            {
                MessageBox.Show("Enter all the data");
            }
            
        }
        /// <summary>
        /// Disable and clear the data of customers
        /// </summary>
        public void disableAndClear()
        {
            txbNameCustomer.IsEnabled = false;
            txbNameCustomer.Clear();
            txbNifCustomer.IsEnabled = false;
            txbNifCustomer.Clear();
            txbSurnameCustomer.IsEnabled = false;
            txbSurnameCustomer.Clear();
            txbZipcode.IsEnabled = false;
            txbZipcode.Clear();
            txbEmail.IsEnabled = false;
            txbEmail.Clear();
            txbPhone.IsEnabled = false;
            txbPhone.Clear();
            txbAdress.IsEnabled = false;
            txbAdress.Clear();
            cmbRegiones.IsEnabled = false;
            cmbRegiones.ItemsSource = null;
            cmbStates.IsEnabled = false;
            cmbStates.ItemsSource = null;
            cmbCity.IsEnabled = false;
            cmbCity.ItemsSource = null;
            cmbZipCode.IsEnabled = false;
            cmbZipCode.ItemsSource = null;
            btnSaveCustomer.IsEnabled = false;
        }
        /// <summary>
        /// Delete a number of customers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> data = new List<Customer>();
            int indice = 0;

            if (dgvCustomers.SelectedItems.Count > 0)
            {
                data = (List<Customer>)dgvCustomers.ItemsSource;

                for (int i = 0; i < dgvCustomers.SelectedItems.Count; i++)
                {
                    indice = dgvCustomers.Items.IndexOf(dgvCustomers.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Customer row = (Customer)dgvCustomers.SelectedItems[i];
                    row.deleteCustomer();
                }
                dgvCustomers.ItemsSource = null;
                dgvCustomers.ItemsSource = data;

                disableAndClear();
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Search a customer with a specific filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBuscar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer();

            c.searchCustomer(txbBuscar.Text);
            dgvCustomers.ItemsSource = null;
            dgvCustomers.ItemsSource = c.manage.list;
            
        }

        /// <summary>
        /// Put a list of products in the datagrid, and charge the colors and measures 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiProducts_Initialized(object sender, EventArgs e)
        {
            Product p = new Product();

            p.readAll();
            p.loadColors();
            p.loadMeasures();

            dgvProducts.ItemsSource = p.manage.list;
            cmbMeasureProduct.ItemsSource = p.manage.measures;
            cmbColorProduct.ItemsSource = p.manage.colors;
        }

        /// <summary>
        /// Disable and clear the data of products
        /// </summary>
        public void disableAndClearProducts()
        {
            txbPriceProduct.IsEnabled = false;
            txbPriceProduct.Clear();

            txbDescriptionProduct.IsEnabled = false;
            txbDescriptionProduct.Clear();

            cmbMeasureProduct.IsEnabled = false;
            cmbMeasureProduct.SelectedItem = null;
            cmbColorProduct.IsEnabled = false;
            cmbColorProduct.SelectedItem = null;
        }

        /// <summary>
        /// Clear the data and enable the elements to write
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            txbPriceProduct.IsEnabled = true;
            txbPriceProduct.Clear();
            txbDescriptionProduct.IsEnabled = true;
            txbDescriptionProduct.Clear();

            cmbMeasureProduct.IsEnabled = true;
            cmbMeasureProduct.SelectedItem = null;
            cmbColorProduct.IsEnabled = true;
            cmbColorProduct.SelectedItem = null;
            btnSaveProduct.IsEnabled = true;

            newProduct = true;
        }

        /// <summary>
        /// Delete a number of products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> data = new List<Product>();
            int indice = 0;

            if (dgvProducts.SelectedItems.Count > 0)
            {
                data = (List<Product>)dgvProducts.ItemsSource;

                for (int i = 0; i < dgvProducts.SelectedItems.Count; i++)
                {
                    indice = dgvProducts.Items.IndexOf(dgvProducts.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Product row = (Product)dgvProducts.SelectedItems[i];
                    row.deleteProduct();
                }
                dgvProducts.ItemsSource = null;
                dgvProducts.ItemsSource = data;

                disableAndClearProducts();
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        /// <summary>
        /// Load the data of a selected product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product p = (Product)dgvProducts.SelectedItem;

            if (p != null)
            {
                txbPriceProduct.IsEnabled = true;
                txbDescriptionProduct.IsEnabled = true;
                cmbMeasureProduct.IsEnabled = true;
                cmbColorProduct.IsEnabled = true;
                btnSaveProduct.IsEnabled = true;

                txbPriceProduct.Text = Convert.ToString(p.price);
                txbDescriptionProduct.Text = p.name;
                cmbMeasureProduct.SelectedItem = p.measure;
                cmbColorProduct.SelectedItem = p.color;

                newProduct = false;
            }
        }

        /// <summary>
        /// Update or insert a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            int index;

            Product p = new Product();
            Product aux = (Product)dgvProducts.SelectedItem;
            if (!newProduct)
            {
                p.id = aux.id;
            }
            p.price = Convert.ToDouble(txbPriceProduct.Text);
            p.name = txbDescriptionProduct.Text;
            p.measure = (Measure)cmbMeasureProduct.SelectedItem;
            p.color = (Domain.Color)cmbColorProduct.SelectedItem;

            if (p.price != 0 && !p.name.Equals("") && p.measure != null && p.color != null)
            {
                if (newProduct)
                {
                    p.insertProduct();
                    newProduct = false;

                    p.manage.list = (List<Product>)dgvProducts.ItemsSource;
                    p.manage.list.Add(p);
                    p.manage.list=p.manage.list.OrderByDescending(x => x.id).ToList();

                }
                else
                {
                    p.modifyProduct();

                    p.manage.list = (List<Product>)dgvProducts.ItemsSource;
                    index = p.manage.list.IndexOf(p);
                    p.manage.list.RemoveAt(index);
                    p.manage.list.Insert(index, p);
                    p.manage.list=p.manage.list.OrderByDescending(x => x.id).ToList();
                }

                dgvProducts.ItemsSource = null;
                dgvProducts.ItemsSource = p.manage.list;

                disableAndClearProducts();
            }
            else
            {
                MessageBox.Show("Enter all the data");
            }
        }

        /// <summary>
        /// Search a product with a specific filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBuscarProduct_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Product p = new Product();

            p.searchProduct(txbBuscarProduct.Text);
            dgvProducts.ItemsSource = null;
            dgvProducts.ItemsSource = p.manage.list;
        }
        private void tbiSupliers_Initialized(object sender, EventArgs e)
        {
            try
            {
                Suplier suplier = new Suplier();
                suplier.readAll();

                dgvSupliers.ItemsSource = suplier.manage.list;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Load the data of a selected suplier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSupliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Suplier s = (Suplier)dgvSupliers.SelectedItem;

            if (s != null)
            {
                txbNifSuplier.Text = s.nif;
                txbNameSuplier.Text = s.name;
                txbSurnameSuplier.Text = s.surname;
                txbPhoneSuplier.Text = s.phone;
            }
        }
        /// <summary>
        /// Load the datagrid with the orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiOrders_Initialized(object sender, EventArgs e)
        {
            Order order = new Order();

            order.readAll();
            dgvOrders.ItemsSource = order.manage.list;
        }
        /// <summary>
        /// Delete a number of orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            List<Order> data = new List<Order>();
            int indice = 0;

            if (dgvOrders.SelectedItems.Count > 0)
            {
                data = (List<Order>)dgvOrders.ItemsSource;

                for (int i = 0; i < dgvOrders.SelectedItems.Count; i++)
                {
                    indice = dgvOrders.Items.IndexOf(dgvOrders.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Order row = (Order)dgvOrders.SelectedItems[i];
                    row.deleteOrder();
                }
                dgvOrders.ItemsSource = null;
                dgvOrders.ItemsSource = data;

            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Search a specific order by his paymentmethod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBuscarOrder_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Order o = new Order();

            o.searchOrder(txbBuscarOrder.Text);
            dgvOrders.ItemsSource = null;
            dgvOrders.ItemsSource = o.manage.list;
            
        }
        /// <summary>
        /// Open the window to create a new order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            ControlOrder controlOrder = new ControlOrder(profile,false,languaje);
            controlOrder.ShowDialog();

            order.readAll();
            dgvOrders.ItemsSource = null;
            dgvOrders.ItemsSource = order.manage.list;
        }
        /// <summary>
        /// Open the window to modify a new order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            ControlOrder controlOrder;
            List<Order> data = new List<Order>();


            if (dgvOrders.SelectedItems.Count == 1)
            {

                data = (List<Order>)dgvOrders.ItemsSource;


                Order row = (Order)dgvOrders.SelectedItems[0];

                controlOrder = new ControlOrder(row,profile,languaje);
                controlOrder.ShowDialog();

                order.readAll();
                dgvOrders.ItemsSource = null;
                dgvOrders.ItemsSource = order.manage.list;

            }
            else
            {
                MessageBox.Show("You must select one row");
            }
        }
        /// <summary>
        /// Change the status of a order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Order> data = new List<Order>();
            Invoice invoice = new Invoice();

            if (dgvOrders.SelectedItems.Count == 1)
            {
                Boolean exist=false;

                data = (List<Order>)dgvOrders.ItemsSource;

                Order row = (Order)dgvOrders.SelectedItems[0];

                int index = dgvOrders.CurrentCell.Column.DisplayIndex;

                switch (index)
                {
                    case 5:
                        if (row.confirmed==0)
                        {
                            row.confirmed = 1;
                        }
                        else if (row.confirmed==1)
                        {
                            row.confirmed = 0;
                        }
                        break;
                    case 6:
                        if (row.labeled == 0)
                        {
                            row.labeled = 1;
                        }
                        else if (row.labeled == 1)
                        {
                            row.labeled = 0;
                        }
                        break;
                    case 7:
                        if (row.sent == 0)
                        {
                            row.sent = 1;
                        }
                        else if (row.sent == 1)
                        {
                            row.sent = 0;
                        }
                        break;
                    case 8:
                        if (row.invoiced == 0)
                        {
                            row.invoiced = 1;

                            invoice.order = row;

                            exist = invoice.checkOrderInvoice();

                            if (!exist)
                            {
                                invoice.insertInvoice();
                                invoice.insertOrderInvoice();
                            }
                            else
                            {
                                invoice.readIdInvoiceOrder();
                                invoice.recoverInvoice();
                            }

                            Print p = new Print(invoice);
                            p.ShowDialog();

                        }
                        else if (row.invoiced == 1)
                        {
                            row.invoiced = 0;

                            invoice.order = row;
                            invoice.readIdInvoiceOrder();
                            invoice.deleteInvoice();
                        }
                        break;
                }

                row.modifyOrderStatus();

                row.readAll();
                dgvOrders.ItemsSource = null;
                dgvOrders.ItemsSource = row.manage.list;

                if (invoice.order != null)
                {
                    invoice.readAllInvoices();
                    dgvInvoices.ItemsSource = null;
                    dgvInvoices.ItemsSource = invoice.manage.invoices;
                }
            }
        }
        /// <summary>
        /// Declared delegate
        /// </summary>
        /// <param name="customer"></param>
        public delegate void GetCustomer(Customer customer);
        /// <summary>
        /// Select a customer and close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (getCustomer)
            {
                Customer selectedFromOrder = (Customer)dgvCustomers.SelectedItem;

                getValueCustomer(selectedFromOrder);
                
                this.Close();
            }
        }

        /// <summary>
        /// Declared delegate
        /// </summary>
        /// <param name="product"></param>
        public delegate void GetProduct(Product product);

        /// <summary>
        /// Select a product and close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (getProduct)
            {
                Product selectedFromOrder = (Product)dgvProducts.SelectedItem;

                getValueProduct(selectedFromOrder);

                this.Close();
            }
        }
        /// <summary>
        /// Handles the Initialized event of the dgvInvoices control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dgvInvoices_Initialized(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();

            invoice.readAllInvoices();
            dgvInvoices.ItemsSource = invoice.manage.invoices;
        }
        /// <summary>
        /// Handles the Click event of the btnNewInvoice control to open the window for creating a new order and invoice.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            Invoice invoice = new Invoice();
            ControlOrder controlOrder = new ControlOrder(profile,true,languaje);
            controlOrder.ShowDialog();

            invoice.readAllInvoices();
            dgvInvoices.ItemsSource = null;
            dgvInvoices.ItemsSource = invoice.manage.invoices;

            order.readAll();
            dgvOrders.ItemsSource = null;
            dgvOrders.ItemsSource = order.manage.list;
        }
        /// <summary>
        /// Handles the Click event of the btnDeleteInvoice control to delete an invoice.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            List<Invoice> data = new List<Invoice>();
            int indice = 0;

            if (dgvInvoices.SelectedItems.Count > 0)
            {
                data = (List<Invoice>)dgvInvoices.ItemsSource;

                for (int i = 0; i < dgvInvoices.SelectedItems.Count; i++)
                {
                    indice = dgvInvoices.Items.IndexOf(dgvInvoices.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Invoice row = (Invoice)dgvInvoices.SelectedItems[i];
                    row.deleteInvoice();
                }
                dgvInvoices.ItemsSource = null;
                dgvInvoices.ItemsSource = data;

            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
        /// <summary>
        /// Handles the Click event of the btnZoomInvoice control to modify an order.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnZoomInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice();
            ControlOrder controlOrder;
            List<Invoice> data = new List<Invoice>();


            if (dgvInvoices.SelectedItems.Count == 1)
            {

                data = (List<Invoice>)dgvInvoices.ItemsSource;


                Invoice row = (Invoice)dgvInvoices.SelectedItems[0];

                controlOrder = new ControlOrder(row.order, profile,languaje);
                controlOrder.ShowDialog();

                row.readAllInvoices();
                dgvInvoices.ItemsSource = null;
                dgvInvoices.ItemsSource = row.manage.invoices;

                row.order.readAll();
                dgvOrders.ItemsSource = null;
                dgvOrders.ItemsSource = row.order.manage.list;

            }
            else
            {
                MessageBox.Show("You must select one row");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPrintInvoice control to print an invoice.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnPrintInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice i=(Invoice)dgvInvoices.SelectedItem;

            if (i!=null)
            {
                Print p = new Print(i);
                p.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select an invoice");
            }

            
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the dgvInvoices control to change the status of accounted.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void dgvInvoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Invoice invoice = (Invoice)dgvInvoices.SelectedItem;
            List<Invoice> data = new List<Invoice>();
            Boolean ilegalUp = false, ilegalDown = false;

            if (invoice!=null)
            {
                data = (List<Invoice>)dgvInvoices.ItemsSource;
                
                int index = dgvInvoices.SelectedIndex;

                if (invoice.accounted == 0)
                {

                    for (int i = 0; i <= index; i++)
                    {
                        Invoice aux = data[i];

                        if (aux.accounted == 1)
                        {
                            ilegalUp = true;
                        }
                    }
                    for (int i = index; i < dgvInvoices.Items.Count; i++)
                    {
                        Invoice aux = data[i];
                        
                        if (index == dgvInvoices.Items.Count - 1)
                        {
                            if (aux.accounted == 0)
                            {
                                ilegalDown = false;
                            }
                        }
                        else
                        {
                            if (i!=index)
                            {
                                if (aux.accounted == 0)
                                {
                                    ilegalDown = true;
                                }
                            }
                        }
                    }

                }
                else
                {
                    ilegalUp = false;
                    ilegalDown = false;
                }

                if (ilegalUp || ilegalDown)
                {
                    MessageBox.Show("You have to account the previous invoices");
                }
                else
                {

                    if (invoice.accounted==0)
                    {
                        invoice.accounted = 1;
                    }
                    else
                    {
                        invoice.accounted = 0;
                    }

                    invoice.modifyAccounted();

                    invoice.readAllInvoices();
                    dgvInvoices.ItemsSource = null;
                    dgvInvoices.ItemsSource = invoice.manage.invoices;
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the btnFillCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFillCustomer_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            String[] names = { "Lucas", "Ana", "Pepe", "Marta", "David" };
            String[] surnames = { "Perez", "Lopez", "Jimenez", "Briñas", "Exposito" };
            String[] adresses = { "calle las viñas", "calle Almeida", "calle España", "calle Portugal", "calle tomiño" };
            String[] phones = { "664112455","776554322", "658124506", "658126709", "156789032" };
            String[] emails = { "lucas@gmail.com", "ana@gmail.com", "pepe@gmail.com", "marta@gmail.com", "david@gmail.com" };
            int[] refzipcodescities = { 30206, 28822, 28066, 31333, 32357 };
            String[] nifs = { "05123133D", "08765133F", "06782345A", "03456788G", "03456788D" };

            Customer customer = new Customer();
            
            for (int i = 0; i < 100; i++)
            {
                customer.id = i + 5;
                customer.name = names[r.Next(0,5)];
                customer.surname = surnames[r.Next(0, 5)];
                customer.adress = adresses[r.Next(0, 5)];
                customer.phone = phones[r.Next(0, 5)];
                customer.email = emails[r.Next(0, 5)];
                customer.idzipcodescities = refzipcodescities[r.Next(0, 5)];
                customer.nif = nifs[r.Next(0, 5)];
                try
                {
                    customer.insertToFill();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            customer.readAll();

            dgvCustomers.ItemsSource = null;
            dgvCustomers.ItemsSource = customer.manage.list;
        }
        /// <summary>
        /// Handles the Click event of the btnFillProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFillProduct_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            String[] names = { "Jordan Air", "Jordan Force", "Jordan Night", "Jordan Black", "Jordan Space" };
            Double[] prices = { 100.75, 200.99, 75.99, 120.99, 300.99 };

            Product product = new Product();
            
            for (int i = 0; i < 100; i++)
            {
                product.id = i + 5;
                product.name = names[r.Next(0, 5)];
                product.price = prices[r.Next(0, 5)];
                product.measure = new Measure(r.Next(1, 4));
                product.color = new Domain.Color(r.Next(1, 4));

                try
                {
                    product.insertToFill();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            product.readAll();

            dgvProducts.ItemsSource = null;
            dgvProducts.ItemsSource = product.manage.list;
        }
        /// <summary>
        /// Handles the Click event of the btnFillOrder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFillOrder_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            Double[] prices = { 100.75, 200.99, 75.99, 120.99, 300.99 };
            Double[] prepaids = { 25, 15, 50, 65, 35 };

            OrderProducts p = new OrderProducts();
            List<OrderProducts> products = new List<OrderProducts>();

            Order order = new Order();
            
            for (int i = 0; i < 100; i++)
            {
                order.id = i + 6;
                order.customer =new Customer(r.Next(1, 10));
                order.user =new User(r.Next(1, 4));
                order.paymentmethod = new Paymentmethods(r.Next(1, 4));
                order.total = prices[r.Next(1, 4)];
                order.prepaid= prepaids[r.Next(1, 4)];
                order.confirmed = 0;
                order.labeled = 0;
                order.sent = 0;
                order.invoiced = 0;

                p.id = r.Next(1, 4);
                p.amountSale = 1;
                p.priceSale = order.total;

                products.Add(p);

                order.manage.products = products;

                try
                {
                    order.insertToFill();
                }
                catch (Exception)
                {
                    throw;
                }

                products.Clear();
            }
            
            order.readAll();

            dgvOrders.ItemsSource = null;
            dgvOrders.ItemsSource = order.manage.list;
        }
        /// <summary>
        /// Handles the Initialized event of the tbiIncidents control to inicialice the data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbiIncidents_Initialized(object sender, EventArgs e)
        {
            Incident incident = new Incident();
            incident.readAll();

            dgvIncidents.ItemsSource = incident.manage.incidents;
        }
        /// <summary>
        /// Handles the Click event of the btnZoomIncident control to look an incident.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnZoomIncident_Click(object sender, RoutedEventArgs e)
        {
            Incident incident = new Incident();
            Order order = new Order();
            Invoice invoice = new Invoice();
            ControlIncident controlIncident;
            List<Incident> data = new List<Incident>();


            if (dgvIncidents.SelectedItems.Count == 1)
            {

                data = (List<Incident>)dgvIncidents.ItemsSource;

                Incident row = (Incident)dgvIncidents.SelectedItems[0];

                controlIncident = new ControlIncident(row,languaje);
                controlIncident.ShowDialog();

                row.readAll();
                order.readAll();
                invoice.readAllInvoices();

                dgvIncidents.ItemsSource = null;
                dgvIncidents.ItemsSource = row.manage.incidents;

                dgvOrders.ItemsSource = null;
                dgvOrders.ItemsSource = order.manage.list;

                dgvInvoices.ItemsSource = null;
                dgvInvoices.ItemsSource = invoice.manage.invoices;
            }
            else
            {
                MessageBox.Show("You must select one row");
            }
        }
        /// <summary>
        /// Handles the Click event of the btnDataIncident control to open the Incident data Window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDataIncident_Click(object sender, RoutedEventArgs e)
        {
            DataIncidents di = new DataIncidents(languaje);
            di.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the btnPrintIncidents control to print the list of incidents.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnPrintIncidents_Click(object sender, RoutedEventArgs e)
        {
            PrintIncidents printIncidents = new PrintIncidents();
            printIncidents.ShowDialog();
        }
    }
}
