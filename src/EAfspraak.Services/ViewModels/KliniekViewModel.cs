using EAfspraak.Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.ViewModels
{
    public class KliniekViewModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string locatie { get; set; }
        public List<Agenda>  Agendas { get; set; }
        public KliniekViewModel(string name, string detail, string locatie, List<Agenda> agendas)
        {
            Name = name;
            Detail = detail;
            this.locatie = locatie;
            Agendas = agendas;
        }
    }
}
