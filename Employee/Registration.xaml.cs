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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registr_Button(object sender, RoutedEventArgs e)
        {
            Regex specialSymbol = new Regex("([#]|[/]|[=]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
            Regex searchFullNumber = new Regex("([0-9]|[ ])");

            MatchCollection matchSpecialSymbol = null;
            MatchCollection matchSearchFullNumber = null;


            StringBuilder error = new StringBuilder();
            try
            {
                gr691_fnvEntities entities = new gr691_fnvEntities();

                User_Auto user_Auto = new User_Auto();
                Employees employees = new Employees();

                int en = 1;

                if (txtLogin.Text == "" )
                {
                    error.Append($"{en}. Укажите логин\n\n");
                    en++;
                }

                if (txtLogin.Text == (from i in entities.User_Auto select i.Login).SingleOrDefault())
                {
                    error.Append($"{en}. Логин занят\n\n");
                    en++;
                }

                if (txtLogin.Text != null && txtLogin.Text != "")
                {
                    matchSpecialSymbol = specialSymbol.Matches(txtLogin.Text);
                    matchSearchFullNumber = searchFullNumber.Matches(txtLogin.Text);

                    if (matchSearchFullNumber.Count == txtLogin.Text.Length)
                    {
                        error.Append($"{en}. Поле \"логин\" не может состоять только из цифр\n\n");
                        en++;
                    }
                    if (matchSpecialSymbol.Count > 0)
                    {
                        error.Append($"{en}. Поле \"логин\" содержит запрещённые символы\n\n");
                        en++;
                    }

                }

                if (txtPassword.Text == "")
                {
                    error.Append($"{en}. Укажите пароль\n\n");
                    en++;
                }

                if (txtFistName.Text == "")
                {
                    error.Append($"{en}. Укажите имя\n\n");
                    en++;
                }
                if (txtFistName.Text != null && txtFistName.Text != "")
                {
                    matchSpecialSymbol = specialSymbol.Matches(txtFistName.Text);
                    matchSearchFullNumber = searchFullNumber.Matches(txtFistName.Text);

                    if (matchSearchFullNumber.Count > 0)
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


                if (txtMiddleName.Text == "")
                {
                    error.Append($"{en}. Укажите отчество\n\n");
                    en++;
                }
                if (txtMiddleName.Text != null && txtMiddleName.Text != "")
                {
                    matchSpecialSymbol = specialSymbol.Matches(txtMiddleName.Text);
                    matchSearchFullNumber = searchFullNumber.Matches(txtMiddleName.Text);

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

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    user_Auto.Login = txtLogin.Text;
                    user_Auto.Password = txtPassword.Text;
                    entities.User_Auto.Add(user_Auto);

                    employees.FirstName = txtFistName.Text;
                    employees.LastName = txtLastName.Text;
                    employees.MiddleName = txtMiddleName.Text;
                    string dd = datePicker.Text;
                    employees.Birthday = Convert.ToDateTime(dd);
                    entities.Employees.Add(employees);
                    entities.SaveChanges();

                    string fName = txtFistName.Text;
                    string lName = txtLastName.Text;
                    string mName = txtMiddleName.Text;
                    DateTime date = Convert.ToDateTime(dd);

                    int idEmp = (from i in entities.Employees
                                 where i.FirstName == txtFistName.Text && i.LastName == txtLastName.Text
                                 && i.MiddleName == txtMiddleName.Text && i.Birthday == date
                                 select i.ID_Employees).SingleOrDefault();
                    user_Auto.FK_Employee = idEmp;
                    entities.User_Auto.Add(user_Auto);
                    entities.SaveChanges();

                    MessageBox.Show("Регистрация успешно завершена. Сейчас вас перенаправит на окно авторизации");

                    Authorization authorization = new Authorization();
                    authorization.Show();
                    this.Close();
                }

            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
