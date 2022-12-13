

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;

namespace EAfspraak.Domain.Common;
    public static class TimeBerekening
    {
        public static Time VolgendeTime(Time time, Time durationTime)
        {

        int oudHour = time.Hour;
        int oudMin = time.Min;

        int newHour = durationTime.Hour;
            int newMin = durationTime.Min;

            TimeSpan timeSpanOud = new TimeSpan(oudHour, oudMin, 0);
            TimeSpan timeSpanNew = new TimeSpan(newHour, newMin, 0);

            TimeSpan newTime = timeSpanOud + timeSpanNew;
            Time returnTime = new Time();
            returnTime.SetTime(newTime.Hours, newTime.Minutes);
            return returnTime;
        }

        public static bool IsTime1Smaller(Time time1, Time time2)
        {

            TimeSpan timeSpan1 = new TimeSpan(time1.Hour, time1.Min, 0);
            TimeSpan timeSpan2 = new TimeSpan(time2.Hour, time2.Min, 0);
            if (timeSpan1 < timeSpan2)
                return true;
            else
                return false;
        }
        public static bool IsTime1EqualSmaller(Time time1, Time time2)
        {

            TimeSpan timeSpan1 = new TimeSpan(time1.Hour, time1.Min, 0);
            TimeSpan timeSpan2 = new TimeSpan(time2.Hour, time2.Min, 0);
            if (timeSpan1 <= timeSpan2)
                return true;
            else
                return false;
        }

        public static List<BeschikbareTijd> MaakBeschikbareTijden(List<BehandelingAgenda> behandelingAgendas, List<Afspraak> afspraken, DateTime date, Time durationTime)
        {
            List<BeschikbareTijd> times = new List<BeschikbareTijd>();
            foreach (BehandelingAgenda behandelingAgenda in behandelingAgendas)
            {
                Time beginTime = behandelingAgenda.BeginTime;
                Time endTime = behandelingAgenda.EndTime;
                Time time = beginTime;
                if (afspraken.Count > 0)
                {
                    for (int j = 0; j < afspraken.Count + 1; j++)
                    {


                        if (j < afspraken.Count)
                        {
                            Afspraak currentAfspraak = afspraken[j];
                            Time beginAfspraakTime = currentAfspraak.BehandelingTime;
                            Time endAfspraakTime = TimeBerekening.VolgendeTime(currentAfspraak.BehandelingTime, currentAfspraak.Behandeling.DurationTime);

                            while (TimeBerekening.IsTime1Smaller(time, beginAfspraakTime) &&
                                TimeBerekening.IsTime1EqualSmaller(TimeBerekening.VolgendeTime(time, durationTime), beginAfspraakTime) &&
                                TimeBerekening.IsTime1Smaller(time, endTime))
                            {
                                times.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist));
                                time = TimeBerekening.VolgendeTime(time, durationTime);
                            }
                            time = endAfspraakTime;
                        }
                        else
                        {
                            while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                            {
                                times.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist));
                                time = TimeBerekening.VolgendeTime(time, durationTime);
                            }
                        }


                    }

                }
                else
                {
                    while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                    {
                        times.Add(new BeschikbareTijd(time, date, behandelingAgenda.Specialist));
                        time = TimeBerekening.VolgendeTime(time, durationTime);
                    }
                }

            }
            return times;
        }
    }

