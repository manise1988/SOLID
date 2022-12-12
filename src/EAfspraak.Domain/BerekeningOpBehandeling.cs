using EAfspraak.Domain.Common;
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
        public string ZoekValue { get; }
        public BerekeningOpBehandeling(Kliniek kliniek, string zoekValue)
        {
            Kliniek = kliniek;
            ZoekValue = zoekValue;
           
        }

       

        public  List<BeschikbareTijd> Calculate()
        {
            string behandelingValue = ZoekValue;
            List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();
            if (Kliniek.Behandelingen.Where(x => x.Name == behandelingValue).Any())
            {
                IBehandeling behandeling = Filter.FilterBehandelingen(Kliniek.Behandelingen, behandelingValue);
                Time durationTime = behandeling.DurationTime;

                List<Specialist> specialisten = Filter.FilterSpecialisten(Kliniek.Specialisten, behandeling);

                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = DateTime.Now;
                    for (int i = 1; i < Kliniek.KliniekSetting.ZoekBereikDay; i++)
                    {
                        bool isTrue = true;
                        currentDate = currentDate.AddDays(1);

                        if (Kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                        { isTrue = false; }

                        if (isTrue)
                        {
                            List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(Kliniek.BehandelingAgendas, specialist, currentDate);

                            if (behandelingAgendas.Count() > 0)
                            {
                                
                                List<Afspraak> currentAfspraken = Filter.FilterAfspraken(Kliniek.Afspraken, specialist, currentDate);

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
