
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
namespace EAfspraak.Domain.Common;


public interface IFilter
{
    public object Get<T>(T data);

}
public class FilterOpSpecialist:IFilter
{
    IBehandeling behandeling;

    public FilterOpSpecialist(IBehandeling _behandeling)
    {
        this.behandeling = _behandeling;
    }

    public object Get<T>(T data)
    {
        Specialist[] result = data as Specialist[];

            if (result != null)
                return result.Where(x =>
                    x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToArray();
        return default;
    }


}
public class FilterOpBehandelingAgenda:IFilter
{
    Specialist specialist;
    DateTime currentDate;

    public FilterOpBehandelingAgenda(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    
       
    }

    public object Get<T>(T data)

    {
        BehandelingAgenda[] result = data as BehandelingAgenda[];
        if (result != null)
        {
            string selectedDayOfWeek = currentDate.DayOfWeek.ToString();
            return result.Where(x =>
                        x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToArray();
        }
        else
            return default;
    }

}
public class FilterOpAfspraken:IFilter {
    Specialist specialist;
    DateTime currentDate;
    public FilterOpAfspraken(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    }

    public object Get<T>(T data)
    {
        Afspraak[] result = data as Afspraak[];
        if (result != null)
            return result.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()
                                   && x.Specialist.BSN == specialist.BSN //&&
                                                                         // x.AfspraakStatus == AfspraakStatus.InBehandeling
                                   ).ToList().OrderBy(x => x.BehandelingTime.GetGetal()).ToArray();
        else
            return default;
    }


}