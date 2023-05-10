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

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Consultant consultant;
        Manager manager;

        string path = "clients.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            combobox_employees.Items.Clear();
            combobox_employees.Items.Add("Manager");
            combobox_employees.Items.Add("Client");

            Refresh();
        }

        private void Refresh()
        {
            ComboboxClientsRefresh(path);

            if (combobox_employees.SelectedIndex == 0)
            {
                butt_add.IsEnabled = true;

                if(checkbox_editable.IsChecked != true)
                {
                    TextBoxesSet(false);
                }
                else
                {
                    TextBoxesSet(true);
                }
            }
            else if(combobox_employees.SelectedIndex == 1)
            {
                butt_add.IsEnabled = false;

                if (checkbox_editable.IsChecked != true)
                {
                    text_phone.IsEnabled = false;
                }
                else
                {
                    text_phone.IsEnabled = true;
                }
            }

            TextsSetEmpty();
        }

        private void ComboboxClientsRefresh(string path)
        {
            combobox_clients.Items.Clear();

            List<string> clientsNames = new List<string>();

            Clients clients = new Clients().Deserialize(path);

            for (int i = 0; i < clients.list.Count; i++)
            {
                clientsNames.Add(clients.list[i].surname);
            }

            combobox_clients.ItemsSource = clientsNames;
        }

        private void TextBoxesSet(bool isEnabled)
        {
            text_surname.IsEnabled = isEnabled;
            text_name.IsEnabled = isEnabled;
            text_secondName.IsEnabled = isEnabled;
            text_phone.IsEnabled = isEnabled;
            text_passport.IsEnabled = isEnabled;
        }

        private void TextsSetEmpty()
        {
            text_surname.Text = "";
            text_name.Text = "";
            text_secondName.Text = "";
            text_phone.Text = "";
            text_passport.Text = "";
            text_surnameEdit.Text = "";
            text_nameEdit.Text = "";
            text_secondNameEdit.Text = "";
            text_phoneEdit.Text = "";
            text_passportEdit.Text = "";
        }
    }
}
