using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Common;
public class Calculator
{

    BehandelingAgenda[] behandelingAgendas;
    IAfspraak[] afspraken;
    DateTime date;
    Time durationTime;

    public Calculator(BehandelingAgenda[] behandelingAgendas, IAfspraak[] afspraken
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
            TimeBerekening timeBerekening = new TimeBerekening();
            if (hasAfspraken)
            {
                for (int j = 0; j < afspraken.Count() + 1; j++)
                {


                    if (j < afspraken.Count())
                    {
                        IAfspraak currentAfspraak = afspraken[j];
                        Time beginAfspraakTime = currentAfspraak.BehandelingTime;
                        Time endAfspraakTime = timeBerekening.VolgendeTime(currentAfspraak.BehandelingTime, currentAfspraak.Behandeling.DurationTime);

                        while (timeBerekening.IsTime1Smaller(time, beginAfspraakTime) &&
                            timeBerekening.IsTime1EqualSmaller(timeBerekening.VolgendeTime(time, durationTime), beginAfspraakTime) &&
                            timeBerekening.IsTime1Smaller(time, endTime))
                        {
                            Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                            time = timeBerekening.VolgendeTime(time, durationTime);
                        }
                        time = endAfspraakTime;
                    }
                    else
                    {
                        while (timeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime) &&
                              timeBerekening.IsTime1EqualSmaller(timeBerekening.VolgendeTime(time, durationTime), behandelingAgenda.EndTime))
                        {
                            Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                            time = timeBerekening.VolgendeTime(time, durationTime);
                        }
                    }


                }

            }
            else
            {
                while (timeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                {
                    Tijden.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist, kliniek));
                    time = timeBerekening.VolgendeTime(time, durationTime);
                }
            }

        }
        return Tijden;

    }

}
