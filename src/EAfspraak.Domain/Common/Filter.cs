
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;

namespace EAfspraak.Domain.Common;



//public interface IFilter<TEntity> where TEntity : class
//{
//    TEntity[] Get(TEntity[] data);

//}

public interface IFilter
{
    public Specialist[] GetSpecialist(Specialist[] data);
    public BehandelingAgenda[] GetBehandelingAgenda(BehandelingAgenda[] data);
    public Afspraak[] GetAfspraak(Afspraak[] data);
}



public class FilterOpSpecialist:IFilter
{
    IBehandeling behandeling;
    public FilterOpSpecialist(IBehandeling _behandeling)
    {
        this.behandeling = _behandeling;

    }

    public Afspraak[] GetAfspraak(Afspraak[] data)
    {
        throw new NotImplementedException();
    }

    public BehandelingAgenda[] GetBehandelingAgenda(BehandelingAgenda[] data)
    {
        throw new NotImplementedException();
    }

    public Specialist[] GetSpecialist(Specialist[] data) 
    {

        if (data != null)
            return  data.Where(x =>
                x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToArray();
        else
            return default;
    }


}


//public class FilterOpSpecialist : IFilter<Specialist>
//{
//    IBehandeling behandeling;

//    public FilterOpSpecialist(IBehandeling _behandeling)
//    {
//        this.behandeling = _behandeling;
//    }

//    public Specialist[] Get(Specialist[] data)
//    {
//        if (data != null)
//            return data.Where(x =>
//                x.Category.Behandelingen.Where(y => y.Name == behandeling.Name).Any()).ToArray();
//        else
//            return default;
//    }
//}

public class FilterOpBehandelingAgenda : IFilter
{
    Specialist specialist;
    DateTime currentDate;
    public BehandelingAgenda[] data;
    public FilterOpBehandelingAgenda(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    
       
    }

    public BehandelingAgenda[] GetBehandelingAgenda(BehandelingAgenda[] data)

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

    public Specialist[] GetSpecialist(Specialist[] data)
    {
        throw new NotImplementedException();
    }

    public Afspraak[] GetAfspraak(Afspraak[] data)
    {
        throw new NotImplementedException();
    }
}

public class FilterOpAfspraken : IFilter
{
    Specialist specialist;
    DateTime currentDate;
    Afspraak[] data;
    public FilterOpAfspraken(Specialist _specialist, DateTime _currentDate)
    {
        specialist = _specialist;
        currentDate = _currentDate;
    }

    public Afspraak[]  GetAfspraak(Afspraak[] _data)
    {
        if (data != null)
            return data.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()
                                   && x.Specialist.BSN == specialist.BSN //&&
                                                                         // x.AfspraakStatus == AfspraakStatus.InBehandeling
                                   ).ToList().OrderBy(x => x.BehandelingTime.GetGetal()).ToArray();
        else
            return default;
    }

    public BehandelingAgenda[] GetBehandelingAgenda(BehandelingAgenda[] data)
    {
        throw new NotImplementedException();
    }

    public Specialist[] GetSpecialist(Specialist[] data)
    {
        throw new NotImplementedException();
    }
}