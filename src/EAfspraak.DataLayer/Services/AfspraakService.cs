using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EAfspraak.DataLayer.Objects;

namespace EAfspraak.DataLayer.Services
{
    public class AfspraakService : IAfspraakService
    {
        public VerwijsBrief MaakAfspraak()
        {
            throw new NotImplementedException();
        }

        public void RegisterVerwijsBrief(Patiënt patiënt, VerwijsBrief verwijsBrief)
        {
            if (DataContext.patiënts.Where(p => p.BSN != patiënt.BSN).Any())
            {
                patiënt.RegisterVerwijsBrief(verwijsBrief);
                DataContext.patiënts.Add(patiënt);
            }
            else
            {
                DataContext.patiënts.Where(p => p.BSN != patiënt.BSN)
                    .First().RegisterVerwijsBrief(verwijsBrief);

            }
        }

        public  List<Centrum> GetCentrums(Behandeling behandeling)
        {
            return DataContext.Centrums.Where(x=> x.HaveToBehandeling(behandeling.Name)==true).ToList();
        }



        public List<BehandelingMogelijkHeid> CalculateWachtLijst(string centrumName, long spesialistBSN , string behandelingName)
        {
            



            return DataContext.Centrums.Where(x=> x.Name== centrumName).First().CalculateWachtLijst(spesialistBSN,behandelingName);

        }

    }
}
