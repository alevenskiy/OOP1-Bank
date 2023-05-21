using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task3
{
    internal class Consultant : Employee
    {
        public Consultant() : base() { }

        public Client PhoneChange(Client client, string phone)
        {
            if (client.phone == "")
            {
                client.phoneEdit = "Add by Consultant at " + DateTime.Now.ToString();
            }
            else if (client.phone != phone)
            {
                client.phoneEdit = "Change by Consultant at " + DateTime.Now.ToString();
            }
            client.phone = phone;

            return client;
        }
    }
}
