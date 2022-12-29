using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EAfspraak.Domain;
public class Category
{

    public string Name { get; set; }
    [JsonConverter(typeof(ConcreteConverter<Behandeling[]>))]
    public IBehandeling[] Behandelingen { get; set; }
    public Category(string name)
    {
        Name = name;
    }

    public void AddBehandeling(IBehandeling behandeling)
    {
        List<IBehandeling> list = new List<IBehandeling>();
        if (Behandelingen != null)
            list = Behandelingen.ToList();
        list.Add(behandeling);
        Behandelingen = list.ToArray();


       
    }
}