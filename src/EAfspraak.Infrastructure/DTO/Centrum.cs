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
        private string[] behandelingenName;


        public string[] BehandelingenName { get { return this.behandelingenName; } }

        public Specialist[] Specialisten { get { return this.specialisten; } }


        public Centrum(string name, Specialist[] specialisten,
            string[] behandelingenName)
        {
            this.name = name;
            this.behandelingenName = behandelingenName;

            this.specialisten = specialisten;
        }
    }
}
