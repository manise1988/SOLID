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
                    
                    // For a day
                    string selectedDayOfWeek = selectedDay.DayOfWeek.ToString();

                   
                    BehandelingAgenda behandelingAgenda = BehandelingAgendas.Where(x =>
                    x.Sepecialist.BSN == specialist.BSN && x.werkdag.ToString() == selectedDayOfWeek).First();

                    
                    string time = behandelingAgenda.BegintTime;
                    while (time != behandelingAgenda.EindTime)
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
                        time = time + durationTime;
                    }
                    ///////////////////////






                }
                

            }
            
            return times;
        }
    }
}
