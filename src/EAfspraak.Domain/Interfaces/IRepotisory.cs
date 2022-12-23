using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces;
public interface IRepotisoryData
{
    public List<Kliniek> ReadKliniek();

    public Afspraak[] ReadAfspraakByKliniekNaam(string kliniekNaam);
    public Kliniek ReadKliniekByNaam(string kliniekNaam);
    public Specialist ReadSpesialistByBSN(string KlinkNaam, long bsn);
    public void SaveAfspraak(Afspraak afspraak);
    public List<Category> ReadCategory();
    public Category ReadCategoryByNaam(string categoryNaam);
    public IBehandeling ReadBehandelingByNaam(string behandelingNaam);
    public List<Patiënt> ReadPatiënt();
    public Patiënt ReadPatiëntByBSN(long bsn);

}

 

