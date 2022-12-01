using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces;
    public interface IRepotisoryKliniek
    {
        public List<Kliniek> ReadData();


    public void SaveAfspraak(List<Kliniek> data);
    }

    public interface IRepotisoryCategory
    {
        public List<Category> ReadData();

        public void SaveData(List<Category> data);
    }

public interface IRepotisoryPersoon
{
    public List<Patiënt> ReadPatiënt();

    public List<Huisarts> ReadHuisarts();

    public void SaveData(List<Patiënt> dataPatiënt, List<Huisarts> dataHuisarts);
}

