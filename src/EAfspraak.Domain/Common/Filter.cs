
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces.MockingInterfaces;

namespace EAfspraak.Domain.Common;
public static class Filter
{
    public static Specialist[] FilterSpecialisten(Specialist[] Specialisten, IBehandeling behandeling)
    {
        if (Specialisten != null)
            return Specialisten.Where(x =>
                x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToArray();
        else
            return default;
    }
    public static IBehandeling FilterBehandelingen(IBehandeling[] behandelingen, string behandelingName)
    {
        if (behandelingen != null)
            return behandelingen.Where(x => x.Name == behandelingName).First();
        else
            return null;
    }

    public static BehandelingAgenda[] FilterBehandelingAgendas(BehandelingAgenda[] behandelingAgendas, Specialist specialist, DateTime currentDate)
    {
        if (behandelingAgendas != null)
        {
            string selectedDayOfWeek = currentDate.DayOfWeek.ToString();
            return behandelingAgendas.Where(x =>
                        x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToArray();
        }
        else
            return default;
    }

    public static Afspraak[] FilterAfspraken(Afspraak[] afspraken, Specialist specialist, DateTime currentDate)
    {
        if (afspraken != null)
            return afspraken.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()
                                   && x.Specialist.BSN == specialist.BSN //&&
                                                                         // x.AfspraakStatus == AfspraakStatus.InBehandeling
                                   ).ToList().OrderBy(x => x.BehandelingTime.GetGetal()).ToArray();
        else
            return default;
    }
}