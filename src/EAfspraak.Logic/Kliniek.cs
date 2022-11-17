
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Common;

namespace EAfspraak.Domain
{
    public class Kliniek
    {
        private string name;
        public string Name { get { return name; } }

        private string locatie;
        public string Locatie { get { return locatie; } }
        private List<Specialist> Specialisten;
        private List<Behandeling> Behandelingen;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<Afspraak> Afspraken;

        public Kliniek(string name, string locatie)
        {
            this.name = name;
            this.locatie = locatie;
            Specialisten = new List<Specialist>();
            Behandelingen = new List<Behandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            Afspraken = new List<Afspraak>();

        }
        public void AddAfspraakToCentrum(Afspraak afspraak)
        {
            Afspraken.Add(afspraak);
        }
        public void AddSpesialistToCentrum(Specialist specialist)
        {
            Specialisten.Add(specialist);
        }
        public void AddSpesialistToCentrum(List<Specialist> specialisten)
        {
            Specialisten.AddRange(specialisten);
        }
        public void AddBehandelingToCentrum(Behandeling behandeling)
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

        public bool HaveToBehandeling(string behandelingName)
        {
            if (Behandelingen.Where(x => x.Name == behandelingName).Any())
                return true;
            else
                return false;
        }

        public List<Agenda> CalculateVrijeTijd(string behandelingName)
        {

            List<Agenda> times = new List<Agenda>();
            Behandeling behandeling = Behandelingen.Where(x => x.Name == behandelingName).First();
            if (behandeling != null)
            {
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

                            foreach (BehandelingAgenda behandelingAgenda in behandelingAgendas)
                            {
                                Time beginTime = behandelingAgenda.BeginTime;
                                Time endTime = behandelingAgenda.EndTime;
                                Time time = beginTime;
                                if (currentAfspraken.Count > 0)
                                {
                                    for (int j = 0; j < currentAfspraken.Count + 1; j++)
                                    {


                                        if (j < currentAfspraken.Count)
                                        {
                                            Afspraak currentAfspraak = currentAfspraken[j];
                                            Time beginAfspraakTime = currentAfspraak.BeginTime;
                                            Time endAfspraakTime = TimeBerekening.VolgendeTime(currentAfspraak.BeginTime, currentAfspraak.Behandeling.DurationTime);

                                            while (TimeBerekening.IsTime1Smaller(time, beginAfspraakTime) &&
                                                TimeBerekening.IsTime1EqualSmaller(TimeBerekening.VolgendeTime(time, durationTime), beginAfspraakTime) &&
                                                TimeBerekening.IsTime1Smaller(time, endTime))
                                            {
                                                times.Add(new Agenda(time, currentDate, behandelingAgenda.Specialist));
                                                time = TimeBerekening.VolgendeTime(time, durationTime);
                                            }
                                            time = endAfspraakTime;
                                        }
                                        else
                                        {
                                            while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                                            {
                                                times.Add(new Agenda(time, currentDate, behandelingAgenda.Specialist));
                                                time = TimeBerekening.VolgendeTime(time, durationTime);
                                            }
                                        }


                                    }

                                }
                                else
                                {
                                    while (TimeBerekening.IsTime1Smaller(time, behandelingAgenda.EndTime))
                                    {
                                        times.Add(new Agenda(time, currentDate, behandelingAgenda.Specialist));
                                        time = TimeBerekening.VolgendeTime(time, durationTime);
                                    }
                                }

                            }




                        }

                    }


                }
            }
            return times;
        }



    }
}
