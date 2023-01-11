using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task2
{
    internal class Manager : Consultant
    {
        public Manager(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public void SurnameChange(string surname)
        {
            client.surname = surname;
        }
        public void NameChange(string name)
        {
            client.name = name;
        }
        public void SecondnameChange(string secondname)
        {
            client.secondName = secondname;
        }
        public void PassportChange(string passport)
        {
            client.passportNumber = passport;
        }
    }
}
