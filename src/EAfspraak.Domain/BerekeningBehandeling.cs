using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class BerekeningBehandeling : IBerekening
{
    public IBehandeling Behandeling { get; }

    private Calculator calculator;
    public BerekeningBehandeling(IBehandeling behandeling)
    {
        Behandeling = behandeling;



    }
    public List<BeschikbareTijd> Calculate(Kliniek kliniek, Afspraak[] afspraken)
    {


        List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();
        if (kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
        {

            IBehandeling behandeling = kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).First();
            Time durationTime = behandeling.DurationTime;

            IFilter filter = new FilterOpSpecialist(behandeling);
            Specialist[] specialisten = filter.GetSpecialist(kliniek.Specialisten);
            
            foreach (var specialist in specialisten)
            {
                DateTime currentDate = DateTime.Now.AddDays(-1);
                for (int i = 1; i < kliniek.KliniekSetting.ZoekBereikDay; i++)
                {
                    bool isTrue = true;
                    currentDate = currentDate.AddDays(1);
                    if (kliniek.GeslotenDagen != null)
                        if (kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                        {
                            isTrue = false;
                        }

                    if (isTrue)
                    {
                        filter = new FilterOpBehandelingAgenda(specialist, currentDate);
                        BehandelingAgenda[] behandelingAgendas = filter.GetBehandelingAgenda(kliniek.BehandelingAgendas);


                        if (behandelingAgendas.Count() > 0)
                        {
                           filter= new FilterOpAfspraken(specialist, currentDate);
                            Afspraak[] currentAfspraken = filter.GetAfspraak(afspraken);

                            calculator = new Calculator(behandelingAgendas, currentAfspraken, currentDate, durationTime);
                            beschikbareTijdList.AddRange(calculator.MaakBeschikbareTijden(kliniek));
                        }
                    }
                }


            }

        }
        return beschikbareTijdList;
    }

}