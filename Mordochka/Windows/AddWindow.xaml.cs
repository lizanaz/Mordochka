using Mordochka.EF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mordochka.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent(); 
            gender.ItemsSource = ClassHelper.AppData.beautyEntities.Gender.ToList();
            gender.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.FirstName = fname.Text;
            client.LastName = lname.Text;
            client.Phone = phone.Text;
            var cmb = gender.SelectedItem as Gender;
            client.GenderCode = cmb.Code;
            client.RegistrationDate = DateTime.Now;

            ClassHelper.AppData.beautyEntities.Client.Add(client);
            ClassHelper.AppData.beautyEntities.SaveChanges();
            MessageBox.Show("Added");
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
