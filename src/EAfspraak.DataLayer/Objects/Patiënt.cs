using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Patiënt: PersonBase 
    {
        
        public DateTime Birthday { get; set; }
        public string EmailAddress { get; set; }    
        public string Address { get; set; }

        public List<VerwijsBrief> VerwijsBrieven { get; set; }

        public Patiënt(long bsn,string firstName, string lastName, DateTime birthday, string emailAddress, string address)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            Birthday = birthday;
            EmailAddress = emailAddress;
            Address = address;
            VerwijsBrieven = new List<VerwijsBrief>();
            
        }

        public void RegisterVerwijsBrief(VerwijsBrief verwijsBrief)
        {
            VerwijsBrieven.Add(verwijsBrief);
        }

        private void CloseVerwijsBrief()
        {
            foreach (var item in VerwijsBrieven.Where(x => x.BehandelingDatum < DateTime.Now).ToList())
            {
                item.BriefStatus = BriefStatus.Closed;
            }
              
        }
        public List<VerwijsBrief> GetVerwijsBrievenAanDeBeurt()
        {
            CloseVerwijsBrief();
            return VerwijsBrieven.Where(x => x.BriefStatus == BriefStatus.AanDeBeurt).ToList();
        }

    }
}
