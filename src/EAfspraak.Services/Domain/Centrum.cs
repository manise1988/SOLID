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


        private List<Specialist> Specialists;
        private List<Behandeling> Behandelings;
        private List<BehandelingAgenda> BehandelingAgendas;
        private List<Patiënt> patiënts;
        public Centrum(string name)
        {
            this.name = name;
            Specialists = new List<Specialist>();
            Behandelings = new List<Behandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            patiënts = new List<Patiënt>();
        }

        public void AddSpesialistToCentrum(Specialist specialist)
        {
            Specialists.Add(specialist);
        }
        public void AddSpesialistToCentrum(List<Specialist> specialisten)
        {
            Specialists.AddRange(specialisten);
        }
        public void AddBehandelingToCentrum(Behandeling behandeling)
        {
            Behandelings.Add(behandeling);
        }
        public void RegisterBehandelingAgenda(BehandelingAgenda behandelingAgenda)
        {
            BehandelingAgendas.Add(behandelingAgenda);
        }

        public List<BehandelingAgenda> GetBehandelingAgendas() {
            return BehandelingAgendas;
        }

        public List<Behandeling> GetBehandelings()
        {
            return Behandelings;
        }

        public bool HaveToBehandeling(string behandelingName)
        {
            if (Behandelings.Where(x => x.Name == behandelingName).Any())
                return true;
            else
                return false;
        }


        public List<Time> CalculateWachtLijst(long spesialistBSN, string behandelingName,DateTime selectedDay)
        {

            List<Time> times = new List<Time>();
            Behandeling behandeling = Behandelings.Where(x => x.Name == behandelingName).First();
            if (behandeling!= null)
            {
                Specialist specialist = Specialists.Where(x => x.BSN == spesialistBSN &&
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

                            Time time = behandelingAgenda.BegintTime;
                            while (IsTime1Smaller(time, behandelingAgenda.EindTime))
                            {

                                if (patiënts.Count > 0)
                                {
                                    foreach (Patiënt item in patiënts)
                                    {
                                        if (!item.Brieven.Where(x => x.BehandelingDatum == selectedDay
                                        && x.Behandeling.Name == behandelingName &&
                                        x.BriefStatus == BriefStatus.AanDeBeurt &&
                                        x.BegintTime == time
                                        ).Any())
                                        {
                                            times.Add(time);

                                        }

                                    }
                                }
                                else
                                {
                                    times.Add(time);
                                }
                                time = CalculateNewTime(time, durationTime);
                            }

                        }
                    }
                    

                }
                

            }
            
            return times;
        }
        
        private Time CalculateNewTime(Time time,Time durationTime)
        {
            

           

            int oudHour = time.Hour;
            int oudMin = time.Min;


            int newHour = durationTime.Hour;
            int newMin = durationTime.Min;

            

            TimeSpan timeSpanOud =new TimeSpan(oudHour,oudMin,0);
            TimeSpan timeSpanNew = new TimeSpan(newHour,newMin,0);


            TimeSpan newTime = timeSpanOud + timeSpanNew;
            Time returnTime = new Time();
            returnTime.SetTime(newTime.Hours, newTime.Minutes);
            return returnTime;
        }

        private bool IsTime1Smaller(Time time1, Time time2)
        {
 
            TimeSpan timeSpan1 = new TimeSpan(time1.Hour, time1.Min, 0);
            TimeSpan timeSpan2 = new TimeSpan(time2.Hour, time2.Min, 0);
            if(timeSpan1 < timeSpan2)
                return true;
            else
                return false;
        }
    
    }
}
