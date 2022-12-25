using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces;
public interface IRepositoryAfspraak
{
    public List<Kliniek> ReadKliniek();
    public Afspraak[] ReadAfspraakByKliniekNaam(string kliniekNaam);
    public Kliniek ReadKliniekByNaam(string kliniekNaam);
    public void SaveAfspraak(Afspraak afspraak);
    public List<Afspraak> ReadAfspraakByPatiënt(Patiënt patiënt);
    public List<Category> ReadCategory();
    public Category ReadCategoryByNaam(string categoryNaam);
    public IBehandeling ReadBehandelingByNaam(string behandelingNaam);
    public List<Patiënt> ReadPatiënt();
    public Patiënt ReadPatiëntByBSN(long bsn);

}

 

