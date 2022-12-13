using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
    public class BerekeningOpWerkdag
    {
    public Kliniek Kliniek { get; private set; }
    public IBehandeling Behandeling { get; }
    public Werkdag Werkdag { get; private set; }
    private List<BeschikbareTijd> beschikbareTijdList;
    public BerekeningOpWerkdag(Kliniek kliniek, IBehandeling behandeling, Werkdag  werkdag)
    {
        Kliniek = kliniek;
        Behandeling = behandeling;
        beschikbareTijdList = new List<BeschikbareTijd>();
        Werkdag = werkdag;

    }



    public List<BeschikbareTijd> Calculate()
    {


        if (Kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
        {
            IBehandeling behandeling = Filter.FilterBehandelingen(Kliniek.Behandelingen, Behandeling.Name);
            Time durationTime = behandeling.DurationTime;

            List<Specialist> specialisten = Filter.FilterSpecialisten(Kliniek.Specialisten, behandeling);

            foreach (var specialist in specialisten)
            {
                DateTime currentDate = DateTime.Now.AddDays(-1);
                for (int i = 1; i < Kliniek.KliniekSetting.ZoekBereikDay; i++)
                {
                    bool isTrue = true;
                    currentDate = currentDate.AddDays(1);
                    if(currentDate.DayOfWeek.ToString() !=Werkdag.ToString())
                        isTrue = false;

                    
                    if (Kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any() && isTrue==true)
                    { isTrue = false; }

                    if (isTrue)
                    {
                        List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(Kliniek.BehandelingAgendas, specialist, currentDate);

                        if (behandelingAgendas.Count() > 0)
                        {

                            List<Afspraak> currentAfspraken = Filter.FilterAfspraken(Kliniek.Afspraken, specialist, currentDate);

                            beschikbareTijdList.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
                        }
                    }
                }


            }

        }
        return beschikbareTijdList;
    }
}

