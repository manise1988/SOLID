using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    public interface IBerekening
    {
        public string Value { get; }
        public Kliniek Kliniek { get; }
        public List<BeschikbareTijd> Calculate();

    }
}
