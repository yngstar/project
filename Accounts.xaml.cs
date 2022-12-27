using APPBDHostel.AccountPages;
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

namespace APPBDHostel
{
    /// <summary>
    /// Логика взаимодействия для Accounts.xaml
    /// </summary>
    public partial class Accounts : Window
    {
        public Accounts()
        {
            InitializeComponent();
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainPanel back = new MainPanel();
            this.Close();
            back.Show();
        }

        private void Button_Click_Accounts(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Account();
        }

        private void Button_Click_AccountsType(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AccountType();
        }
    }
}
