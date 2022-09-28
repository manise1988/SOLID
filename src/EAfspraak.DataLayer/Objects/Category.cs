﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public  class Category:ClassBase
    {
        public string Name { get; set; }
        public List<Behandeling> Behandelings { get; set; }
        public Category(string name)
        {
            Name = name;
            base.Id = Guid.NewGuid().GetHashCode();
            
        }
    }
}