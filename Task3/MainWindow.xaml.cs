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
        Client currentClient;

        //string path = "clients.json";

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
            if (File.Exists("clients.json"))
            {

                ComboboxClientsRefresh("clients.json");

                butt_cancel.Visibility = Visibility.Collapsed; // creating mod off
                butt_save.Content = "Save";
                checkbox_editable.IsChecked = false;

                if (combobox_employees.SelectedIndex == 0) //manager
                {
                    butt_create.IsEnabled = true;
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
                    butt_create.IsEnabled = false;
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
                    butt_create.IsEnabled = false;
                    combobox_clients.IsEnabled = false;
                }

                TextsSetEmpty();
            }
            else
            {
                File.Create("clients.json");
            }
        }

        private void ComboboxClientsRefresh(string path)
        {
            combobox_clients.ItemsSource = null;

            List<string> clientsNames = new List<string>();

            Clients clients = new Clients().Deserialize(path);

            windowClients = clients;

            if (/*clients != null && */clients.list != null)
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

            butt_cancel.Visibility = Visibility.Visible; // creating mod on
            butt_save.Content = "Add and Save";

            TextsSetEmpty();
        }

        private void butt_save_Click(object sender, RoutedEventArgs e)
        {
            if (EmptyTextBoxesCheck())
            {
                MessageBox.Show("All fields must be filled in");
            }
            //else if (DuplicateClientSurname(text_surname.Text))
            //{
            //    MessageBox.Show("Client with this Surname is already in base");
            //}
            else
            {
                Employee emp;

                if (combobox_employees.SelectedIndex == 0)
                {
                    emp = new Manager();
                }
                else
                {
                    emp = new Consultant();
                }

                Clients clients = emp.GetClients();

                Client client = new Client();

                if (clients.list == null || clients.list.Count == 0) //creating mod check
                {
                    clients = new Clients();
                }
                else if (butt_cancel.Visibility == Visibility.Visible) //adding mod check
                {
                    client.id = clients.list[clients.list.Count - 1].id + 1;
                }
                else //editing
                {
                    client = currentClient;
                }

                //if (butt_cancel.Visibility == Visibility.Visible) //creating mod check
                //{
                //    client = (emp as Manager).SurnameChange(client, text_surname.Text);
                //    client = (emp as Manager).NameChange(client, text_name.Text);
                //    client = (emp as Manager).SecondNameChange(client, text_secondName.Text);
                //    client = (emp as Manager).PhoneChange(client, text_phone.Text);
                //    client = (emp as Manager).PassportChange(client, text_passport.Text);


                //    //client.surname = text_surname.Text;
                //    //client.name = text_name.Text;
                //    //client.secondName = text_secondName.Text;
                //    //client.phone = text_phone.Text;
                //    //client.passport = text_passport.Text;

                //    //client.surnameEdit = "Add by Manager at " + DateTime.Now.ToString();
                //    //client.nameEdit = "Add by Manager at " + DateTime.Now.ToString();
                //    //client.secondNameEdit = "Add by Manager at " + DateTime.Now.ToString();
                //    //client.phoneEdit = "Add by Manager at " + DateTime.Now.ToString();
                //    //client.passportEdit = "Add by Manager at " + DateTime.Now.ToString();
                //}
                //else
                //{
                if (combobox_employees.SelectedIndex == 0)
                {
                    client = (emp as Manager).SurnameChange(client, text_surname.Text);
                    client = (emp as Manager).NameChange(client, text_name.Text);
                    client = (emp as Manager).SecondNameChange(client, text_secondName.Text);
                    client = (emp as Manager).PhoneChange(client, text_phone.Text);
                    client = (emp as Manager).PassportChange(client, text_passport.Text);
                }
                else
                {
                    client = (emp as Consultant).PhoneChange(client, text_phone.Text);
                }
                //}

                if (butt_cancel.Visibility == Visibility.Visible)
                {
                    clients.list.Add(client);
                }
                else
                {
                    for(int i = 0; i < clients.list.Count; i++)
                    {
                        if(clients.list[i].id == client.id)
                        {
                            clients.list.Remove(clients.list[i]);
                            clients.list.Insert(i, client);
                        }
                    }
                }

                clients.Serialize("clients.json");

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

        private void combobox_clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Client client in windowClients.list)
            {
                if (combobox_clients.SelectedItem != null)
                {
                    if (combobox_clients.SelectedItem.ToString() == client.surname)
                    {
                        currentClient = client;
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

        private void butt_cancel_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void checkbox_editable_Checked(object sender, RoutedEventArgs e)
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
    }
}
