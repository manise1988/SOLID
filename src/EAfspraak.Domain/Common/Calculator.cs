using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Common;
public class Calculator
{

    BehandelingAgenda[] behandelingAgendas;
    Afspraak[] afspraken;
    DateTime date;
    Time durationTime;
    public Calculator(BehandelingAgenda[] behandelingAgendas, Afspraak[] afspraken
        , DateTime date, Time durationTime)
    {

        this.behandelingAgendas = behandelingAgendas;
        this.afspraken = afspraken;
        this.date = date;
        this.durationTime = durationTime;

    }

    public List<BeschikbareTijd> MaakBeschikbareTijden (Kliniek kliniek)
    {
        List<BeschikbareTijd> Tijden = new List<BeschikbareTijd>();
        foreach (BehandelingAgenda behandelingAgenda in behandelingAgendas)
        {
            Time beginTime = behandelingAgenda.BeginTime;
            Time endTime = behandelingAgenda.EndTime;
            Time time = beginTime;

            bool hasAfspraken = false;
            if (afspraken != null)
            {
                if (afspraken.Count() > 0)
                    hasAfspraken = true;
            }

            if (hasAfspraken)
            {
                for (int j = 0; j < afspraken.Count() + 1; j++)
                {


                    if (j < afspraken.Count())
                    {
                        Afspraak currentAfspraak = afspraken[j];
                        Time beginAfspraakTime = currentAfspraak.BehandelingTime;
                        Time endAfspraakTime = TimeBerekening.VolgendeTime(currentAfspraak.BehandelingTime, currentAfspraak.Behandeling.DurationTime);

                        while (TimeBerekening.IsTime1Smaller(time, beginAfspraakTime) &&
                            TimeBerekening.IsTime1EqualSmaller(TimeBerekening.VolgendeTime(time, durationTime), beginAfspraakTime) &&
                            TimeBerekening.IsTime1Smaller(time, endTime))
                        {
                            Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                            time = TimeBerekening.VolgendeTime(time, durationTime);
                        }
                        time = endAfspraakTime;
                    }
                    else
                    {
                        while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                        {
                            Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                            time = TimeBerekening.VolgendeTime(time, durationTime);
                        }
                    }


                }

            }
            else
            {
                while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                {
                    Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                    time = TimeBerekening.VolgendeTime(time, durationTime);
                }
            }

        }
        return Tijden;

    }

}
