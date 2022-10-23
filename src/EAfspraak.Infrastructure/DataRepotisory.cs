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
        private string dataPath;

        public DataRepotisory(string dataPath)
        {
            this.dataPath = dataPath;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories;
            categories = JsonSerializer.Deserialize<List<Category>>(File.ReadAllText(@dataPath+"Category.json"));

            return categories;


         }
        public void SetCategory(List<Category> categories)
        {
            string jsonString = JsonSerializer.Serialize<List<Category>>(categories);
            File.Delete(@dataPath+"Category.json");
            File.WriteAllText(@dataPath+"Category.json", jsonString);

        }
        public List<Behandeling> GetBehandelingen()
        {
            List<Behandeling> behandelingen;
            behandelingen = JsonSerializer.Deserialize<List<Behandeling>>(File.ReadAllText(@dataPath+"Behandeling.json"));

            return behandelingen;


        }
        public void SetBehandeling(List<Behandeling> behandelingen)
        {
            string jsonString = JsonSerializer.Serialize<List<Behandeling>>(behandelingen);
            File.Delete(@dataPath+"Behandeling.json");
            File.WriteAllText(@dataPath+"Behandeling.json", jsonString);

        }


        public List<BehandelingAgenda> GetBehandelingAgendas()
        {
            List<BehandelingAgenda> behandelingAgendas;
            behandelingAgendas = JsonSerializer.Deserialize<List<BehandelingAgenda>>(File.ReadAllText(@dataPath+"BehandelingAgenda.json"));
            return behandelingAgendas;
        }

        public List<Afspraak> GetAfspraken()
        {
            List<Afspraak> brieven = new List<Afspraak>();
            var item = File.ReadAllText(@dataPath+"Afspraak.json");
            if (item.Trim() != "")
                brieven = JsonSerializer.Deserialize<List<Afspraak>>(item);
            return brieven;
        }
        public List<Centrum> GetCentrum()
        {
            List<Centrum> centrums;
            centrums = JsonSerializer.Deserialize<List<Centrum>>(File.ReadAllText(@dataPath+"Centrum.json"));
            return centrums;
        }


        public void SetCentrum(List<Centrum> centrums)
        {
            string jsonString = JsonSerializer.Serialize<List<Centrum>>(centrums);
            File.Delete(@dataPath+"Centrum.json");
            File.WriteAllText(@dataPath+"Centrum.json", jsonString);

        }
        public void SetBehandelingAgenda(List<BehandelingAgenda> behandelingAgendas)
        {
            string jsonString = JsonSerializer.Serialize<List<BehandelingAgenda>>(behandelingAgendas);
            File.Delete(@dataPath+"BehandelingAgenda.json");
            File.WriteAllText(@dataPath+"BehandelingAgenda.json", jsonString);

        }
        public void SetAfspraken(List<Afspraak> afspraken)
        {
            string jsonString = JsonSerializer.Serialize<List<Afspraak>>(afspraken);
            File.Delete(@dataPath+"Afspraak.json");
            File.WriteAllText(@dataPath+"Afspraak.json", jsonString);

        }
        public void SetPersonen(List<Persoon> Personen)
        {
            string jsonString = JsonSerializer.Serialize<List<Persoon>>(Personen);
            File.Delete(@dataPath+ "Persoon.json");
            File.WriteAllText(@dataPath+"Patiënt.json", jsonString);

        }
        public void SetVerwijsBrieven(List<VerwijsBrief> brieven)
        {
            string jsonString = JsonSerializer.Serialize<List<VerwijsBrief>>(brieven);
            File.Delete(@dataPath+"VerwijsBrief.json");
            File.WriteAllText(@dataPath+"VerwijsBrief.json", jsonString);

        }
        public List<Persoon> GetPersonen()
        {
            List<Persoon> Personen;
            Personen = JsonSerializer.Deserialize<List<Persoon>>(File.ReadAllText(@dataPath+ "Persoon.json"));
            return Personen;
        }
        public List<VerwijsBrief> GetVerwijsBrieven()
        {
            List<VerwijsBrief> brieven=new List<VerwijsBrief>();
            var item = File.ReadAllText(@dataPath+"VerwijsBrief.json");
            if(item.Trim()!="")
                brieven = JsonSerializer.Deserialize<List<VerwijsBrief>>(item);
            return brieven;
        }


    }
}
