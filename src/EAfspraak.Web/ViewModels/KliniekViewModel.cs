
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public class KliniekViewModel
    {
        public string Name { get;}
        public string Detail { get; }
        
        public string locatie { get;  }
        public List<KliniekTijdenViewModel>  Agendas { get; }
        public KliniekViewModel(string name, string detail, string locatie, List<KliniekTijdenViewModel> agendas)
        {
            Name = name;
            Detail = detail;
            this.locatie = locatie;
            Agendas = agendas;
        }
    }
}
