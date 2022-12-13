using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure
{
    public class RepotisoryPersoon : IRepotisoryPersoon
    {


        public List<Patiënt> ReadPatiënt()
        {
            List<Patiënt> patiënten = new List<Patiënt>();

            RepotisoryCategory repotisoryCategory = new RepotisoryCategory();
            List<Category> categories = repotisoryCategory.ReadData();

            DataRepotisory dataRepository = new DataRepotisory();
            List<DTO.Persoon> dtoPatienten = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").ToList();

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    DateTime.Parse(item.Birthday));

                patiënten.Add(patiënt);

            }



            return patiënten;
        }

   
    }
}
