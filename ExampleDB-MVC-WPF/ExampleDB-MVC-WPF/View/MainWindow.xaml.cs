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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ExampleDB_MVC_WPF
{
    
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            changeLanguage();
            
        }
        /// <summary>
        /// Handles the Click event of the btnOK control to check if the user and password is correct.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            User user=new User();
            Tabcontrol tab = null;

            user.name = txtLogin.Text;
            user.password = pwdPassword.Password;

            Boolean exist = user.check();

            if (exist)
            {
                user.getIduser();
                tab = new Tabcontrol(user);
                tab.Show();
                this.Close();
            }
            else
                MessageBox.Show("User not found");
        }
        /// <summary>
        /// Handles the Click event of the btnOK_Copy1 control to end the program.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnOK_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Changes the language.
        /// </summary>
        private void changeLanguage()
        {
            lblLogin.Content = Res.Usuario;
            lblPassword.Content = Res.Contraseña;
            btnOK.Content = Res.Entrar;
            btnOK_Copy1.Content = Res.Cerrar;
        }
    }
}
