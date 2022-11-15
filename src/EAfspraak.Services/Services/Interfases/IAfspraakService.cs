using EAfspraak.Domain;
using EAfspraak.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Services.Interfases
{
    public interface IAfspraakService
    {

        public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
           string date, string time);
        public void RegisterBrief(Patiënt patiënt, VerwijsBrief verwijsBrief);

        public List<Kliniek> GetCentrums(Behandeling behandeling);

        public List<KliniekViewModel> GetCentrumsMetVrijeTijden(string behandelingName);

        public List<CategoryViewModel> GetCategories();

        public List<Huisarts> GetHuisartsen();
        public List<Patiënt> GetPatienten();

    }
}
