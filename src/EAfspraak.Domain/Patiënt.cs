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

        public DateTime Birthday { get; }

        public List<VerwijsBrief> Brieven { get; }

        public int Age
        {
            get { return this.CalculateAge(); }
        }
        public Patiënt(long bsn, string firstName, string lastName, DateTime birthday)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Brieven = new List<VerwijsBrief>();

        }

        public void RegisterBrief(VerwijsBrief brief)
        {
            Brieven.Add(brief);
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
            age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
