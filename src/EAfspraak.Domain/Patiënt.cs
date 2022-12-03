using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;

namespace EAfspraak.Domain
{
    public class Patiënt : Persoon
    {

        private DateTime birthday;
        public DateTime Birthday { get { return birthday; } }

        private string emailAddress;
        public string EmailAddress { get { return emailAddress; } }

        private string address;
        public string Address { get { return address; } }

        private List<VerwijsBrief> brieven;
        public List<VerwijsBrief> Brieven { get { return brieven; } }

        public int Age
        {
            get { return this.CalculateAge(); }
        }
        public Patiënt(long bsn, string firstName, string lastName, DateTime birthday, string emailAddress, string address)
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
        private int CalculateAge()
        {
            int age = 0;
            age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
