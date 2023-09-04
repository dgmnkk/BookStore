using data_access;
using data_access.Interfaces;
using data_access.Repositories;
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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnitOfWork uow = new UnitOfWork();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user = uow.UserRepo.Get(x => x.Login == loginBox.Text && x.Password == passwordBox.Text).FirstOrDefault();
            if(user != null)
            {
               
               BookStoreInfo bookStoreInfo = new BookStoreInfo();
               bookStoreInfo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password! Try again");
                loginBox.Text = string.Empty;
                passwordBox.Text = string.Empty;
            }
        }
    }
}
