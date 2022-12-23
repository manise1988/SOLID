using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class AfspraakManager
{
    IBerekening berekening;
    IRepotisoryData repotisory;
    public AfspraakManager(IRepotisoryData repotisoryData)
    {

        this.repotisory = repotisoryData;
    }

    public  void MaakAfspraak( IBehandeling behandeling, Kliniek kliniek, Patiënt patiënt, Specialist specialist, DateTime datum, Time time)
    {
        Afspraak afspraak = new Afspraak(behandeling,  datum, time, specialist, patiënt);
       
        kliniek.AddAfspraakToKliniek(afspraak);
        repotisory.SaveAfspraak(kliniek);

    }

    public List<Kliniek> GetKlinieken()
    {
        List<Kliniek> klinieken = repotisory.ReadKliniek();
        klinieken.Sort();
        return klinieken;
    }

    public List<BeschikbareTijd> GetKliniekenMetVrijeTijden(List<IBerekening> berekeningList)
    {
        List<Kliniek> kliniekList = repotisory.ReadKliniek();
        kliniekList.Sort();

        List<BeschikbareTijd> BeschikbareTijdList = new List<BeschikbareTijd>(); 
        foreach (var item in kliniekList)
        {
            foreach (var itemBerekening in berekeningList)
            {
                BeschikbareTijdList.AddRange(itemBerekening.Calculate(item));
            }

        }

        return BeschikbareTijdList;



    }


}
