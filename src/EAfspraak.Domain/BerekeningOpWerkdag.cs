using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class BerekeningOpWerkdag : IBerekening
{
    public IBehandeling Behandeling { get; }
    public Werkdag Werkdag { get; private set; }

    private Calculator calculator;
    public BerekeningOpWerkdag(IBehandeling behandeling, Werkdag werkdag)
    {

        Behandeling = behandeling;
        Werkdag = werkdag;

    }



    public List<BeschikbareTijd> Calculate(Kliniek kliniek, Afspraak[] afspraken)
    {

        List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();

        if (kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
        {
            IBehandeling behandeling = kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).First();
            Time durationTime = behandeling.DurationTime;

            IFilter<Specialist> filter = new FilterOpSpecialist(behandeling);
            Specialist[] specialisten = filter.Get(kliniek.Specialisten);
          
            foreach (var specialist in specialisten)
            {
                DateTime currentDate = DateTime.Now.AddDays(-1);
                for (int i = 1; i < kliniek.KliniekSetting.ZoekBereikDay; i++)
                {
                    bool isTrue = true;
                    currentDate = currentDate.AddDays(1);
                    if (currentDate.DayOfWeek.ToString() != Werkdag.ToString())
                        isTrue = false;

                    if (kliniek.GeslotenDagen != null)
                        if (kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any() && isTrue == true)
                        { isTrue = false; }

                    if (isTrue)
                    {
                        IFilter<BehandelingAgenda> filterAgenda = new FilterOpBehandelingAgenda(specialist, currentDate);
                        BehandelingAgenda[] behandelingAgendas = filterAgenda.Get(kliniek.BehandelingAgendas);

                        if (behandelingAgendas.Count() > 0)
                        {
                            IFilter<Afspraak> filterAfspraak = new FilterOpAfspraken(specialist, currentDate);
                            Afspraak[] currentAfspraken = filterAfspraak.Get(afspraken);

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