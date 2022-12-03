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
        private bool isVerwijsbriefNodig;
        private string  categoryName;

        
        public string Name { get { return this.name; } }
        public string DurationTime { get { return durationTime; } }
        public bool IsVerwijsbriefNodig { get { return this.isVerwijsbriefNodig; } }

        public string CategoryName { get { return categoryName; } }

        private BehandelingGroep behandelingGroep;
        public BehandelingGroep BehandelingGroep { get { return behandelingGroep; } }
        public Behandeling(string name, string durationTime, bool isVerwijsbriefNodig, string  categoryName,BehandelingGroep behandelingGroep)
        {
           
            this.name = name;
            this.durationTime = durationTime;
            this.isVerwijsbriefNodig = isVerwijsbriefNodig;
            this.categoryName = categoryName;
            this.behandelingGroep = behandelingGroep;



        }
    }
}
