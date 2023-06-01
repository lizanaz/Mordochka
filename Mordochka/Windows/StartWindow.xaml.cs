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
using Mordochka.Windows;
using Mordochka.ClassHelper;

namespace Mordochka
{
    public partial class StartWindow : Window
    {
        List<Client> clients = new List<Client>();
        List<string> sotrList = new List<string>() { "Все", "По фамилии", "По email", "По телефону"};
        List<string> pages = new List<string>() {"10", "50", "200", "Все"};

        public StartWindow()
        {
            InitializeComponent();
            LV.ItemsSource=AppData.beautyEntities.Client.ToList();
            count.Text = LV.Items.Count + " из " + AppData.beautyEntities.Client.Count().ToString();
            cmb.ItemsSource = sotrList;
            cmb.SelectedIndex = 0;
            cmbPages.ItemsSource = pages;
            cmbPages.SelectedIndex = 3;
            Filter();
        }
        private void cmbPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbPages.SelectedIndex)
            {
                case 0:
                    LV.ItemsSource = AppData.beautyEntities.Client.Take(10).ToList();
                    break;
                case 1:
                    LV.ItemsSource = AppData.beautyEntities.Client.Take(50).ToList();
                    break;
                case 2:
                    LV.ItemsSource = AppData.beautyEntities.Client.Take(200).ToList();
                    break;
                case 3:
                    LV.ItemsSource = AppData.beautyEntities.Client.ToList();
                    break;
            }

            LV.Items.Refresh();
        }
        public void Filter()
        {
            clients=AppData.beautyEntities.Client.ToList();
            clients=clients.Where (i=> i.LastName.Contains(txbSearch.Text) || i.Email.Contains(txbSearch.Text) || i.Phone.Contains(txbSearch.Text)).ToList();
            switch (cmb.SelectedIndex)
            {
                case 0:
                    clients = clients.OrderBy(i=>i.ID).ToList();
                    break;
                case 1:
                    clients= clients.OrderBy(i=>i.LastName).ToList();
                    break;
                case 2:
                    clients=clients.OrderBy(i=>i.Email).ToList();
                    break;
                case 3:
                    clients=clients.OrderBy(i=>i.Phone).ToList();
                    break;  
            }

            LV.ItemsSource= clients;
            LV.Items.Refresh();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
            this.Close();
        }


        //if(check.IsChecked == true)
        //{
        //    clients=clients.Where(i=> i.Birthday.Month == DateTime.Now.Month).ToList();
        //}

        //switch (cmbPages.SelectedIndex)
        //{
        //    case 0:
        //        clients = clients.Skip()

        //}

    }


}
