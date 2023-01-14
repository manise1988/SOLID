using EAfspraak.Domain;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System.Security.Cryptography;
using UnitTestProject.Mock;

namespace UnitTestProject;
public class UnitTestAfspraak
    {
    //AfspraakMaken Test

    [Fact]
    public void TestMaakAfspraakInEenKliniekDieInDerangvanTimeIsViaMock()
    {
        Kliniek kliniek = new Kliniek("Test", "Helmond");
        Category category = new Category("category 1");
        IBehandeling behandeling = new BehandelingTest("b1", new Time("30.00"));

        Specialist specialist = new Specialist(1234567895, "Ali", "Hata", category);
        Patient patient = new Patient(1235478960, "P1", "", DateTime.Parse("12-10-2020"));

        category.AddBehandeling(behandeling);

        IAfspraak[] AfspraakList = {
        new AfspraakTest(behandeling,DateTime.Now,new Time("08.00"),specialist,patient),
        new AfspraakTest(behandeling,DateTime.Now,new Time("08.30"),specialist,patient)

        };


        Afspraak afspraak = new Afspraak(behandeling,
             DateTime.Now, new Time("08.30"), specialist, patient, kliniek);

        Assert.False(afspraak.HasAdded(AfspraakList));


    }



    [Fact]
    public void TestMaakAfspraakInEenKliniekDieInBehandelingAccessTrueIsViaMock()
    {

        Kliniek kliniek = new Kliniek("Test", "Helmond");
        Category category = new Category("category 1");
        IBehandeling behandeling = new BehandelingTest( "b1",true);

        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(1234567895, "Ali", "Hatami", category);
        Patient patient = new Patient(1235478960, "P1", "", DateTime.Parse("01-01-2020"));

       
        Afspraak afspraak = new Afspraak(behandeling,
             DateTime.Now, new Time("08.30"), specialist, patient, kliniek);


        
        Assert.True(afspraak.HasAdded(null));


    }
    [Fact]
    public void TestMaakAfspraakInEenKliniekDieInBehandelingAccessFalseIsViaMock()
    {


        Kliniek kliniek = new Kliniek("Test", "Helmond");
        Category category = new Category("category 1");
        IBehandeling behandeling = new BehandelingTest("b1",false);

        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(1234567895, "Ali", "Hata", category);
        Patient patient = new Patient(1235478960, "P1", "", DateTime.Parse("12-10-2020"));

        Afspraak afspraak = new Afspraak(behandeling,
             DateTime.Now, new Time("08.30"), specialist, patient, kliniek);

        Assert.False(afspraak.HasAdded(null));


    }


    // Test op berekeningen
    [Fact]
    public void TestOpBerekeningBehandeling()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist, Werkdag.Monday
            , new Time("08.00"), new Time("18.00"));

        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
        kliniek.AddBehandelingAgenda(agenad);


        IBerekening berekening = new BerekeningBehandeling(behandeling);
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Equal(testList.First().Time.GetTime(), "08.00");



    }

    [Fact]
    public void TestOpBerekeningBehandelingMet2VerscillendeTijdInEenDagInBehandelingAgendazonderAfspraken()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist, Werkdag.Monday
            , new Time("08.00"), new Time("9.00"));
        kliniek.AddBehandelingAgenda(agenad);

        agenad = new BehandelingAgenda(specialist, Werkdag.Monday
           , new Time("11.00"), new Time("12.00"));
        kliniek.AddBehandelingAgenda(agenad);
        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
       
       


        IBerekening berekening = new BerekeningBehandeling(behandeling);
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Equal(testList.ToList().Where(x => x.Time.GetTime() == "11.00").First().Time.GetTime(), "11.00");



    }

    [Fact]
    public void TestOpBerekeningWerkdagOpverschilendewerkdag()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        Werkdag werkdag = (Werkdag)Enum.Parse(typeof(Werkdag), DateTime.Now.DayOfWeek.ToString(), true);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist,werkdag,
              new Time("08.00"), new Time("10.00"));

        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
        kliniek.AddBehandelingAgenda(agenad);


        IBerekening berekening = new BerekeningOpWerkdag(behandeling,(Werkdag)Enum.Parse(typeof(Werkdag), DateTime.Now.AddDays(1).DayOfWeek.ToString(), true));
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Empty(testList);



    }

    [Fact]
    public void TestOpBerekeningWerkdag()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        Werkdag werkdag = (Werkdag)Enum.Parse(typeof(Werkdag), DateTime.Now.DayOfWeek.ToString(), true);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist, werkdag,
              new Time("08.00"), new Time("10.00"));

        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
        kliniek.AddBehandelingAgenda(agenad);


        IBerekening berekening = new BerekeningOpWerkdag(behandeling, werkdag);
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Equal(testList.First().Time.GetTime(), "08.00");


    }



    [Fact]
    public void TestOpBerekeningDatumOpverschilendeDatum()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        Werkdag werkdag = (Werkdag)Enum.Parse(typeof(Werkdag), DateTime.Now.DayOfWeek.ToString(), true);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist, werkdag,
              new Time("08.00"), new Time("10.00"));

        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
        kliniek.AddBehandelingAgenda(agenad);


        IBerekening berekening = new BerekeningOpDatum(behandeling,  DateTime.Now.AddDays(1));
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Empty(testList);



    }

    [Fact]
    public void TestOpBerekeningDatum()
    {

        Kliniek kliniek = new Kliniek("K1", "Helmond");

        LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
        Category category = new Category("c1");
        category.AddBehandeling(behandeling);

        Specialist specialist = new Specialist(123, "Alie", "", category);

        Werkdag werkdag = (Werkdag)Enum.Parse(typeof(Werkdag), DateTime.Now.DayOfWeek.ToString(), true);

        BehandelingAgenda agenad = new BehandelingAgenda(specialist, werkdag,
              new Time("08.00"), new Time("10.00"));

        kliniek.AddSpesialistToKliniek(specialist);
        kliniek.AddBehandelingToKliniek(behandeling);
        kliniek.AddBehandelingAgenda(agenad);


        IBerekening berekening = new BerekeningOpDatum(behandeling, DateTime.Now);
        List<BeschikbareTijd> testList = berekening.Calculate(kliniek, null);

        Assert.Equal(testList.First().Time.GetTime(), "08.00");


    }



    [Fact]
    public void TestOpCalculatorZonderAfspraken()
    {
        Kliniek kliniek = new Kliniek("K1", "Helmond");

        Specialist specialist = new Specialist(123, "Alie", "", null);

        BehandelingAgenda[] agenads = {
                new BehandelingAgenda(specialist,
                (Werkdag) Enum.Parse(typeof(Werkdag),DateTime.Now.DayOfWeek.ToString(),true),
                new Time("08.00"),
                new Time("12.00"))
            };
        DateTime date = DateTime.Now;
        Time durationTime = new Time("00.40");

        TimeBerekening timeBerekening = new TimeBerekening();

        Calculator calculator = new Calculator(agenads, null, date, durationTime);
        List<BeschikbareTijd> test = calculator.MaakBeschikbareTijden(kliniek);

        Assert.Equal(timeBerekening.VolgendeTime(test.Last().Time, durationTime).GetTime(), agenads.First().EndTime.GetTime());

    }

    [Fact]
    public void TestOpCalculatorMetAfsprakenEnVerschilendeDurationTimeInBehandelingEnAfspraak()
    {
        Kliniek kliniek = new Kliniek("K1", "Helmond");

        IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), null);

          
        BehandelingAgenda[] agenads = {
                new BehandelingAgenda(null,
                (Werkdag) Enum.Parse(typeof(Werkdag),DateTime.Now.DayOfWeek.ToString(),true),
                new Time("08.00"),
                new Time("12.00"))
            };
        DateTime date = DateTime.Now;
        Time durationTime = new Time("00.40");

        Patient patient = new Patient(1235478960, "P1", "", DateTime.Parse("12-10-2020"));

        IAfspraak[] afspraken =
        {
            new AfspraakTest(behandeling,DateTime.Now,new Time("09.00"))
        };

        TimeBerekening timeBerekening = new TimeBerekening();

        Calculator calculator = new Calculator(agenads, afspraken, date, durationTime);
        List<BeschikbareTijd> test = calculator.MaakBeschikbareTijden(kliniek);
        
        bool check = timeBerekening.IsTime1EqualSmaller(test.Last().Time, agenads.First().EndTime);

        Assert.True(check);
    }
}
