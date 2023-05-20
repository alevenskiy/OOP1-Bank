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
        public Manager(MainWindow mainWindow) : base(mainWindow) { }

        public void SurnameChange(Client client, string surname)
        {
            if(surname == "")
            {
                client.surnameEdit = "Delete by Manager at " + DateTime.Now.ToString();
            }
            else if(client.surname == "")
            {
                client.surnameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else
            {
                client.surnameEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.surname = surname;
        }
        public void NameChange(Client client, string name)
        {
            if (name == "")
            {
                client.nameEdit = "Delete by Manager at " + DateTime.Now.ToString();
            }
            else if (client.name == "")
            {
                client.nameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else
            {
                client.nameEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.name = name;
        }
        public void SecondnameChange(Client client, string secondname)
        {
            if (secondname == "")
            {
                client.secondNameEdit = "Delete by Manager at " + DateTime.Now.ToString();
            }
            else if (client.secondName == "")
            {
                client.secondNameEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else
            {
                client.secondNameEdit = "Chenge by Manager at " + DateTime.Now.ToString();
            }

            client.secondName = secondname;
        }

        public void PhoneChange(Client client, string phone)
        {
            if (phone == "")
            {
                client.phoneEdit = "Delete by Manager at " + DateTime.Now.ToString();
            }
            else if (client.phone == "")
            {
                client.phoneEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else
            {
                client.phoneEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.phone = phone;
        }

        public void PassportChange(Client client, string passport)
        {
            if (passport == "")
            {
                client.passportEdit = "Delete by Manager at " + DateTime.Now.ToString();
            }
            else if (client.passport == "")
            {
                client.passportEdit = "Add by Manager at " + DateTime.Now.ToString();
            }
            else
            {
                client.passportEdit = "Change by Manager at " + DateTime.Now.ToString();
            }

            client.passport = passport;
        }
    }
}
