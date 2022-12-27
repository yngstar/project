using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace APPBDHostel
{
    /// <summary>
    /// Логика взаимодействия для Base.xaml
    /// </summary>
    public partial class MainPanel : Window
    {
        public MainPanel()
        {
            InitializeComponent();
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1),
                IsEnabled = true
            };
            timer.Tick += (o, e) => { time.Content = DateTime.Now.ToString(); };
            timer.Start();
        }
        static DB database = new DB();

        public static string Login;
        public static int Role;

        static DataTable dt = new DataTable();

        private void MinusBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchText.Text.Length == 0)
            {
                SearchMask.Visibility = Visibility.Visible;
            }
            else
            {
                SearchMask.Visibility = Visibility.Hidden;
            }

            database.openConnection();

            string sql = $"SELECT name,amount_place, amount_rooms, add_info, cost_day FROM rooms_categories WHERE name LIKE '%" + SearchText.Text + "%' OR amount_place LIKE '%" + SearchText.Text + "%' OR add_info LIKE '%" + SearchText.Text + "%' OR cost_day LIKE '%";
            SqlCommand sqlCommand = new SqlCommand(sql, database.getConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();

            dt.Clear();
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt);

            database.closeConnection();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            database.openConnection();

            string sql = $"SELECT VIN, CarImage, CarName, BodyType, GearBox, Places, Speed, TrunkCapacity, Information, HP, CarCost FROM Cars";
            SqlCommand sqlCommand = new SqlCommand(sql, database.getConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dt);

            Role = DB.Role;
            Login = DB.Login;

            User.Text = Login + "!";


            database.closeConnection();
        }

        private void Button_Click_Clients(object sender, RoutedEventArgs e)
        {
            Clients client = new Clients();
            this.Close();
            client.Show();
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {
            Rooms room = new Rooms();
            this.Close();
            //room.Show();
        }

        private void Button_Click_Log(object sender, RoutedEventArgs e)
        {
            Log log = new Log();
            this.Close();
            //log.Show();
        }
        private void Button_Click_Accounts(object sender, RoutedEventArgs e)
        {
            Accounts acc = new Accounts();
            this.Close();
            acc.Show();
        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            this.Close();
            staff.Show();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            LoginPanel relog = new LoginPanel();
            this.Close();
            relog.Show();
        }
    }
}