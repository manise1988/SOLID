using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Patiënt : Persoon
    {

        private string birthday;
        public string Birthday { get { return birthday; } }

        private string emailAddress;
        public string EmailAddress { get { return emailAddress; } }

        private string address;
        public string Address { get { return address; } }

        private List<VerwijsBrief> brieven;
        public List<VerwijsBrief> Brieven { get { return brieven; } }

        public Patiënt(long bsn, string firstName, string lastName, string birthday, string emailAddress, string address)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            this.birthday = birthday;
            this.emailAddress = emailAddress;
            this.address = address;
            brieven = new List<VerwijsBrief>();

        }

        public void RegisterBrief(VerwijsBrief brief)
        {
            brieven.Add(brief);
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
