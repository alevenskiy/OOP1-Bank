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
        public string surnameEdit { set; get; }
        public string nameEdit { set; get; }
        public string secondNameEdit { set; get; }
        public string phoneEdit { set; get; }
        public string passportEdit { set; get; }

        public Client() 
        {
            surname = "";
            name = "";
            secondName = string.Empty;
            phone = string.Empty;
            passport = string.Empty;

            surnameEdit = "";
            nameEdit = "";
            secondNameEdit = string.Empty;
            phoneEdit = string.Empty;
            passportEdit = string.Empty;

        }

        //public Client Deserialize(string path)
        //{
        //    string str = File.ReadAllText(path);
        //    return JsonConvert.DeserializeObject<Client>(str);
        //}

        public JObject Serialize(/*string path*/)
        {
            JObject jObject = new JObject();
            jObject["surname"] = surname;
            jObject["name"] = name;
            jObject["secondName"] = secondName;
            jObject["phoneNumber"] = phone;
            jObject["passportNumber"] = passport;

            jObject["surnameEdit"] = surnameEdit;
            jObject["nameEdit"] = nameEdit;
            jObject["secondNameEdit"] = secondNameEdit;
            jObject["phoneEdit"] = phoneEdit;
            jObject["passportEdit"] = passportEdit;

            /*jObject["editTime"] = editTime;

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
            */

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
