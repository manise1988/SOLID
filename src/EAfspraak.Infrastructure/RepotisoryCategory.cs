using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure
{
    public class RepotisoryCategory : IRepotisoryCategory
    {
        
        public List<Category> ReadData()
        {
            DataRepotisory dataRepository = new DataRepotisory();
            List<Category> categories = new List<Category>();

            List<DTO.Category> dtoCategories = dataRepository.ReadData<List<DTO.Category>>("Category");
            List<DTO.Behandeling> dtoBehandelingen = dataRepository.ReadData<List<DTO.Behandeling>>("Behandeling");
            foreach (DTO.Category item in dtoCategories)
            {
                Category category = new Category(item.Name);
                foreach (DTO.Behandeling itemBehandeling in dtoBehandelingen.Where(x => x.CategoryName == item.Name))
                {
                   
                    Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                        new Time(itemBehandeling.DurationTime), itemBehandeling.IsVerwijsbriefNodig,itemBehandeling.BehandelingGroep);
                    category.Behandelingen.Add(behandeling);

                }
                categories.Add(category);
            }
            return categories;
        }
        public void SaveData(List<Category> data)
        {
            DataRepotisory dataRepository = new DataRepotisory();
            List<DTO.Category> dtoCategories = new List<DTO.Category>();
            List<DTO.Behandeling> dtoBehandelings = new List<DTO.Behandeling>();
            foreach (var item in data)
            {

                dtoCategories.Add(new DTO.Category(item.Name));
                foreach (var itemBehandeling in item.Behandelingen)
                {
                    dtoBehandelings.Add(new DTO.Behandeling(itemBehandeling.Name,
                        itemBehandeling.DurationTime.GetTime().ToString(), itemBehandeling.IsVerwijsbriefNodig, item.Name,itemBehandeling.BehandelingGroep));


                }


            }
            dataRepository.SaveData(dtoCategories, "Category");
            dataRepository.SaveData(dtoBehandelings, "Behandeling");
        }
    }
}
