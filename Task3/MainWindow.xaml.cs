using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        Clients windowClients;

        string path = "clients.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (File.Exists(path))
            {

                ComboboxClientsRefresh(path);

                if (combobox_employees.SelectedIndex == 0) //manager
                {
                    butt_add.IsEnabled = true;
                    checkbox_editable.IsEnabled = true;
                    combobox_clients.IsEnabled = true;

                    if (checkbox_editable.IsChecked != true)
                    {
                        TextBoxesSet(false);
                    }
                    else
                    {
                        TextBoxesSet(true);
                    }
                }
                else if (combobox_employees.SelectedIndex == 1) //consultant
                {
                    butt_add.IsEnabled = false;
                    checkbox_editable.IsEnabled = true;
                    combobox_clients.IsEnabled = true;

                    if (checkbox_editable.IsChecked != true)
                    {
                        text_phone.IsEnabled = false;
                    }
                    else
                    {
                        text_phone.IsEnabled = true;
                    }
                }
                else
                {
                    TextBoxesSet(false);
                    checkbox_editable.IsEnabled = false;
                    butt_add.IsEnabled = false;
                    combobox_clients.IsEnabled = false;
                }

                TextsSetEmpty();
            }
            else
            {
                File.Create(path);
            }
        }

        private void ComboboxClientsRefresh(string path)
        {
            combobox_clients.ItemsSource = null;

            List<string> clientsNames = new List<string>();

            Clients clients = new Clients().Deserialize(path);

            windowClients = clients;

            if (clients != null)
            {
                for (int i = 0; i < clients.list.Count; i++)
                {
                    clientsNames.Add(clients.list[i].surname);
                }

                combobox_clients.ItemsSource = clientsNames;
            }
            else
            {
                MessageBox.Show("Clients base is empty.\nPlease Create new Client as a Manager");
            }
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

        private void combobox_employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void butt_create_Click(object sender, RoutedEventArgs e)
        {
            checkbox_editable.IsChecked = true;

            TextsSetEmpty();
        }

        private void butt_save_Click(object sender, RoutedEventArgs e)
        {
            if (EmptyTextBoxesCheck())
            {
                MessageBox.Show("All fields must be filled in");
            }
            else if (DuplicateClientSurname(text_surname.Text))
            {
                MessageBox.Show("Client with this Surname is already in base");
            }
            else
            {
                Client client = new Client();

                client.surname = text_surname.Text;
                client.name = text_name.Text;
                client.secondName = text_secondName.Text;
                client.phone = text_phone.Text;
                client.passport = text_passport.Text;

                client.surnameEdit = "Add by Manager at " + DateTime.Now.ToString();
                client.nameEdit = "Add by Manager at " + DateTime.Now.ToString();
                client.secondNameEdit = "Add by Manager at " + DateTime.Now.ToString();
                client.phoneEdit = "Add by Manager at " + DateTime.Now.ToString();
                client.passportEdit = "Add by Manager at " + DateTime.Now.ToString();

                Clients clients = new Clients().Deserialize(path);

                if (clients == null)
                {
                    clients = new Clients();
                }

                clients.list.Add(client);

                clients.Serialize(path);

                MessageBox.Show("Save complete");

                Refresh();
            }
        }

        private bool EmptyTextBoxesCheck()
        {
            if( text_surname.Text == "" ||
                text_name.Text == "" ||
                text_secondName.Text == "" ||
                text_phone.Text == "" ||
                text_passport.Text == "")
            {
                return true;
            }
            else
                return false;
        }

        private bool DuplicateClientSurname(string surname)
        {
            foreach (Client client in windowClients.list)
            {
                if(client.surname == surname)
                {
                    return true;
                }
            }
            return false;
        }

        private void checkbox_editable_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_employees.SelectedIndex == 0) //manager
            {
                if (checkbox_editable.IsChecked == true)
                {
                    TextBoxesSet(true);
                }
                else
                {
                    TextBoxesSet(false);
                }
            }
            else
            {
                if (checkbox_editable.IsChecked == true)
                {
                    text_phone.IsEnabled = true;
                }
                else
                {
                    text_phone.IsEnabled = false;
                }
            }
        }

        private void combobox_clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Client client in windowClients.list)
            {
                if (combobox_clients.SelectedItem != null)
                {
                    if (combobox_clients.SelectedItem.ToString() == client.surname)
                    {
                        ShowClient(client);
                        return;
                    }
                }
            }
        }

        private void ShowClient(Client client)
        {
            text_surname.Text = client.surname;
            text_name.Text = client.name;
            text_secondName.Text = client.secondName;
            text_phone.Text = client.phone;
            text_passport.Text = client.passport;

            text_surnameEdit.Text = client.surnameEdit;
            text_nameEdit.Text = client.nameEdit;
            text_secondNameEdit.Text = client.secondNameEdit;
            text_phoneEdit.Text = client.phoneEdit;
            text_passportEdit.Text = client.passportEdit;
        }
    }
}
