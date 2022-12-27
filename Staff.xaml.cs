using System;
using APPBDHostel.StaffPages;
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
    /// Логика взаимодействия для Employeers.xaml
    /// </summary>
    public partial class Staff : Window
    {
        public Staff()
        {
            InitializeComponent();
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainPanel back = new MainPanel();
            this.Close();
            back.Show();
        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StaffPage();
        }

        private void Button_Click_StaffPos(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Staff_Positions();
        }

        private void Button_Click_Pos(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Positions();
        }
    }
}
