
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Infrastructure.DTO;

namespace EAfspraak.Domain
{
    public class Kliniek:IComparable<Kliniek>//: IEnable
    {
        private string name;
        public string Name { get { return name; } }

        private string locatie;
        public string Locatie { get { return locatie; } }

       
        private List<Specialist> Specialisten;
        //private List<Behandeling> Behandelingen;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<Afspraak> Afspraken;
        private IAvailable Behandelingen = new AvalabailBehandelingen();
        public Kliniek(string name, string locatie)
        {
            this.name = name;
            this.locatie = locatie;
            Specialisten = new List<Specialist>();
            Behandelingen.BehandelingList = new List<Behandeling>();
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
            Behandelingen.BehandelingList.Add(behandeling);
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
            return Behandelingen.BehandelingList;
        }

        public List<Beschikbaarheid> CalculateVrijeTijd(string behandelingName)
        {

            List<Beschikbaarheid> times = new List<Beschikbaarheid>();
            if(Behandelingen.IsAvailable(behandelingName))
            { 
                Behandeling behandeling = Behandelingen.BehandelingList.Where(x => x.Name == behandelingName).First();
                List<Specialist> specialisten = Specialisten.Where(x =>
                x.Category.Behandelingen.Where(y => y.Name == behandelingName).Any()).ToList();
                Time durationTime = behandeling.DurationTime;
                foreach (var specialist in specialisten)
                {
                    DateTime currentDate = DateTime.Now;
                    for (int i = 1; i < 31; i++)
                    {
                        currentDate = currentDate.AddDays(1);
                        string selectedDayOfWeek = currentDate.DayOfWeek.ToString();
                        List<BehandelingAgenda> behandelingAgendas = BehandelingAgendas.Where(x =>
                        x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToList();

                        if (behandelingAgendas.Count() > 0)
                        {
                            List<Afspraak> currentAfspraken = Afspraken.Where(x => x.BehandelingDatum.ToShortDateString() == currentDate.ToShortDateString()
                                     && x.Category.Name == specialist.Category.Name &&
                                     x.Specialist.BSN == specialist.BSN &&
                                     x.AfspraakStatus == AfspraakStatus.InBehandeling
                                     ).ToList().OrderBy(x => x.BeginTime.GetGetal()).ToList();

                            times.AddRange(TimeBerekening.MaakBeschikbareTijden(behandelingAgendas, currentAfspraken, currentDate, durationTime));
                            
                        }

                    }


                }
            }
            return times;
        }



        public int CompareTo(Kliniek? obj)
        {
            
            return String.Compare(this.Name, obj.Name);
        }
    }
}
