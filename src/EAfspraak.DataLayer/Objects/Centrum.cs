﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Centrum:ClassBase
    {
        public string Name { get; set; }
        public List<Specialist> Specialists { get; set; }
        public Centrum(string name)
        {
            Name = name;
        }
    }
}
