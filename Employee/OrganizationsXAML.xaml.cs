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
    /// Логика взаимодействия для OrganizationsXAML.xaml
    /// </summary>
    public partial class OrganizationsXAML : Window
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public OrganizationsXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgOrganization.ItemsSource = entities.Organization.ToList();
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
                int id = (dgOrganization.SelectedValue as Organization).ID_Organization;
                Organization org = (from i in entities.Organization where i.ID_Organization == id select i).SingleOrDefault();
                entities.Organization.Remove(org);
                entities.SaveChanges();
                dgOrganization.ItemsSource = entities.Organization.ToList();
            }
            catch
            {
                MessageBox.Show("Выделите строку из таблицы, которую хотите удалить");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Organization organization = new Organization();
            organization.Name = txtName.Text;
            organization.View = txtView.Text;
            organization.LegalAddress = txtLegalAddress.Text;
            organization.Supervisor = txtSupervisior.Text;
            entities.Organization.Add(organization);
            entities.SaveChanges();
            dgOrganization.ItemsSource = entities.Organization.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgOrganization.SelectedValue as Organization).ID_Organization;
            Organization org = (from i in entities.Organization where i.ID_Organization == id select i).SingleOrDefault();
            org.Name = txtName.Text;
            org.View = txtView.Text;
            org.LegalAddress = txtLegalAddress.Text;
            org.Supervisor = txtSupervisior.Text;
            entities.SaveChanges();
            dgOrganization.ItemsSource = entities.Organization.ToList();
        }
    }
}
