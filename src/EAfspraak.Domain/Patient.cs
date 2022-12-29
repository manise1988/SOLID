using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;

namespace EAfspraak.Domain;
public class Patient : Persoon
{

    public DateTime Birthday { get; set; }


    public int Age
    {
        get { return this.CalculateAge(); }
    }
    public Patient(long bsn, string firstName, string lastName, DateTime birthday)
    {
        BSN = bsn;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;

    }

    private int CalculateAge()
    {
        int age = 0;
        age = DateTime.Now.Year - Birthday.Year;
        if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
            age = age - 1;

        return age;
    }

}
