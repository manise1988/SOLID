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
    public IBehandeling Behandeling { get; }
    public DateTime Datum { get;private set; }

  //  public List<BeschikbareTijd> BeschikbareTijdList { get { return Calculate; } private set { } }

    private Calculator calculator;
    public BerekeningOpDatum(IBehandeling behandeling, DateTime datum)
    {

        Behandeling = behandeling;
        Datum = datum;
    }
    public List<BeschikbareTijd> Calculate(Kliniek kliniek)
    {
       
            List<BeschikbareTijd> beschikbareTijdList = new List<BeschikbareTijd>();

            if (kliniek.Behandelingen.Where(x => x.Name == Behandeling.Name).Any())
            {
                IBehandeling behandeling = Filter.FilterBehandelingen(kliniek.Behandelingen, Behandeling.Name);
                Time durationTime = behandeling.DurationTime;

                Specialist[] specialisten = Filter.FilterSpecialisten(kliniek.Specialisten, behandeling);

                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = Datum;

                    bool isTrue = true;

                    if (kliniek.GeslotenDagen.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
                    { isTrue = false; }

                    if (isTrue)
                    {
                        BehandelingAgenda[] behandelingAgendas = Filter.FilterBehandelingAgendas(kliniek.BehandelingAgendas, specialist, currentDate);

                        if (behandelingAgendas.Count() > 0)
                        {

                            Afspraak[] currentAfspraken = Filter.FilterAfspraken(kliniek.Afspraken, specialist, currentDate);
                            calculator = new Calculator(behandelingAgendas, currentAfspraken, currentDate, durationTime);
                            beschikbareTijdList.AddRange(calculator.MaakBeschikbareTijden(kliniek));
                        }
                    }



                }

            }
            return beschikbareTijdList;
        }
    
}

