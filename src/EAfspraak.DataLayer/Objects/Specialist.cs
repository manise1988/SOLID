using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Specialist:PersonBase
    {
        public int CategoryId { get; set; }
        public int CentrumId { get; set; }
        public Specialist(long bsn,string name,int categoryId,int CentrumId)
        {
            base.BSN = bsn;
            base.Name = name;
            this.CategoryId = categoryId;
            this.CentrumId = CentrumId;
            base.Id = Guid.NewGuid().GetHashCode();
        }

    }


}
