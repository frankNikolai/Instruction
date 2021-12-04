using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Instruction.xaml
    /// </summary>
    public partial class InstructionXAML : Window
    {
        Regex specialSymbol = new Regex("([#]|[/]|[=]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$])");
        Regex searchFullNumber = new Regex("([0-9]|[ ])");

        MatchCollection matchSpecialSymbol = null;
        MatchCollection matchSearchFullNumber = null;

        gr691_fnvEntities entities = new gr691_fnvEntities();
        public InstructionXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgInstruction.ItemsSource = entities.Instruction.ToList();
            cbName.ItemsSource = entities.Employees.ToList();
            cbView.ItemsSource = entities.View_Instruction.ToList();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            try
            {
                int id = (dgInstruction.SelectedItem as Instruction).ID_Instruction;
                Instruction ins = (from i in entities.Instruction where i.ID_Instruction == id select i).SingleOrDefault();
                entities.Instruction.Remove(ins);
                entities.SaveChanges();
                dgInstruction.ItemsSource = entities.Instruction.ToList();
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

            if (string.IsNullOrEmpty(datePicker.Text) == true)
            {
                error.Append($"{en}. Укажите дату\n\n");
                en++;
            }
            if (cbName.Text == null || cbName.Text == "")
            {
                error.Append($"{en}. Укажите инструктора\n\n");
                en++;
            }
            if (cbView.Text == null || cbView.Text == "")
            {
                error.Append($"{en}. Укажите вид\n\n");
                en++;
            }
            if (string.IsNullOrEmpty(txtNote.Text) == true)
            {
                error.Append($"{en}. Укажите примечание\n\n");
                en++;
            }
            else
            {
                if (txtNote.Text != null && txtNote.Text != "")
                {
                    matchSpecialSymbol = specialSymbol.Matches(txtNote.Text);
                    matchSearchFullNumber = searchFullNumber.Matches(txtNote.Text);

                    if (matchSearchFullNumber.Count > 0)
                    {
                        error.Append($"{en}. Поле \"примечание\" не может состоять из цифр\n\n");
                        en++;
                    }
                    if (matchSpecialSymbol.Count > 0)
                    {
                        error.Append($"{en}. Поле \"примечание\" содержит запрещённые символы\n\n");
                        en++;
                    }
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    Instruction instruction = new Instruction();
                    string dd = Convert.ToString(datePicker);
                    instruction.Date = Convert.ToDateTime(dd);
                    int emp = Convert.ToInt32(cbName.SelectedValue);
                    int view = Convert.ToInt32(cbView.SelectedValue);
                    instruction.FK_InstructionEmployees = emp;
                    instruction.FK_ViewInstruction = view;
                    instruction.Note = txtNote.Text;
                    entities.Instruction.Add(instruction);
                    entities.SaveChanges();
                    dgInstruction.ItemsSource = entities.Instruction.ToList();
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

                bool onToWay = false;

                int id = (dgInstruction.SelectedValue as Instruction).ID_Instruction;
                Instruction ins = (from i in entities.Instruction where i.ID_Instruction == id select i).SingleOrDefault();

                if (datePicker.Text != "")
                {
                    string dd = Convert.ToString(datePicker);
                    ins.Date = Convert.ToDateTime(dd);
                }
                if (cbName.Text != "")
                {
                    int emp = Convert.ToInt32(cbName.SelectedValue);
                    ins.FK_InstructionEmployees = emp;
                }
                if (cbView.Text != "")
                {
                    int view = Convert.ToInt32(cbView.SelectedValue);
                    ins.FK_ViewInstruction = view;
                }
                if (txtNote.Text != "")
                {
                    if (txtNote.Text != null && txtNote.Text != "")
                    {
                        matchSpecialSymbol = specialSymbol.Matches(txtNote.Text);
                        matchSearchFullNumber = searchFullNumber.Matches(txtNote.Text);

                        int en = 1;
                        if (matchSearchFullNumber.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"примечание\" не может состоять из цифр\n\n");
                            en++;
                        }
                        if (matchSpecialSymbol.Count > 0)
                        {
                            onToField.Append($"{en}. Поле \"примечание\" содержит запрещённые символы\n\n");
                            en++;
                        }
                        if (matchSearchFullNumber.Count == 0 && matchSpecialSymbol.Count == 0)
                        {
                            ins.Note = txtNote.Text;
                        }
                        
                    }
                }

                if (onToField.Length == 0)
                {
                    entities.SaveChanges();
                    dgInstruction.ItemsSource = entities.Instruction.ToList();
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
