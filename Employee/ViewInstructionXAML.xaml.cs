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
    /// Логика взаимодействия для ViewInstructionXAML.xaml
    /// </summary>
    public partial class ViewInstructionXAML : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public ViewInstructionXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgViewInstruction.ItemsSource = entities.View_Instruction.ToList();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            View_Instruction view_Instruction = new View_Instruction();
            view_Instruction.Name = txtName.Text;
            entities.View_Instruction.Add(view_Instruction);
            entities.SaveChanges();
            dgViewInstruction.ItemsSource = entities.View_Instruction.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (dgViewInstruction.SelectedValue as View_Instruction).ID_View_Instruction;
                View_Instruction viewIns = (from i in entities.View_Instruction where i.ID_View_Instruction == id select i).SingleOrDefault();
                entities.View_Instruction.Remove(viewIns);
                entities.SaveChanges();
                dgViewInstruction.ItemsSource = entities.View_Instruction.ToList();
            }
            catch
            {
                MessageBox.Show("Выделите строку из таблицы, которую хотите удалить");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgViewInstruction.SelectedValue as View_Instruction).ID_View_Instruction;
            View_Instruction viewIns = (from i in entities.View_Instruction where i.ID_View_Instruction == id select i).SingleOrDefault();
            viewIns.Name = txtName.Text;
            entities.SaveChanges();
            dgViewInstruction.ItemsSource = entities.View_Instruction.ToList();
        }
    }
}
