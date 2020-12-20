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
using System.Windows.Shapes;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private readonly ObrazMarshrutEntities dbContext = new ObrazMarshrutEntities();
        private readonly Пользователь user;

        public MainWindowView(Пользователь user)
        {
            dbContext.Дисциплины.Load();
            this.user = user;
            FillListBoxes();
            InitializeComponent();
        }

        private void FillListBoxes()
        {
            foreach(var child in grid.Children)
            {
                if(child is ListBox)
                {
                    (child as ListBox).ItemsSource = dbContext.Дисциплины.ToList();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Предпочтения_обучающегося.Дисциплины
        }
    }
}
