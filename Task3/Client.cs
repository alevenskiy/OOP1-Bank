using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3
{
    public class Client
    {
        public string surname { set; get; }
        public string name { set; get; }
        public string secondName { set; get; }
        public string phoneNumber { set; get; }
        public string passportNumber { set; get; }

        public DateTime editTime { set; get; }
        public string[] editedData { set; get; }
        public string[] editType { set; get; }
        public string editUser { set; get; }




        public Client Deserialize(string path)
        {
            string str = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Client>(str);
        }

        public void Serialize(string path)
        {
            JObject jObject = new JObject();
            jObject["surname"] = surname;
            jObject["name"] = name;
            jObject["secondName"] = secondName;
            jObject["phoneNumber"] = phoneNumber;
            jObject["passportNumber"] = passportNumber;
            jObject["editTime"] = editTime;

            JArray editedDatas = new JArray();
            JArray editTypes = new JArray();
            for(int i = 0; i < editedData.Length; i++)
            {
                editedDatas.Add(editedData[i]);
                editTypes.Add(editType[i]);
            }
            jObject["editedData"] = editedDatas;
            jObject["editedType"] = editTypes;

            jObject["editUser"] = editUser;

            string json = jObject.ToString();
            File.WriteAllText(path, json);
        }
    }
}
