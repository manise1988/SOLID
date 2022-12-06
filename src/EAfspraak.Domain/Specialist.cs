using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;

namespace EAfspraak.Domain
{
    public class Specialist : Persoon
    {
        private Category category;
        public Category Category { get { return category; } }

        public List<Vrij> VerlofAgendas { get; private set; }
        public Specialist(long bsn, string firstName, string lastName, Category category)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            this.category = category;
            VerlofAgendas = new List<Vrij>();


        }

        public void AddVerlof(Vrij verlof)
        {
            VerlofAgendas.Add(verlof);
        }

    }


}
