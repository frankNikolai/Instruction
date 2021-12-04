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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeXAML employeeXAML = new EmployeeXAML();
            employeeXAML.Show();
            this.Hide();
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            InstructionXAML instructionXAML = new InstructionXAML();
            instructionXAML.Show();
            this.Hide();
        }

        private void Position_Click(object sender, RoutedEventArgs e)
        {
            PositionsXAML positionsXAML = new PositionsXAML();
            positionsXAML.Show();
            this.Hide();
        }

        private void View_Instruction_Click(object sender, RoutedEventArgs e)
        {
            ViewInstructionXAML viewInstructionXAML = new ViewInstructionXAML();
            viewInstructionXAML.Show();
            this.Hide();
        }

        private void Organizations_Click(object sender, RoutedEventArgs e)
        {
            OrganizationsXAML organizationsXAML = new OrganizationsXAML();
            organizationsXAML.Show();
            this.Hide();
        }
    }
}
