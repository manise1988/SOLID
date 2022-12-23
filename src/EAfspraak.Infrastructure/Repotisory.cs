using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.IO;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Abstracts;
using Newtonsoft.Json;


namespace EAfspraak.Infrastructure;
public class Repotisory
{
    string dataPath="";


    public Repotisory()
    {
        string baseDirectoryName = new FileInfo(GetType().Assembly.Location).DirectoryName;
        dataPath = Path.Combine(baseDirectoryName, "Data");
    }

    public T? ReadData<T>(string fileName)
    {
        var item = File.ReadAllText(@dataPath + @"\" + fileName + ".json");

        if (item.Trim() != "")
        {
            return  JsonConvert.DeserializeObject<T>(item);
          
        }
        else
            return default;
    }

   
    public void SaveData<T>(T data,string fileName)
    {


        string newJsonString = JsonConvert.SerializeObject(data); 

    
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

