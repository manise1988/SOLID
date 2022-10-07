using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class BehandelingAgenda
    {
        
        
        
        public Specialist Sepecialist { get; set; }

        public Werkdag werkdag { get; set; }

        public string BegintTime { get; set; }
        public string EindTime { get; set; }
        public BehandelingAgenda( Specialist sepecialist, Werkdag werkdag, string begintTime, string eindTime)
        {
            
            Sepecialist = sepecialist;
            this.werkdag = werkdag;
            BegintTime = begintTime;
            EindTime = eindTime;
           
        }
    }

    public enum Werkdag
    {
        maandag,
        dinsdag,
        woensdag,
        donderdag,
        vrijdag,
        zaterdag
    }
}
