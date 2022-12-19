using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class BerekeningOpDatum:IBerekening
{ 
    public Kliniek Kliniek { get; private set; }
    public IBehandeling Behandeling { get; }
    public DateTime Datum { get;private set; }

    public List<BeschikbareTijd> BeschikbareTijdList { get { return Calculate(); } private set { } }

    private Calculator calculator;
    public BerekeningOpDatum(Kliniek kliniek, IBehandeling behandeling,DateTime datum)
        {
            Kliniek = kliniek;
            Behandeling = behandeling;
            
            Datum = datum;

        }



    public List<BeschikbareTijd> Calculate()
    {
        List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();

        if (Kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
        {
            IBehandeling behandeling = Filter.FilterBehandelingen(Kliniek.Behandelingen, Behandeling.Name);
            Time durationTime = behandeling.DurationTime;

            List<Specialist> specialisten = Filter.FilterSpecialisten(Kliniek.Specialisten, behandeling);

            foreach (var specialist in specialisten)
            {
                DateTime currentDate = Datum;

                bool isTrue = true;

                if (Kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                { isTrue = false; }

                if (isTrue)
                {
                    List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(Kliniek.BehandelingAgendas, specialist, currentDate);

                    if (behandelingAgendas.Count() > 0)
                    {

                        List<Afspraak> currentAfspraken = Filter.FilterAfspraken(Kliniek.Afspraken, specialist, currentDate);
                    calculator = new Calculator(behandelingAgendas, currentAfspraken, currentDate, durationTime);
                    beschikbareTijdList.AddRange(calculator.MaakBeschikbareTijden());
                    //  beschikbareTijdList.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
                }
                }



            }

        }
        return beschikbareTijdList;
    }
    }

