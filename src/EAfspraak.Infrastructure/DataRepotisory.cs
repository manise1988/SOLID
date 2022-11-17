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
    public class DataRepotisory//<TEntity> where TEntity : Basis, new()
    {
        private string dataPath;

        public DataRepotisory(string dataPath)
        {
            this.dataPath = dataPath;
        }

        public DTO? ReadData<DTO>(string fileName)
        {
           
            var item = File.ReadAllText(@dataPath + fileName +".json");
            if (item.Trim() != "")
                return JsonSerializer.Deserialize<DTO>(File.ReadAllText(@dataPath + fileName + ".json"));
            else
               return default;
        }

        public void SaveData<DTO>(DTO data,string fileName)
        {
            string jsonString = JsonSerializer.Serialize<DTO>(data);
            File.Delete(@dataPath + fileName + ".json");
            File.WriteAllText(@dataPath + fileName + ".json", jsonString);

        }
   

    }
}
