using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task3
{
    internal class Consultant
    {

        protected Client client;
        protected MainWindow mainWindow;
        protected string[] changedData = null;
        protected string[] changedType = null;


        public Consultant(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void LoadClient()
        {
            client = new Client().Deserialize("client.json");
            //mainWindow.text_surname.Text = client.surname;
            //mainWindow.text_name.Text = client.name;
            //mainWindow.text_secondname.Text = client.secondName;
            //mainWindow.text_phone.Text = client.phoneNumber;
            //if (client.passportNumber != "")
            //    mainWindow.text_passport.Text = "*******************";
        }

        public bool PhoneNumberChange(string newPhone)
        {
            if (newPhone == "")
            {
                mainWindow.grid_supp.Visibility = Visibility.Visible;
                mainWindow.text_supp.Text = "Phone number can not be empty";
                return false;
            }
            else
            {
                mainWindow.grid_supp.Visibility = Visibility.Collapsed;
                client.phoneNumber = newPhone;

                changedData = new string[] { " phone"};
                changedType = new string[] { " change" };

                return true;

            }

        }

        public bool SaveClient()
        {
            //if (PhoneNumberChange(mainWindow.text_phone.Text))
            //{
            //    client.surname = mainWindow.text_surname.Text;
            //    client.name = mainWindow.text_name.Text;
            //    client.secondName = mainWindow.text_secondname.Text;
            //    client.phoneNumber = mainWindow.text_phone.Text;
            //    client.passportNumber = mainWindow.text_passport.Text;

            //    client.Serialize("client.json");
            //    return true;
            //}
            client.surname = mainWindow.datagrid_clients.SelectedItems[0].ToString(); // еще проверять надо работает ли этот код.. эх
            client.name = mainWindow.datagrid_clients.SelectedItems[1].ToString();
            client.secondName = mainWindow.datagrid_clients.SelectedItems[2].ToString();
            client.phoneNumber = mainWindow.datagrid_clients.SelectedItems[3].ToString();
            client.passportNumber = mainWindow.datagrid_clients.SelectedItems[4].ToString();

            client.editTime = DateTime.Now;
            client.editedData = changedData;
            client.editType = changedType;
            client.editUser = "Client";

            return false;
        }

    }
}
