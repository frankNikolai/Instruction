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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLogin.Text == "" || txtPassword.Password == "")
                {
                    MessageBox.Show("Заполните пустые поля");
                }
                gr691_fnvEntities entities = new gr691_fnvEntities();
                string log = txtLogin.Text;
                string pass = txtPassword.Password;
                string trueLog = (from i in entities.User_Auto where i.Login == log select i.Login).FirstOrDefault();
                string truePass = (from i in entities.User_Auto where i.Password == pass select i.Password).FirstOrDefault();
                
                if (trueLog != null && truePass != null)
                {
                    MessageBox.Show("Авторизация прошла успешно");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин и/или пароль");
                }
            }
            catch
            {
                MessageBox.Show("Соединение с БД не установлено");
            }
        }

        private void RegistrNow_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();

        }
    }
}
