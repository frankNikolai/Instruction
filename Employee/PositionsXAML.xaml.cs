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

namespace Employee
{
    /// <summary>
    /// Логика взаимодействия для PositionsXAML.xaml
    /// </summary>
    public partial class PositionsXAML : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public PositionsXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgPosition.ItemsSource = entities.Position.ToList();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Position position = new Position();
            position.Name = txtName.Text;
            entities.Position.Add(position);
            entities.SaveChanges();
            dgPosition.ItemsSource = entities.Position.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (dgPosition.SelectedValue as Position).ID_Position;
                Position pos = (from i in entities.Position where i.ID_Position == id select i).SingleOrDefault();
                entities.Position.Remove(pos);
                entities.SaveChanges();
                dgPosition.ItemsSource = entities.Position.ToList();
            }
            catch
            {
                MessageBox.Show("Выделите строку из таблицы, которую хотите удалить");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgPosition.SelectedValue as Position).ID_Position;
            Position position = (from i in entities.Position where i.ID_Position == id select i).SingleOrDefault();
            position.Name = txtName.Text;
            entities.SaveChanges();
            dgPosition.ItemsSource = entities.Position.ToList();
        }

        
    }
}
