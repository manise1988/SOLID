using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Centrum
    {
        public string Name { get; set; }
        public List<Specialist> Specialists { get;  }
        private  List<Behandeling> Behandelings { get; set; }
        private List<BehandelingAgenda> BehandelingAgendas { get; set; }

       
        private List<Patiënt> patiënts { get; set; }
        public Centrum(string name)
        {
            Name = name;
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

        public List<BehandelingAgenda> GetBehandelingMogelijkheids() {
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


        public List<string> CalculateWachtLijst(long spesialistBSN, string behandelingName,DateTime selectedDay)
        {

            List<string> times = new List<string>();
            Behandeling behandeling = Behandelings.Where(x => x.Name == behandelingName).First();
            if (behandeling!= null)
            {
                Specialist specialist = Specialists.Where(x => x.BSN == spesialistBSN &&
                x.Category.Behandelingen.Where(y => y.Name == behandelingName).Any()
                ).First();
                
                if(specialist != null)
                {
                    string durationTime = behandeling.DurationTime;
                    
                    string selectedDayOfWeek = selectedDay.DayOfWeek.ToString();
                    List<BehandelingAgenda> behandelingAgendas= new List<BehandelingAgenda>();

                    if (BehandelingAgendas.Where(x =>
                    x.Sepecialist.BSN == specialist.BSN && x.werkdag.ToString() == selectedDayOfWeek).Any())
                   
                   behandelingAgendas = BehandelingAgendas.Where(x =>
                    x.Sepecialist.BSN == specialist.BSN && x.werkdag.ToString() == selectedDayOfWeek).ToList();

                    if (behandelingAgendas.Count() > 0)
                    {
                        foreach (BehandelingAgenda behandelingAgenda in behandelingAgendas)
                        {

                            string time = behandelingAgenda.BegintTime;
                            while (IsTime1Smaller(time, behandelingAgenda.EindTime))
                            {

                                if (patiënts.Count > 0)
                                {
                                    foreach (Patiënt item in patiënts)
                                    {
                                        if (!item.VerwijsBrieven.Where(x => x.BehandelingDatum == selectedDay
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
        
        private string CalculateNewTime(string time,string durationTime)
        {
            

            string[] times = time.Split('.');
            string[] durationTimes = durationTime.Split('.');

            int oudHour = int.Parse(times[0]);
            int oudMin = int.Parse(times[1]);


            int newHour = int.Parse(durationTimes[0]);
            int newMin = int.Parse(durationTimes[1]);

            

            TimeSpan timeSpanOud =new TimeSpan(oudHour,oudMin,0);
            TimeSpan timeSpanNew = new TimeSpan(newHour,newMin,0);


            TimeSpan newTime = timeSpanOud + timeSpanNew;
            string hour = "";
            string min = "";
            if (newTime.Hours < 10)
                hour = "0" + newTime.Hours.ToString();
            else
                hour = newTime.Hours.ToString();

            if (newTime.Minutes < 10)
                min =  "0" + newTime.Minutes.ToString();
            else
                min =  newTime.Minutes.ToString();
            return hour + "." + min;
        }

        private bool IsTime1Smaller(string time1, string time2)
        {
            string[] times1 = time1.Split('.');
            string[] times2 = time2.Split('.');

            int hour1 = int.Parse(times1[0]);
            int min1 = int.Parse(times1[1]);


            int hour2 = int.Parse(times2[0]);
            int min2 = int.Parse(times2[1]);



            TimeSpan timeSpan1 = new TimeSpan(hour1, min1, 0);
            TimeSpan timeSpan2 = new TimeSpan(hour2, min2, 0);
            if(timeSpan1 < timeSpan2)
                return true;
            else
                return false;
        }
    
    }
}
