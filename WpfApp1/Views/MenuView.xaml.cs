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

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        private readonly Пользователь user;
        private readonly BZEntities dbContext;
        public MenuView(Пользователь user, BZEntities dbContext)
        {
            this.user = user;
            this.dbContext = dbContext;
            InitializeComponent();
        }

        //Добавить пердпочитаемы предметы
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindowView(user, dbContext);
            window.Show();
        }

        //Показать карту равития
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mapWindow = new MapView(user, dbContext);
            mapWindow.Show();
        }
    }
}
