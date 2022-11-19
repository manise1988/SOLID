using EAfspraak.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.IO;

namespace EAfspraak.Infrastructure
{
    public class DataRepotisory
    {
        string dataPath="";
        
        public DataRepotisory()//string dataPath)
        {
            string baseDirectoryName = new FileInfo(GetType().Assembly.Location).DirectoryName;
            dataPath = Path.Combine(baseDirectoryName, "Data");
        }

        public T? ReadData<T>(string fileName)
        {
           
            var item = File.ReadAllText(@dataPath+ @"\" + fileName +".json");
            if (item.Trim() != "")
                return JsonSerializer.Deserialize<T>(File.ReadAllText(@dataPath + @"\"  + fileName + ".json"));
            else
               return default;
        }

        public void SaveData<T>(T data,string fileName)
        {
            string jsonString = JsonSerializer.Serialize<T>(data);
            File.Delete(@dataPath + @"\" + fileName + ".json");
            File.WriteAllText(@dataPath + @"\" + fileName + ".json", jsonString);

        }
   

    }
}
