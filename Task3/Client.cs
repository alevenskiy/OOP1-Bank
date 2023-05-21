using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Task3
{
    public class Client
    {
        public int id { set; get; }
        public string surname { set; get; }
        public string name { set; get; }
        public string secondName { set; get; }
        public string phone { set; get; }
        public string passport { set; get; }
        public string surnameEdit { set; get; }
        public string nameEdit { set; get; }
        public string secondNameEdit { set; get; }
        public string phoneEdit { set; get; }
        public string passportEdit { set; get; }

        public Client() 
        {
            id = 0;

            surname = string.Empty;
            name = string.Empty;
            secondName = string.Empty;
            phone = string.Empty;
            passport = string.Empty;

            surnameEdit = string.Empty;
            nameEdit = string.Empty;
            secondNameEdit = string.Empty;
            phoneEdit = string.Empty;
            passportEdit = string.Empty;

        }

        public JObject Serialize()
        {
            JObject jObject = new JObject();
            jObject["id"] = id;
            jObject["surname"] = surname;
            jObject["name"] = name;
            jObject["secondName"] = secondName;
            jObject["phone"] = phone;
            jObject["passport"] = passport;

            jObject["surnameEdit"] = surnameEdit;
            jObject["nameEdit"] = nameEdit;
            jObject["secondNameEdit"] = secondNameEdit;
            jObject["phoneEdit"] = phoneEdit;
            jObject["passportEdit"] = passportEdit;

            return jObject;
        }
    }

    public class Clients
    {
        public List<Client> list;

        public Clients()
        {
            list = new List<Client>();
        }

        public Clients(List<Client> list)
        {
            this.list = list;
        }

        public Clients Deserialize(string path)
        {
            string str = "";

            try
            {
                str = File.ReadAllText(path);
            }
            catch
            {
                MessageBox.Show("File does not open");
            }

            Clients clients = new Clients(JsonConvert.DeserializeObject<List<Client>>(str));

            return clients;
        }

        public void Serialize(string path)
        {
            JArray array = new JArray();

            foreach(Client client in list)
            {
                array.Add(client.Serialize());
            }

            string json = array.ToString();

            try
            {
                File.WriteAllText(path, json);
            }
            catch 
            {
                MessageBox.Show("File does not open");
            }
        }
    }
}
