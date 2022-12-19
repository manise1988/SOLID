using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public class BehandelingViewModel
    {
        private string name;
        private string durationTime;
        public string Name { get { return this.name; } }
        public string  DurationTime { get { return durationTime; } }

        public BehandelingViewModel(string name, string durationTime)
        {
            this.name = name;
            this.durationTime = durationTime;
           

                  
        }
    }
}
