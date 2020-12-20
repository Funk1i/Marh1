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
using WpfApp1.Models;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MapView.xaml
    /// </summary>
    public partial class MapView : Window
    {
        private readonly BZEntities dbContext;
        private List<Дисциплины> educationRout;
        public MapView(Пользователь user, BZEntities dbContext)
        {
            this.dbContext = dbContext;
            var subjects = dbContext.Дисциплины.ToList();
            educationRout = Analyzer.Analyze(user, subjects).ToList();
            InitializeComponent();
            ShowEducationMap();
        }

        private void ShowEducationMap()
        {
            var index = 0;
            foreach(var child in grid.Children)
            {
                if(child is Label)
                {
                    (child as Label).Content = educationRout[index].Название;
                    index++;

                    if (index == 9)
                        break;
                }
            }    
        }
    }
}
