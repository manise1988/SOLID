using EAfspraak.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    public interface IAvailable
    {

        List<Behandeling> BehandelingList { get; set; }

        bool IsAvailable(string name);
    }
}
