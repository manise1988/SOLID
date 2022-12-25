using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public class BehandelingViewModel
    {
        public string Name { get; }
        public string  DurationTime { get; }

        public BehandelingViewModel(string name, string durationTime)
        {
           Name = name;
           DurationTime = durationTime;
           

                  
        }
    }
}
