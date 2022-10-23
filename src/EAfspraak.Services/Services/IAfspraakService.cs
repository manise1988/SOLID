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

        public VerwijsBrief MaakAfspraak();
        public void RegisterBrief(Patiënt patiënt, VerwijsBrief verwijsBrief);

        public List<Centrum> GetCentrums(Behandeling behandeling);
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN, string categoryName, string behandelingName, DateTime selectedDay);

        public List<Category> GetCategories();

        public List<Huisarts> GetHuisartsen();
        public List<Patiënt> GetPatienten();

    }
}
