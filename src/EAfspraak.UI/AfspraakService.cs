using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Verzender;
using EAfspraak.Domain;
using EAfspraak.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.UI
{
    public class AfspraakService
    {
        AfspraakReader afspraakReader;
        public AfspraakService()
        {
            RepotisoryManager repotisory = new RepotisoryManager();
            afspraakReader = new AfspraakReader(repotisory);
        }
        public void GetCentrumsMetVrijeTijden(IBehandeling behandeling, DateTime date, Werkdag werkdag)
        {

            List<Kliniek> klinieks = afspraakReader.GetKlinieken();
            foreach (var item in klinieks)
            {

                List<IBerekening> berekenings = new List<IBerekening>();
                berekenings.Add(new BerekeningOpDatum(item, behandeling, date));
                berekenings.Add(new BerekeningOpWerkdag(item, behandeling, werkdag));

            }

        }
    }
}
