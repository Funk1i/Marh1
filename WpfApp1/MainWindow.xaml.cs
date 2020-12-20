using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BZEntities dbContext = new BZEntities();
        public MainWindow()
        {
            dbContext.Пользователь.Load();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login_tb.Text;
            var password = Password_tb.Password;

            var user = dbContext.Пользователь.FirstOrDefault(x => x.Логин == login && x.Пароль == password);

            if(user != null)
            {
                var mainPage = new MenuView(user, dbContext);
                mainPage.Show();
                this.Close();
            }
            else
            {
                Error_lbl.Content = "Не верно введен логин или пароль";
            }
        }
    }
}
