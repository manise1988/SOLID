using EAfspraak.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.IO;
using EAfspraak.Domain.Interfaces;

namespace EAfspraak.Infrastructure;
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
        string newJsonString = JsonSerializer.Serialize<T>(data);
       
        var jsonFile = File.ReadAllText(@dataPath + @"\" + fileName + ".json");
        if (jsonFile.Trim() != "")
        {
            jsonFile = "[" + newJsonString + "," + jsonFile.Substring(1);

        }
        else
        {
            jsonFile = "[" + newJsonString + "]";
        }
        File.Delete(@dataPath + @"\" + fileName + ".json");
        File.WriteAllText(@dataPath + @"\" + fileName + ".json", jsonFile);
    }


}
