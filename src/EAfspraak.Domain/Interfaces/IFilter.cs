using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    internal interface IFilter<TEntity> where TEntity : class
    {
        TEntity[] Get(TEntity[] data);

    }
}
