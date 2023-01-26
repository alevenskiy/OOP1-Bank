using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3
{
    internal class Manager : Consultant
    {
        public Manager(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public void SurnameChange(Client client, string surname)
        {
            client.editTime = DateTime.Now;
            client.editUser = "Manager";
            client.editedData.Add("Surname");

            if(surname == "")
            {
                client.editType.Add("delete");
            }
            else if(client.surname == "")
            {
                client.editType.Add("add");
            }
            else
            {
                client.editType.Add("change");
            }

            client.surname = surname;
        }
        public void NameChange(Client client, string name)
        {
            client.editTime = DateTime.Now;
            client.editUser = "Manager";
            client.editedData.Add("Name");

            if (name == "")
            {
                client.editType.Add("delete");
            }
            else if (client.name == "")
            {
                client.editType.Add("add");
            }
            else
            {
                client.editType.Add("change");
            }

            client.name = name;
        }
        public void SecondnameChange(Client client, string secondname)
        {
            client.editTime = DateTime.Now;
            client.editUser = "Manager";
            client.editedData.Add("Second Name");

            if (secondname == "")
            {
                client.editType.Add("delete");
            }
            else if (client.secondName == "")
            {
                client.editType.Add("add");
            }
            else
            {
                client.editType.Add("change");
            }

            client.secondName = secondname;
        }
        public void PassportChange(Client client, string passport)
        {
            client.editTime = DateTime.Now;
            client.editUser = "Manager";
            client.editedData.Add("Passport");

            if (passport == "")
            {
                client.editType.Add("delete");
            }
            else if (client.passport == "")
            {
                client.editType.Add("add");
            }
            else
            {
                client.editType.Add("change");
            }

            client.passport = passport;
        }
    }
}
