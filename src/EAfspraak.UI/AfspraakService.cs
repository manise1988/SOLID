using EAfspraak.Domain.Interfaces;
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
        IRepotisoryData repotisory;
        
        public AfspraakService()
        {
            repotisory = new RepotisoryManager();
        }

        public List<Kliniek> GetKlinieken()
        {
            List<Kliniek> klinieken = repotisory.ReadDataKliniek();
            klinieken.Sort();
            return klinieken;
        }

        
        public void GetCentrumsMetVrijeTijden(IBehandeling behandeling, DateTime date, Werkdag werkdag)
        {

            List<Kliniek> klinieks = repotisory.ReadDataKliniek();
            List<IBerekening> berekenings = new List<IBerekening>();
            if (date != null && werkdag != null)
            {
                foreach (var item in klinieks)
                {
                    if(date != null)
                        berekenings.Add(new BerekeningOpDatum(item, behandeling, date));
                    if(werkdag!= null)
                        berekenings.Add(new BerekeningOpWerkdag(item, behandeling, werkdag));

                }
            }
            else
            {
                foreach (var item in klinieks)
                    berekenings.Add(new BerekeningBase(item, behandeling));

            }

        }

    }
}
