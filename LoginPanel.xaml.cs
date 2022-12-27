using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.Data.Entity;
using APPBDHostel;

namespace APPBDHostel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginPanel : Window
    {

        public LoginPanel()
        {
            InitializeComponent();
        }

        DB database = new DB();

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                
                passField.Text = pass.Password; // скопируем в TextBox из PasswordBox
                passField.Visibility = Visibility.Visible; // TextBox - отобразить
                pass.Visibility = Visibility.Hidden; // PasswordBox - скрыть
                ImNo.Visibility = Visibility.Hidden;
                ImYes.Visibility = Visibility.Visible;

            }
            else
            {
                
                pass.Password = passField.Text; // скопируем в PasswordBox из TextBox 
                passField.Visibility = Visibility.Hidden; // TextBox - скрыть
                pass.Visibility = Visibility.Visible; // PasswordBox - отобразить
                ImNo.Visibility = Visibility.Visible;
                ImYes.Visibility = Visibility.Hidden;
            }

            
        }
        public void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            database.openConnection();

            var userLogin = loginField.Text;
            var userPassword = pass.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable datatable = new DataTable();

            string sqlQuery = $"SELECT id_employeer, login, password FROM employeers WHERE login = '{userLogin}' and password = '{userPassword}'";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, database.getConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(datatable);

            if (datatable.Rows.Count == 1)
            {
                string sqlGetRole = $"SELECT account FROM employeers WHERE login = '{userLogin}'";

                SqlCommand comm = new SqlCommand(sqlGetRole, database.getConnection());

                

                MessageBox.Show("Успешная авторизация!");
                MainPanel join = new MainPanel();
                this.Close();
                join.Show();
                DB.Login = userLogin;
            }
            else
            {
                LoginWarning.Visibility = Visibility.Visible;
            }

            database.closeConnection();
        }
    }
}
