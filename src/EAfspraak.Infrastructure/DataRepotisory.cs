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

        public List<Category> GetCategories()
        {
            List<Category> categories;
            categories = JsonSerializer.Deserialize<List<Category>>(File.ReadAllText(@"Data/Category.json"));

            return categories;


         }
        public void SetCategory(List<Category> categories)
        {
            string jsonString = JsonSerializer.Serialize<List<Category>>(categories);
            File.Delete(@"Data/Category.json");
            File.WriteAllText(@"Data/Category.json", jsonString);

        }
        public List<Behandeling> GetBehandelingen()
        {
            List<Behandeling> behandelingen;
            behandelingen = JsonSerializer.Deserialize<List<Behandeling>>(File.ReadAllText(@"Data/Behandeling.json"));

            return behandelingen;


        }
        public void SetBehandeling(List<Behandeling> behandelingen)
        {
            string jsonString = JsonSerializer.Serialize<List<Behandeling>>(behandelingen);
            File.Delete(@"Data/Behandeling.json");
            File.WriteAllText(@"Data/Behandeling.json", jsonString);

        }


        public List<BehandelingAgenda> GetBehandelingAgendas()
        {
            List<BehandelingAgenda> behandelingAgendas;
            behandelingAgendas = JsonSerializer.Deserialize<List<BehandelingAgenda>>(File.ReadAllText(@"Data/BehandelingAgenda.json"));
            return behandelingAgendas;
        }
        public List<Centrum> GetCentrum()
        {
            List<Centrum> centrums;
            centrums = JsonSerializer.Deserialize<List<Centrum>>(File.ReadAllText(@"Data/Centrum.json"));
            return centrums;
        }


        public void SetCentrum(List<Centrum> centrums)
        {
            string jsonString = JsonSerializer.Serialize<List<Centrum>>(centrums);
            File.Delete(@"Data/Centrum.json");
            File.WriteAllText(@"Data/Centrum.json", jsonString);

        }
        public void SetBehandelingAgenda(List<BehandelingAgenda> behandelingAgendas)
        {
            string jsonString = JsonSerializer.Serialize<List<BehandelingAgenda>>(behandelingAgendas);
            File.Delete(@"Data/BehandelingAgenda.json");
            File.WriteAllText(@"Data/BehandelingAgenda.json", jsonString);

        }
        public void SetPatiënten(List<Patiënt> Patiënten)
        {
            string jsonString = JsonSerializer.Serialize<List<Patiënt>>(Patiënten);
            File.Delete(@"Data/Patiënt.json");
            File.WriteAllText(@"Data/Patiënt.json", jsonString);

        }
        public void SetBrieven(List<Brief> brieven)
        {
            string jsonString = JsonSerializer.Serialize<List<Brief>>(brieven);
            File.Delete(@"Data/Brief.json");
            File.WriteAllText(@"Data/Brief.json", jsonString);

        }
        public List<Patiënt> GetPatiënt()
        {
            List<Patiënt> patiënten;
            patiënten = JsonSerializer.Deserialize<List<Patiënt>>(File.ReadAllText(@"Data/Patient.json"));
            return patiënten;
        }
        public List<Brief> GetBrieven()
        {
            List<Brief> brieven=new List<Brief>();
            var item = File.ReadAllText(@"Data/Brief.json");
            if(item.Trim()!="")
                brieven = JsonSerializer.Deserialize<List<Brief>>(item);
            return brieven;
        }


    }
}
