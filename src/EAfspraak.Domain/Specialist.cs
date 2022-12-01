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

        private List<Verlof> verlofAgendas;
        public List<Verlof> VerlofAgendas { get { return verlofAgendas; } }
        public Specialist(long bsn, string firstName, string lastName, Category category)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            this.category = category;
            this.verlofAgendas = new List<Verlof>();


        }

        public void AddVerlof(Verlof verlof)
        {
            VerlofAgendas.Add(verlof);
        }

    }


}
