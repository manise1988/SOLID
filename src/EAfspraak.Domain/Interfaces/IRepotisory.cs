using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces;
public interface IRepotisoryData
{
    public List<Kliniek> ReadDataKliniek();
    public void SaveAfspraak(Kliniek kliniek,Afspraak afspraak);
    public List<Category> ReadDataCategory();
    public IBehandeling behandelingByNaam(string behandelingName);
    public List<Patiënt> ReadPatiënt();
}

 

