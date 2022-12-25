using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    public interface IAfspraakManager
    {
        public List<Afspraak> GetAfsprakenByPatient(Patiënt patiënt);
        public void MaakAfspraak(IBehandeling behandeling, Kliniek kliniek, Patiënt patiënt, Specialist specialist, DateTime datum, Time time);
        public List<Kliniek> GetKlinieken();

        public Kliniek GetKliniekByNaam(string kliniekNaam);
        public List<Patiënt> GetPatienten();

        public Patiënt GetPatiëntByBSN(long patiëntBSN);

        public List<Category> GetCategories();
        public IBehandeling GetBehandelingByNaam(string behandelingNaam);

    }

}
