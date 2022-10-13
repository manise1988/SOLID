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
        public string Address { get { return this.Address; } }

        private List<Brief> brieven;
        public List<Brief> Brieven { get { return this.brieven; } }

        public Patiënt(long bsn,string firstName, string lastName, DateTime birthday, string emailAddress, string address)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.birthday = birthday;
            this.emailAddress = emailAddress;
            this.address = address;
            this.brieven = new List<Brief>();
            
        }

        public void RegisterBrief(Brief brief)
        {
            this.brieven.Add(brief);
        }

        private void CloseVerwijsBrief()
        {
            foreach (var item in this.brieven.Where(x => x.BehandelingDatum < DateTime.Now).ToList())
            {
                item.BriefStatus = BriefStatus.Closed;
            }
              
        }
        public List<Brief> GetVerwijsBrievenAanDeBeurt()
        {
            CloseVerwijsBrief();
            return Brieven.Where(x => x.BriefStatus == BriefStatus.AanDeBeurt).ToList();
        }

    }
}
