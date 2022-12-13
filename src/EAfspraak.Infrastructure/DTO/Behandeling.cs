using EAfspraak.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public  class Behandeling
    {
        
        private string name;
        private string durationTime; 
        private string  categoryName;

        
        public string Name { get { return this.name; } }
        public string DurationTime { get { return durationTime; } }

        public string CategoryName { get { return categoryName; } }

        private LeeftijdRange behandelingGroep;
        public LeeftijdRange BehandelingGroep { get { return behandelingGroep; } }
        public Behandeling(string name, string durationTime, string  categoryName,LeeftijdRange behandelingGroep)
        {
           
            this.name = name;
            this.durationTime = durationTime;
            this.categoryName = categoryName;
            this.behandelingGroep = behandelingGroep;



        }
    }
}
