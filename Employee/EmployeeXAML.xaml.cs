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
using System.Text.RegularExpressions;

namespace Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeeXAML.xaml
    /// </summary>
    public partial class EmployeeXAML : Window
    {
        Regex specialSymbol = new Regex("([#]|[/]|[=]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
        Regex searchFullNumber = new Regex("([0-9]|[ ])");

        MatchCollection matchSpecialSymbol = null;
        MatchCollection matchSearchFullNumber = null;

        gr691_fnvEntities entities = new gr691_fnvEntities();
        public EmployeeXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEmployee.ItemsSource = entities.Employees.ToList();
            cbPosition.ItemsSource = entities.Position.ToList();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (dgEmployee.SelectedValue as Employees).ID_Employees;
                Employees emp = (from i in entities.Employees where i.ID_Employees == id select i).SingleOrDefault();
                entities.Employees.Remove(emp);
                entities.SaveChanges();
                dgEmployee.ItemsSource = entities.Employees.ToList();
            }
            catch
            {
                MessageBox.Show("Выделите строку из таблицы, которую хотите удалить");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            int en = 1;

            if (txtFirstName.Text == "")
            {
                error.Append($"{en}. Укажите имя\n\n");
                en++;
            }

            if (txtFirstName.Text != null && txtFirstName.Text != "")
            {
                matchSpecialSymbol = specialSymbol.Matches(txtFirstName.Text);
                matchSearchFullNumber = searchFullNumber.Matches(txtFirstName.Text);

                if ( matchSearchFullNumber.Count > 0)
                {
                    error.Append($"{en}. Поле \"имя\" не может состоять из цифр\n\n");
                    en++;
                }
                if (matchSpecialSymbol.Count > 0)
                {
                    error.Append($"{en}. Поле \"имя\" содержит запрещённые символы\n\n");
                    en++;
                }
            }


            if (txtLastName.Text == "")
            {
                error.Append($"{en}. Укажите Фамилию\n\n");
                en++;
            }
            if (txtLastName.Text != null && txtLastName.Text != "")
            {
                matchSpecialSymbol = specialSymbol.Matches(txtLastName.Text);
                matchSearchFullNumber = searchFullNumber.Matches(txtLastName.Text);

                if (matchSearchFullNumber.Count > 0)
                {
                    error.Append($"{en}. Поле \"Фамилия\" не может состоять из цифр\n\n");
                    en++;
                }
                if (matchSpecialSymbol.Count > 0)
                {
                    error.Append($"{en}. Поле \"Фамилия\" содержит запрещённые символы\n\n");
                    en++;
                }
            }


            if (txtMidName.Text == "")
            {
                error.Append($"{en}. Укажите отчество\n\n");
                en++;
            }
            if (txtMidName.Text != null && txtMidName.Text != "")
            {
                matchSpecialSymbol = specialSymbol.Matches(txtMidName.Text);
                matchSearchFullNumber = searchFullNumber.Matches(txtMidName.Text);

                if (matchSearchFullNumber.Count > 0)
                {
                    error.Append($"{en}. Поле \"Отчество\" не может состоять из цифр\n\n");
                    en++;
                }
                if (matchSpecialSymbol.Count > 0)
                {
                    error.Append($"{en}. Поле \"Отчество\" содержит запрещённые символы\n\n");
                    en++;
                }
            }

            if (string.IsNullOrEmpty(datePicker.Text) == true)
            {
                error.Append($"{en}. Укажите дату\n\n");
                en++;
            }

            if (cbPosition.Text == "")
            {
                error.Append($"{en}. Укажите должность\n\n");
                en++;
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    Employees employees = new Employees();
                    employees.FirstName = txtFirstName.Text;
                    employees.LastName = txtLastName.Text;
                    employees.MiddleName = txtMidName.Text;
                    string dd = Convert.ToString(datePicker);
                    employees.Birthday = Convert.ToDateTime(dd);
                    int pos = Convert.ToInt32(cbPosition.SelectedValue);
                    employees.FK_Position = pos;
                    entities.Employees.Add(employees);
                    entities.SaveChanges();
                    dgEmployee.ItemsSource = entities.Employees.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных");
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder onToField = new StringBuilder();

                int id = (dgEmployee.SelectedValue as Employees).ID_Employees;
                Employees emp = (from i in entities.Employees where i.ID_Employees == id select i).SingleOrDefault();
                int en = 1;
                if (txtFirstName.Text != "")
                {
                    if (txtFirstName.Text != null && txtFirstName.Text != "")
                    {
                        matchSpecialSymbol = specialSymbol.Matches(txtFirstName.Text);
                        matchSearchFullNumber = searchFullNumber.Matches(txtFirstName.Text);

                        if (matchSearchFullNumber.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"имя\" не может состоять из цифр\n\n");
                            en++;
                        }
                        if (matchSpecialSymbol.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"имя\" содержит запрещённые символы\n\n");
                            en++;
                        }
                        if (matchSearchFullNumber.Count == 0 && matchSpecialSymbol.Count == 0)
                        {
                            emp.FirstName = txtFirstName.Text;
                        }
                    }
                }



                if (txtLastName.Text != "")
                {
                    if (txtLastName.Text != null && txtLastName.Text != "")
                    {
                        matchSpecialSymbol = specialSymbol.Matches(txtLastName.Text);
                        matchSearchFullNumber = searchFullNumber.Matches(txtLastName.Text);

                        if (matchSearchFullNumber.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"Фамилия\" не может состоять из цифр\n\n");
                            en++;
                        }
                        if (matchSpecialSymbol.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"Фамилия\" содержит запрещённые символы\n\n");
                            en++;
                        }
                        if (matchSearchFullNumber.Count == 0 && matchSpecialSymbol.Count == 0)
                        {
                            emp.LastName = txtLastName.Text;

                        }
                    }
                }


                if (txtMidName.Text != "")
                {
                    if (txtMidName.Text != null && txtMidName.Text != "")
                    {
                        matchSpecialSymbol = specialSymbol.Matches(txtMidName.Text);
                        matchSearchFullNumber = searchFullNumber.Matches(txtMidName.Text);

                        if (matchSearchFullNumber.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"Отчество\" не может состоять из цифр\n\n");
                            en++;
                        }
                        if (matchSpecialSymbol.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"Отчество\" содержит запрещённые символы\n\n");
                            en++;
                        }
                        if (matchSearchFullNumber.Count == 0 && matchSpecialSymbol.Count == 0)
                        {
                            emp.MiddleName = txtMidName.Text;
                        }
                    }
                }

                if (datePicker.Text != "")
                {
                    string dd = Convert.ToString(datePicker);
                    emp.Birthday = Convert.ToDateTime(dd);
                }
                if (cbPosition.Text != "")
                {
                    int pos = Convert.ToInt32(cbPosition.SelectedValue);
                    emp.FK_Position = pos;
                }

                if (onToField.Length == 0)
                {
                    entities.SaveChanges();
                    dgEmployee.ItemsSource = entities.Employees.ToList();
                }
                else
                {
                    MessageBox.Show(onToField.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Выделите строку из таблицы, которую хотите обновить");
            }
        }
    }
}
