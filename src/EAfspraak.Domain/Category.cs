using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;

namespace EAfspraak.Domain;
public class Category
{

    public string Name { get; set; }
    [JsonConverter(typeof(ConcreteConverter<Behandeling[]>))]
    public IBehandeling[] Behandelingen { get; set; }
    public Category(string name)
    {
        Name = name;
        // Behandelingen = behandelingen;
        //Behandelingen = new List<IBehandeling>();
    }

    //public Category(string name, IBehandeling[] behandelingen)
    //{
    //    Name = name;
    //    Behandelingen = behandelingen;
    //    //Behandelingen = new List<IBehandeling>();
    //}


    public void AddBehandeling(IBehandeling behandeling)
    {
        //Dictionary<string, IBehandeling> BehandelingenList = Behandelingen.ToDictionary(s => s.Name, s => s);
        //int key = Behandelingen.Count()-1;

        //BehandelingenList.Add(key.ToString(), behandeling);
        Behandelingen.Append(behandeling);
    }
}