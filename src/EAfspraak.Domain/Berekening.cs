using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Berekening
    {
        public List<BerekeningZoekParameter> ZoekParameters { get; private set; }
        public List<BeschikbareTijd> beschikbareTijdList { get { return this.calculateBeschikbareTijden(); } }
        public Kliniek Kliniek { get; private set; }

        public Berekening(Kliniek kliniek, List<BerekeningZoekParameter> zoekParameters)
        {
            Kliniek = kliniek;
            ZoekParameters = zoekParameters;
        }

        private List<BeschikbareTijd> calculateBeschikbareTijden()
        {
            List<BeschikbareTijd> beschikbareTijdList=new List<BeschikbareTijd>();

            if (ZoekParameters != null)
            {
                foreach (BerekeningZoekParameter zoekParameter in ZoekParameters)
                {
                    if (zoekParameter.ZoekParameterName == ZoekParameterType.Behandeling)
                    {
                        beschikbareTijdList = calculateByBehandeling(zoekParameter.ZoekparameterValue);
                    }
                }
             
            }
            return beschikbareTijdList;
        }

        private List<BeschikbareTijd> calculateByBehandeling(string behandelingName)
        {
            List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();
            if (Kliniek.GetBehandelings().Where(x => x.Name == behandelingName).Any())
            {
                IBehandeling behandeling = Filter.FilterBehandelingen(Kliniek.GetBehandelings(), behandelingName);
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
