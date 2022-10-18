using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class Centrum
    {
        private string name;
        public string Name { get { return this.name; } }


        private List<Specialist> Specialisten;
        private List<Behandeling> Behandelingen;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<Afspraak> Afspraken;

        public Centrum(string name)
        {
            this.name = name;
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

        public List<BehandelingAgenda> GetBehandelingAgendas() {
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


        public List<Time> CalculateVrijeTijdFromAgenda( long spesialistBSN ,string categoryName,string behandelingName,DateTime selectedDay)
        {

            List<Time> times = new List<Time>();
            Behandeling behandeling = Behandelingen.Where(x => x.Name == behandelingName).First();
            if (behandeling!= null)
            {
                Specialist specialist = Specialisten.Where(x => x.BSN == spesialistBSN &&
                x.Category.Behandelingen.Where(y => y.Name == behandelingName).Any()
                ).First();
                
                if(specialist != null)
                {
                    Time durationTime = behandeling.DurationTime;
                    
                    string selectedDayOfWeek = selectedDay.DayOfWeek.ToString();
                    List<BehandelingAgenda> behandelingAgendas= new List<BehandelingAgenda>();

                    if (BehandelingAgendas.Where(x =>
                    x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).Any())
                   
                   behandelingAgendas = BehandelingAgendas.Where(x =>
                    x.Specialist.BSN == specialist.BSN && x.Werkdag.ToString() == selectedDayOfWeek).ToList();

                    if (behandelingAgendas.Count() > 0)
                    {
                        foreach (BehandelingAgenda behandelingAgenda in behandelingAgendas)
                        {

                            Time time = behandelingAgenda.BeginTime;
                            while (IsTime1Smaller(time, behandelingAgenda.EndTime))
                            {
                                if (Afspraken.Count > 0)
                                {

                                    foreach (var item in Afspraken.Where(x => x.BehandelingDatum == selectedDay
                                    && x.Category.Name == categoryName &&
                                    x.Specialist.BSN == spesialistBSN &&
                                    x.AfspraakStatus == AfspraakStatus.InBehandeling
                                    ).ToList())
                                    {
                                        //Algoritme
                                        // endtime = item.BegintTime+item.Behandeling.DurationTime

                                    }

                                }
                                times.Add(time);
                                
                                time = CalculateVolgendeTime(time, durationTime);
                            }

                        }
                    }
                    

                }
                

            }
            
            return times;
        }
        
        private Time CalculateVolgendeTime(Time time,Time durationTime)
        {
            

           

            int oudHour = time.GetHour();
            int oudMin = time.GetMin();


            int newHour = durationTime.GetHour();
            int newMin = durationTime.GetMin();

            

            TimeSpan timeSpanOud =new TimeSpan(oudHour,oudMin,0);
            TimeSpan timeSpanNew = new TimeSpan(newHour,newMin,0);


            TimeSpan newTime = timeSpanOud + timeSpanNew;
            Time returnTime = new Time();
            returnTime.SetTime(newTime.Hours, newTime.Minutes);
            return returnTime;
        }

        private bool IsTime1Smaller(Time time1, Time time2)
        {
 
            TimeSpan timeSpan1 = new TimeSpan(time1.GetHour(), time1.GetMin(), 0);
            TimeSpan timeSpan2 = new TimeSpan(time2.GetHour(), time2.GetMin(), 0);
            if(timeSpan1 < timeSpan2)
                return true;
            else
                return false;
        }
    
    }
}
