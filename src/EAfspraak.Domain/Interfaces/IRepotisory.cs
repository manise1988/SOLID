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


        public void SaveAfspraak(Kliniek kliniek,Afspraak afspraak);
    }

    public interface IRepotisoryCategory
    {
        public List<Category> ReadData();

        
    }

public interface IRepotisoryPersoon
{
    public List<Patiënt> ReadPatiënt();

    public List<Huisarts> ReadHuisarts();


}

