
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;


namespace EAfspraak.Domain
{
    public class Kliniek:IComparable<Kliniek>
    {
        private string name;
        public string Name { get { return name; } }

        private string locatie;
        public string Locatie { get { return locatie; } }

        public KliniekSetting KliniekSetting { get; }
       
        private List<Specialist> Specialisten;
        private List<IBehandeling> Behandelingen;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<IAfspraak> Afspraken;
        public  List<Vrij> VakantieAgendas { get; private set; }

         
       public Kliniek(string name, string locatie , KliniekSetting kliniekSetting)
       {
            this.name = name;
            this.locatie = locatie;
            KliniekSetting = kliniekSetting;

            Specialisten = new List<Specialist>();
            Behandelingen = new List<IBehandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            Afspraken = new List<IAfspraak>();
            VakantieAgendas = new List<Vrij>();

        }

        public void AddVakantieDagenToKliniek(Vrij vakantie)
        {
            VakantieAgendas.Add(vakantie);
        }
        public void AddAfspraakToKliniek(IAfspraak afspraak)
        {
            if (!afspraak.Behandeling.HasAccess(afspraak.Patiënt))
            
                Afspraken.Add(afspraak);
        }
        public void AddSpesialistToKliniek(Specialist specialist)
        {
            Specialisten.Add(specialist);
        }
        public void AddSpesialistToKliniek(List<Specialist> specialisten)
        {
            Specialisten.AddRange(specialisten);
        }
        public void AddBehandelingToKliniek(IBehandeling behandeling)
        {
            Behandelingen.Add(behandeling);
        }
        public void RegisterBehandelingAgenda(BehandelingAgenda behandelingAgenda)
        {
            BehandelingAgendas.Add(behandelingAgenda);
        }


        public List<Specialist> GetSpecialisten()
        {
            return Specialisten;
        }

        public List<IAfspraak> GetAfspraken()
        {
            return Afspraken;
        }

        public List<BehandelingAgenda> GetBehandelingAgendas()
        {
            return BehandelingAgendas;
        }

        public List<IBehandeling> GetBehandelings()
        {
            return Behandelingen;
        }

        //public List<BeschikbareTijd> CalculateVrijeTijd(string behandelingName)
        //{



        //    List<BeschikbareTijd> times = new List<BeschikbareTijd>();

        //    if(Behandelingen.Where(x => x.Name == behandelingName).Any())
        //    { 
        //        IBehandeling behandeling =Filter.FilterBehandelingen(Behandelingen,behandelingName);
        //        Time durationTime = behandeling.DurationTime;

               
        //        // stap 1 de specialisten die de behandeling dient.
        //        List<Specialist> specialisten = Filter.FilterSpecialisten(Specialisten, behandeling);

        //        foreach (var specialist in specialisten)
        //        {
        //            DateTime currentDate = DateTime.Now;
        //            for (int i = 1; i < KliniekSetting.ZoekBereikDay; i++)
        //            {
        //                bool isTrue = true;
        //                currentDate = currentDate.AddDays(1);

        //                if (VakantieAgendas.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
        //                { isTrue = false; }
        //                if (specialist.VerlofAgendas.Where(x => x.Datum.ToShortDateString() == currentDate.ToShortDateString()).Any())
        //                { isTrue = false; }

        //                // Stap 2 behandelingAgenda die een specialist aanwezig is
        //                if (isTrue)
        //                {
        //                    List<BehandelingAgenda> behandelingAgendas = Filter.FilterBehandelingAgendas(BehandelingAgendas, specialist, currentDate);

        //                    if (behandelingAgendas.Count() > 0)
        //                    {
        //                        //Stap 3 Afspraken die een specialist op de dag heeft
        //                        List<IAfspraak> currentAfspraken = Filter.FilterAfspraken(Afspraken, specialist, currentDate);

        //                        times.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
        //                    }
        //                }
        //            }


        //        }
        //    }
        //    return times;
        //}



        public int CompareTo(Kliniek? obj)
        {
            return String.Compare(this.Locatie, obj.Locatie);
        }
    }
}
