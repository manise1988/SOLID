﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public enum AfspraakStatus
{
    InBehandeling,
    Close
}



public enum BriefStatus
{

    Open,
    Close
}

public enum Werkdag
{
    Monday = 0,
    Tuesday = 1,
    Wednesday = 2,
    Thursday = 3,
    Friday = 4,
    Saturday = 5
}

public enum VrijType
{
    Vakantie,
    Verlof
}


