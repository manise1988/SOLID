﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public class KliniekAgendaViewModel
    {
        public string KliniekName { get; set; }
        public string KliniekDescription { get; set; }
        public string SpecialistName { get; set; }
        public long SpecialistBSN { get; set; }
        public string Date { get; set; }
        public string AfspraakTime { get; set; }
        public KliniekAgendaViewModel(string kliniekName, string kliniekDescription, string specialistName, long specialistBSN, string date, string afspraakTime)
        {
            KliniekName = kliniekName;
            KliniekDescription = kliniekDescription;
            SpecialistName = specialistName;
            SpecialistBSN = specialistBSN;
            Date = date;
            AfspraakTime = afspraakTime;
        }
    }
}