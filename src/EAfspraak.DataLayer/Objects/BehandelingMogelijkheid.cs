using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class BehandelingMogelijkheid:ClassBase
    {
        
        
        public int CentrumId { get; set; }  
        public int SepecialistId { get; set; }

        public Werkdag werkdag { get; set; }

        public string BegintTime { get; set; }
        public string EindTime { get; set; }
        public BehandelingMogelijkheid(int centrumId, int sepecialistId, Werkdag werkdag, string begintTime, string eindTime)
        {
            CentrumId = centrumId;
            SepecialistId = sepecialistId;
            this.werkdag = werkdag;
            BegintTime = begintTime;
            EindTime = eindTime;
            base.Id = Guid.NewGuid().GetHashCode();
        }
    }

    public enum Werkdag
    {
        maandag,
        dinsdag,
        woensdag,
        donderdag,
        vrijdag,
        zaterdag
    }
}
