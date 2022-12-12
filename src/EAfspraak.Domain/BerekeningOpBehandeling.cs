﻿using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BerekeningOpBehandeling:IBerekening
    {
 
        public Kliniek Kliniek { get; private set; }
        public string Parameter { get; }
        public BerekeningOpBehandeling(Kliniek kliniek, string parameter)
        {
            Kliniek = kliniek;
            Parameter = parameter;
           
        }

       

        public  List<BeschikbareTijd> Calculate()
        {
            string behandelingValue = Parameter;
            List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();
            if (Kliniek.GetBehandelings().Where(x => x.Name == behandelingValue).Any())
            {
                IBehandeling behandeling = Filter.FilterBehandelingen(Kliniek.GetBehandelings(), behandelingValue);
                Time durationTime = behandeling.DurationTime;

                List<Specialist> specialisten = Filter.FilterSpecialisten(Kliniek.GetSpecialisten(), behandeling);

                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = DateTime.Now;
                    for (int i = 1; i < Kliniek.KliniekSetting.ZoekBereikDay; i++)
                    {
                        bool isTrue = true;
                        currentDate = currentDate.AddDays(1);

                        if (Kliniek.VakantieAgendas.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                        { isTrue = false; }
                        if (specialist.VerlofAgendas.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                        { isTrue = false; }

                        if (isTrue)
                        {
                            List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(Kliniek.GetBehandelingAgendas(), specialist, currentDate);

                            if (behandelingAgendas.Count() > 0)
                            {
                                
                                List<IAfspraak> currentAfspraken = Filter.FilterAfspraken(Kliniek.GetAfspraken(), specialist, currentDate);

                                beschikbareTijdList.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
                            }
                        }
                    }


                }

            }
            return beschikbareTijdList;
            }
    }
}
