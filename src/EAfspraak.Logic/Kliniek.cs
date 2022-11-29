
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Common;
using EAfspraak.Infrastructure.DTO;

namespace EAfspraak.Domain
{
    public class Kliniek:IComparable<Kliniek>
    {
        private string name;
        public string Name { get { return name; } }

        private string locatie;
        public string Locatie { get { return locatie; } }

        private ZoekBereik zoekBereik;
       
        private List<Specialist> Specialisten;
        private List<Behandeling> Behandelingen;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<Afspraak> Afspraken;
        public Kliniek(string name, string locatie , ZoekBereik zoekBereik)
        {
            this.name = name;
            this.locatie = locatie;
            this.zoekBereik = zoekBereik;

            Specialisten = new List<Specialist>();
            Behandelingen = new List<Behandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            Afspraken = new List<Afspraak>();

        }
        public void AddAfspraakToKliniek(Afspraak afspraak)
        {
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
        public void AddBehandelingToKliniek(Behandeling behandeling)
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

        public List<Afspraak> GetAfspraken()
        {
            return Afspraken;
        }

        public List<BehandelingAgenda> GetBehandelingAgendas()
        {
            return BehandelingAgendas;
        }

        public List<Behandeling> GetBehandelings()
        {
            return Behandelingen;
        }

        public List<BeschikbareTijd> CalculateVrijeTijd(string behandelingName)
        {

            List<BeschikbareTijd> times = new List<BeschikbareTijd>();

            if(Behandelingen.Where(x => x.Name == behandelingName).Any())
            { 
                Behandeling behandeling = Behandelingen.Where(x => x.Name == behandelingName).First();
                Time durationTime = behandeling.DurationTime;

                // stap 1 de specialisten die de behandeling dient.
                List<Specialist> specialisten = Filter.GetSpecialisten(Specialisten, behandeling);

                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = DateTime.Now;
                    for (int i = 1; i < zoekBereik.Day; i++)
                    {
                        currentDate = currentDate.AddDays(1);

                        // Stap 2 behandelingAgenda die een specialist aanwezig is
                        List<BehandelingAgenda> behandelingAgendas = Filter.GetBehandelingAgendas(BehandelingAgendas, specialist, currentDate);

                        if (behandelingAgendas.Count() > 0)
                        {
                            //Stap 3 Afspraken die een specialist op de dag heeft
                            List<Afspraak> currentAfspraken = Filter.GetAfspraken(Afspraken, specialist, currentDate);

                            times.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
                        }

                    }


                }
            }
            return times;
        }



        public int CompareTo(Kliniek? obj)
        {
            return String.Compare(this.Locatie, obj.Locatie);
        }
    }
}
