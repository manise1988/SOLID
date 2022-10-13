using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class Time
    {
        public int Min { get; set; }
        public int Hour { get; set; }
        
        public string ShowTime()
        {
            string hour = "0";
            string min = "0";
            if (Hour< 10)
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
            Min =min;
        }
    }
}
