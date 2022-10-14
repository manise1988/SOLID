using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Centrum
    {
        private string name;
        public string Name { get { return this.name; } }


        private Specialist[] specialisten;
        private Behandeling[] behandelingen;
        private BehandelingAgenda[] behandelingAgendas;
        private Patiënt[] patiënten;

        public Specialist[] Specialisten { get { return this.specialisten; } }
        public Behandeling[] Behandelingen { get { return this.behandelingen; } }
        public BehandelingAgenda[] BehandelingAgendas { get { return this.behandelingAgendas; } }
        public Patiënt[] Patiënten { get { return this.patiënten; } }
        public Centrum(string name, Specialist[] specialisten,
            Behandeling[] behandelingen, BehandelingAgenda[] behandelingAgendas,
            Patiënt[] patiënten)
        {
            this.name = name;
            this.specialisten = specialisten;
            this.behandelingen = behandelingen;
            this.behandelingAgendas = behandelingAgendas;
            this.patiënten = patiënten;
        }
    }
}
