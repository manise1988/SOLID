

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;

namespace EAfspraak.Domain.Common;
public class TimeBerekening
{
    public TimeBerekening()
    {
    }

    public  Time VolgendeTime(Time time, Time durationTime)
    {

        int oudHour = time.GetHour();
        int oudMin = time.GetMin();

        int newHour = durationTime.GetHour();
        int newMin = durationTime.GetMin();

        TimeSpan timeSpanOud = new TimeSpan(oudHour, oudMin, 0);
        TimeSpan timeSpanNew = new TimeSpan(newHour, newMin, 0);

        TimeSpan newTime = timeSpanOud + timeSpanNew;
        Time returnTime = new Time();
        returnTime.SetTime(newTime.Hours, newTime.Minutes);
        return returnTime;
    }
    public  bool IsTime1Smaller(Time time1, Time time2)
    {

        TimeSpan timeSpan1 = new TimeSpan(time1.GetHour(), time1.GetMin(), 0);
        TimeSpan timeSpan2 = new TimeSpan(time2.GetHour(), time2.GetMin(), 0);
        if (timeSpan1 < timeSpan2)
            return true;
        else
            return false;
    }
    public  bool IsTime1EqualSmaller(Time time1, Time time2)
    {

        TimeSpan timeSpan1 = new TimeSpan(time1.GetHour(), time1.GetMin(), 0);
        TimeSpan timeSpan2 = new TimeSpan(time2.GetHour(), time2.GetMin(), 0);
        if (timeSpan1 <= timeSpan2)
            return true;
        else
            return false;
    }
    public  bool IsTime1Equallarger(Time time1, Time time2)
    {

        TimeSpan timeSpan1 = new TimeSpan(time1.GetHour(), time1.GetMin(), 0);
        TimeSpan timeSpan2 = new TimeSpan(time2.GetHour(), time2.GetMin(), 0);
        if (timeSpan1 >= timeSpan2)
            return true;
        else
            return false;
    }
}
   