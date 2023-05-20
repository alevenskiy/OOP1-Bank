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

        protected Clients clients;
        protected MainWindow mainWindow;
        protected string[] changedData = null;
        protected string[] changedType = null;


        public Consultant(MainWindow mainWindow) : base(mainWindow) { }

        public bool PhoneChange(Client client, string newPhone)
        {
            if (newPhone == "")
            {
                return false;
            }
            else
            {
                if (client.phone == "")
                {
                    client.phoneEdit = "Add by Consultant at " + DateTime.Now.ToString();
                }
                else
                {
                    client.phoneEdit = "Change by Consultant at " + DateTime.Now.ToString();
                }

                client.phone = newPhone;
                return true;
            }
        }
    }
}
