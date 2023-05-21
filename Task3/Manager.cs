using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3
{
    internal class Manager : Employee
    {
        public Manager() : base() { }

        public Client SurnameChange(Client client, string surname)
        {
            if(client.surname == "")
            {
                client.surnameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else if (client.surname != surname)
            {
                client.surnameEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.surname = surname;

            return client;
        }
        public Client NameChange(Client client, string name)
        {
            if (client.name == "")
            {
                client.nameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else if (client.name != name)
            {
                client.nameEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.name = name;

            return client;
        }
        public Client SecondNameChange(Client client, string secondname)
        {
            if (client.secondName == "")
            {
                client.secondNameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else if (client.secondName != secondname)
            {
                client.secondNameEdit = "Chenge by Manager at " + DateTime.Now.ToString();
            }

            client.secondName = secondname;

            return client;
        }
        public Client PhoneChange(Client client, string phone)
        {
            if (client.phone == "")
            {
                client.phoneEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else if(client.phone != phone)
            {
                client.phoneEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.phone = phone;

            return client;
        }
        public Client PassportChange(Client client, string passport)
        {
            if (client.passport == "")
            {
                client.passportEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else if (client.passport != passport)
            {
                client.passportEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.passport = passport;

            return client;
        }
    }
}
