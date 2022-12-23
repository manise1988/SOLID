
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;

namespace EAfspraak.Domain.Common
{
    public static class Filter
    {
        public static List<Specialist> FilterSpecialisten(Specialist[] Specialisten, IBehandeling behandeling)
        {
            return Specialisten.Where(x =>
                x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToList();

        }
        public static IBehandeling FilterBehandelingen(IBehandeling[] behandelingen, string behandelingName)
        {
            if (behandelingen != null)
                return behandelingen.Where(x => x.Name == behandelingName).First();
            else
                return null;
        }

        public static List<BehandelingAgenda> FilterBehandelingAgendas( BehandelingAgenda[] behandelingAgendas, Specialist specialist, DateTime currentDate)
        {
            string selectedDayOfWeek = currentDate.DayOfWeek.ToString();
            return behandelingAgendas.Where(x =>
                        x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToList();
        }

        public static List<Afspraak> FilterAfspraken(Afspraak[] afspraken,Specialist specialist, DateTime currentDate)
        {
            return afspraken.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()
                                   && x.Category.Name == specialist.Category.Name &&
                                   x.Specialist.BSN == specialist.BSN &&
                                   x.AfspraakStatus == AfspraakStatus.InBehandeling
                                   ).ToList().OrderBy(x => x.BehandelingTime.GetGetal()).ToList();
        }
    }
}
