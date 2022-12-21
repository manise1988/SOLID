using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Time
    {
        private int Min;
        private int Hour;
        public string Uur { get; set; }

        public Time()
        {

        }
        public Time(string uur)
        {
            Uur = uur;
            SetHourMin();
        }
        private void SetHourMin()
        {
            if (Uur != null)
            {
                string[] times = Uur.Split('.');

                Hour = int.Parse(times[0]);
                Min = int.Parse(times[1]);
            }
        }
        public  string GetTime()
        {
            SetHourMin();
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
            SetHourMin();
            return decimal.Parse(Hour.ToString() + "," + Min.ToString());


        }

        public int GetMin()
        {
            SetHourMin();
            return this.Min;
        }

        public int GetHour()
        {
            SetHourMin();
            return this.Hour;
        }

    }
}
