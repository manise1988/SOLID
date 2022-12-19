using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Time
    {
        public int Min { get; private set; }
        public int Hour { get; private set; }
        public Time()
        {

        }
        public Time(string time)
        {
            string[] times = time.Split('.');


            Hour = int.Parse(times[0]);
            Min = int.Parse(times[1]);
        }
        public string GetTime()
        {
            string hour = "0";
            string min = "0";
            if (Hour < 10)
                hour = "0" + Hour.ToString();
            else
                hour = Hour.ToString();

            if (Min < 10)
                min = "0" + Min.ToString();
            else
                min = Min.ToString();
            return hour + "." + min;

        }
        public void SetTime(string time)
        {
            string[] times = time.Split('.');

            Hour = int.Parse(times[0]);
            Min = int.Parse(times[1]);
        }
        public void SetTime(int hour, int min)
        {



            Hour = hour;
            Min = min;
        }
       
        public decimal GetGetal()
        {
            return decimal.Parse(Hour.ToString() + "," + Min.ToString());


        }
       
    }
}
