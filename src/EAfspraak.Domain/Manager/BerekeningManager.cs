using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Manager;
public class BerekeningManager//:IBerekeningManager
{
    private readonly IRepositoryAfspraak repository;
    private readonly List<IBerekening> berekeningList;
    public BerekeningManager(IRepositoryAfspraak repository, List<IBerekening> berekeningList)
    {
        this.repository = repository;
        this.berekeningList = berekeningList;
    }

    public List<BeschikbareTijd> GetKliniekenMetVrijeTijden()
    {
        List<Kliniek> kliniekList = repository.ReadKliniek();
        kliniekList.Sort();

        List<BeschikbareTijd> BeschikbareTijdList = new List<BeschikbareTijd>();
        foreach (var item in kliniekList)
        {
            foreach (var itemBerekening in berekeningList)
            {
                Afspraak[] afspraken = repository.ReadAfspraakByKliniekNaam(item.Name);
                BeschikbareTijdList.AddRange(itemBerekening.Calculate(item, afspraken));
            }

        }

        return BeschikbareTijdList;
    }
}