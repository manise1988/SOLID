using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Kliniek
    {
        private string name;
        public string Name { get { return this.name; } }

        private string locatie;
        public string Locatie { get { return this.locatie; } }
        private Specialist[] specialisten;
        private string[] behandelingenName;


        public string[] BehandelingenName { get { return this.behandelingenName; } }

        public Specialist[] Specialisten { get { return this.specialisten; } }


        public Kliniek(string name,string locatie, Specialist[] specialisten,
            string[] behandelingenName)
        {
            this.name = name;
            this.locatie = locatie;
            this.behandelingenName = behandelingenName;

            this.specialisten = specialisten;
        }
    }
}
