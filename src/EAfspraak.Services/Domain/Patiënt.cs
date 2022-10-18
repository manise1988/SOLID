using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class Patiënt: PersonBase 
    {

        private DateTime birthday;
        public DateTime Birthday { get { return this.birthday; } }

        private string emailAddress;
        public string EmailAddress { get { return this.emailAddress; } }

        private string address;
        public string Address { get { return this.address; } }

        private List<VerwijsBrief> brieven;
        public List<VerwijsBrief> Brieven { get { return this.brieven; } }

        public Patiënt(long bsn,string firstName, string lastName, DateTime birthday, string emailAddress, string address)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.birthday = birthday;
            this.emailAddress = emailAddress;
            this.address = address;
            this.brieven = new List<VerwijsBrief>();
            
        }

        public void RegisterBrief(VerwijsBrief brief)
        {
            this.brieven.Add(brief);
        }

        public List<VerwijsBrief> GetOpenVerwijsBrieven()
        {
            return Brieven.Where(x => x.BriefStatus == BriefStatus.Open).ToList();
        }
        public void CloseVerwijsBrief(VerwijsBrief verwijsBrief)
        {
            verwijsBrief.CloseBriefStatus();
        }

    }
}
