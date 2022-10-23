﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class BehandelingAgenda
    {
        
        private Specialist specialist;
        
        public Specialist Specialist { get { return this.specialist; } set { this.specialist = value; } }

        private Werkdag werkdag;
        public Werkdag Werkdag { get { return this.werkdag; } set { this.werkdag = value; } }

        private Time beginTime;
        public Time BeginTime { get { return this.beginTime; } }
        private Time endTime;
        public Time EndTime { get { return this.endTime; } }
        public BehandelingAgenda( Specialist sepecialist, Werkdag werkdag, Time beginTime, Time endTime)
        {
            
            this.specialist = sepecialist;
            this.werkdag = werkdag;
            this.beginTime = beginTime;
            this.endTime = endTime;
           
        }
    }

    public enum Werkdag
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}