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
        public string surname { set; get; }
        public string name { set; get; }
        public string secondName { set; get; }
        public string phone { set; get; }
        public string passport { set; get; }

        public DateTime editTime { set; get; }
        public List<string> editedData { set; get; }
        public List<string> editType { set; get; }
        public string editUser { set; get; }


        public Client() 
        {
            surname = "";
            name = "";
            secondName = string.Empty;
            phone = string.Empty;
            passport = string.Empty;

            editTime = DateTime.Now;
            editedData = new List<string>();
            editType = new List<string>();
            editUser = string.Empty;

        }

        public Client Deserialize(string path)
        {
            string str = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Client>(str);
        }

        public JObject Serialize(/*string path*/)
        {
            JObject jObject = new JObject();
            jObject["surname"] = surname;
            jObject["name"] = name;
            jObject["secondName"] = secondName;
            jObject["phoneNumber"] = phone;
            jObject["passportNumber"] = passport;
            jObject["editTime"] = editTime;

            JArray editedDatas = new JArray();
            JArray editTypes = new JArray();
            for(int i = 0; i < editedData.Count; i++)
            {
                editedDatas.Add(editedData[i]);
                editTypes.Add(editType[i]);
            }
            jObject["editedData"] = editedDatas;
            jObject["editedType"] = editTypes;

            jObject["editUser"] = editUser;

            //string json = jObject.ToString();
            //File.WriteAllText(path, json);

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

        public Clients Deserialize(string path)
        {
            string str = "";

            try
            {
                str = File.ReadAllText(path);
            }
            catch
            {
                MessageBox.Show("Файл не открывается");
            }

            return JsonConvert.DeserializeObject<Clients>(str);
        }

        public void Serialize(string path)
        {
            JArray array = new JArray();

            foreach(Client client in list)
            {
                array.Add(client.Serialize());
            }

            string json = array.ToString();
            File.WriteAllText(path, json);
        }
    }
}
