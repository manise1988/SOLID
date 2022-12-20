﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BeschikbareTijd
    {
        public Time Time { get; set; }

        public string Date { get; set; }

        public Specialist Specialist { get; set; }

        public Kliniek Kliniek { get; set; }
        public BeschikbareTijd(Time time, DateTime date, Specialist specialist, Kliniek kliniek)
        {
            Time = time;
            Date = date.ToShortDateString();
            Specialist = specialist;
            Kliniek = kliniek;
        }
    }
}
