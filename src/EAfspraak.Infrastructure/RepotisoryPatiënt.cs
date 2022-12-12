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

        public List<Huisarts> ReadHuisarts()
        {
            List<Huisarts> huisartsen = new List<Huisarts>();
            DataRepotisory dataRepository = new DataRepotisory();
            List<DTO.Persoon> dtoHuisartsen = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").Where(x => x.Role == "huisarts").ToList();


            foreach (var item in dtoHuisartsen)
            {

                huisartsen.Add(new Huisarts(item.BSN, item.FirstName, item.LastName,
                    item.Birthday));

            }



            return huisartsen;
        }
        public List<Patiënt> ReadPatiënt()
        {
            List<Patiënt> patiënten = new List<Patiënt>();

            RepotisoryCategory repotisoryCategory = new RepotisoryCategory();
            List<Category> categories = repotisoryCategory.ReadData();

            DataRepotisory dataRepository = new DataRepotisory();
            List<DTO.Persoon> dtoPatienten = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").Where(x => x.Role == "patient").ToList();
            List<DTO.VerwijsBrief> dtoBrieven = dataRepository.ReadData<List<DTO.VerwijsBrief>>("VerwijsBrief");

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    DateTime.Parse(item.Birthday));
                if (dtoBrieven != null)
                    foreach (var itemBrieven in dtoBrieven.Where(x => x.Bsn == item.BSN).ToList())
                    {
                        Category category = categories.Where(x => x.Name == itemBrieven.CategoryName).First();
                        IBehandeling behandeling = category.Behandelingen.Where(x => x.Name == itemBrieven.BehandelingName).First();

                        patiënt.RegisterBrief(new VerwijsBrief(category, behandeling, itemBrieven.Details,
                            (BriefStatus)Enum.Parse(typeof(BriefStatus), itemBrieven.BriefStatus),
                           itemBrieven.RegisterDate));

                    }

                patiënten.Add(patiënt);

            }



            return patiënten;
        }

        //public void SaveData(List<Patiënt> dataPatiënt, List<Huisarts> dataHuisarts)
        //{
        //    DataRepotisory dataRepository = new DataRepotisory();
        //    List<DTO.Persoon> dtoPersonen = new List<DTO.Persoon>();
        //    List<DTO.VerwijsBrief> dtoBrieven = new List<DTO.VerwijsBrief>();
        //    foreach (var item in dataPatiënt)
        //    {

        //        dtoPersonen.Add(new DTO.Persoon(item.BSN, item.FirstName, item.LastName, item.Birthday.ToShortDateString(), item.EmailAddress, item.Address, "patient"));
        //        foreach (var itemBrief in item.Brieven)
        //        {
        //            dtoBrieven.Add(new DTO.VerwijsBrief(item.BSN, itemBrief.Category.Name, itemBrief.Behandeling.Name, itemBrief.Details,
        //                itemBrief.BriefStatus.ToString(), itemBrief.RegisterDate));


        //        }


        //    }

        //    foreach (var item in dataHuisarts)
        //    {

        //        dtoPersonen.Add(new DTO.Persoon(item.BSN, item.FirstName, item.LastName, item.Birthday, "", "", "huisarts"));


        //    }
        //    dataRepository.SaveData(dtoPersonen, "Persoon");
        //    dataRepository.SaveData(dtoBrieven, "VerwijsBrief");

        //}
    }
}
