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

        protected Clients clients;
        protected MainWindow mainWindow;
        protected string[] changedData = null;
        protected string[] changedType = null;


        public Consultant(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public Clients GetClients()
        {
            if(clients == null)
            {
                clients = new Clients().Deserialize("client.json");
            }

            return clients;
        }

        public void SetClients()
        {
            clients.Serialize("client.json");
        }

        public bool PhoneNumberChange(Client client, string newPhone)
        {
            if (newPhone == "")
            {
                return false;
            }
            else
            {
                client.editTime = DateTime.Now;
                client.editUser = "Client";
                client.editedData.Add("Phone");

                if (client.phone == "")
                {
                    client.editType.Add("Add");
                }
                else
                {
                    client.editType.Add("Change");
                }

                client.phone = newPhone;
                return true;
            }
        }
    }
}
