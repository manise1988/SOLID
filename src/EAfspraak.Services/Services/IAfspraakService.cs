using EAfspraak.Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Services
{
    public interface IAfspraakService
    {

        public Brief MaakAfspraak();
        public void RegisterBrief(Patiënt patiënt, Brief verwijsBrief);

        public List<Centrum> GetCentrums(Behandeling behandeling);
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN, string categoryName, string behandelingName, DateTime selectedDay);


    }
}
