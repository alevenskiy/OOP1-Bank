using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IUser
    {
        Clients GetClients();

        void SetClients();

    }

    abstract class Employee : IUser
    {
        Clients clients;

        public Employee() 
        {
            clients = new Clients();
        }

        public Clients GetClients()
        {
            return clients.Deserialize("clients.json");
        }

        public void SetClients()
        {
            clients.Serialize("clients.json");
        }
    }
}
