
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
namespace EAfspraak.Domain.Common;

public class FilterOpSpecialist
{
    IBehandeling behandeling;

    public FilterOpSpecialist(IBehandeling _behandeling)
    {
        this.behandeling = _behandeling;
    }

    public Specialist[] Get(Specialist[] data)
    {
        if (data != null)
            return data.Where(x =>
                x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToArray();
        else
            return default;
    }
}
public class FilterOpBehandelingAgenda
{
    Specialist specialist;
    DateTime currentDate;

    public FilterOpBehandelingAgenda(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    
       
    }

    public BehandelingAgenda[] Get(BehandelingAgenda[] data)

    {
        if (data != null)
        {
            string selectedDayOfWeek = currentDate.DayOfWeek.ToString();
            return data.Where(x =>
                        x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToArray();
        }
        else
            return default;
    }

}
public class FilterOpAfspraken {
    Specialist specialist;
    DateTime currentDate;
    public FilterOpAfspraken(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    }

    public Afspraak[]  Get(Afspraak[] data)
    {
        if (data != null)
            return data.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()
                                   && x.Specialist.BSN == specialist.BSN //&&
                                                                         // x.AfspraakStatus == AfspraakStatus.InBehandeling
                                   ).ToList().OrderBy(x => x.BehandelingTime.GetGetal()).ToArray();
        else
            return default;
    }


}