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
        private readonly BZEntities dbContext = new BZEntities();
        private readonly Пользователь user;

        public MainWindowView(Пользователь user)
        {
            dbContext.Предпочтения_обучающегося.Load();
            dbContext.Дисциплины.Load();
            this.user = user;
            InitializeComponent();
            FillListBoxes();
        }

        private void FillListBoxes()
        {
            foreach(var child in stackPanel.Children)
            {
                if(child is ComboBox)
                {
                    (child as ComboBox).ItemsSource = dbContext.Дисциплины.ToList();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = dbContext.Предпочтения_обучающегося.ToArray().Last().ID + 1;
            foreach (var child in stackPanel.Children)
            {
                if (child is ComboBox)
                {
                    if ((child as ComboBox).SelectedItem == null)
                    {
                        continue;
                    }

                    var disct = (child as ComboBox).SelectedItem as Дисциплины;
                    if(disct == null)
                    {
                        continue;
                    }

                    var prefear = new Предпочтения_обучающегося()
                    {
                        ID = index,
                        ID_дисциплины = disct.ID_дисциплины,
                        ID_пользователья = user.ID_пользователья,
                        Дисциплины = disct,
                        Пользователь = user
                    };

                    if(user.Предпочтения_обучающегося.Any(x => x.Дисциплины == disct))
                    {
                        continue;
                    }

                    dbContext.Предпочтения_обучающегося.Add(prefear);
                    index++;
                }

            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            this.Close();
        }
    }
}
