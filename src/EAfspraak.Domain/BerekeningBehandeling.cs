using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BerekeningBehandeling : IBerekening
    {
        public IBehandeling Behandeling { get; }

        private Calculator calculator;
        public BerekeningBehandeling(IBehandeling behandeling)
        {
            Behandeling = behandeling;



        }
        public List<BeschikbareTijd> Calculate(Kliniek kliniek)
        {


            List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();
            if (kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
            {
                IBehandeling behandeling = Filter.FilterBehandelingen(kliniek.Behandelingen, Behandeling.Name);
                Time durationTime = behandeling.DurationTime;

                List<Specialist> specialisten = Filter.FilterSpecialisten(kliniek.Specialisten, behandeling);

                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = DateTime.Now.AddDays(-1);
                    for (int i = 1; i < kliniek.KliniekSetting.ZoekBereikDay; i++)
                    {
                        bool isTrue = true;
                        currentDate = currentDate.AddDays(1);

                        if (kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                        {
                            isTrue = false;
                        }

                        if (isTrue)
                        {
                            List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(kliniek.BehandelingAgendas, specialist, currentDate);

                            if (behandelingAgendas.Count() > 0)
                            {

                                List<Afspraak> currentAfspraken = Filter.FilterAfspraken(kliniek.Afspraken, specialist, currentDate);
                                calculator = new Calculator(behandelingAgendas, currentAfspraken, currentDate, durationTime);
                                beschikbareTijdList.AddRange(calculator.MaakBeschikbareTijden(kliniek));
                            }
                        }
                    }


                }

            }
            return beschikbareTijdList;
        }

    }
}
