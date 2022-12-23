using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System.Security.Cryptography;
using UnitTestProject.Mock;

namespace UnitTestProject
{
    public class UnitTestAfspraak
    {
       
        [Fact]
        public void TestMaakAfspraakInEenKliniekAccesstrue()
        {

            Kliniek kliniek =new Kliniek("Test","Helmond");
            Category category = new Category("category 1");
            IBehandeling behandeling = new BehandelingTest("bahandeling1", true);
            category.AddBehandeling(behandeling);
            Specialist specialist =new Specialist(1234567895,"Ali","Hata",category);
            Patiënt patient = new Patiënt(1235478960,"P1","",DateTime.Parse("12-10-2020"));

            Afspraak afspraak = new Afspraak( behandeling, 
                 DateTime.Now, new Time("08.30"), specialist, patient,kliniek);

         //   kliniek.AddAfspraakToKliniek(afspraak);
            Assert.Equal(afspraak.Patiënt.FirstName,"P1");

            
        }
        [Fact]
        public void TestMaakAfspraakInEenKliniekAccessFalse()
        {


            Kliniek kliniek = new Kliniek("Test", "Helmond");
            Category category = new Category("category 1");
            IBehandeling behandeling = new BehandelingTest("bahandeling1", false);
            category.AddBehandeling(behandeling);

            Specialist specialist = new Specialist(1234567895, "Ali", "Hata", category);
            Patiënt patient = new Patiënt(1235478960, "P1", "", DateTime.Parse("12-10-2020"));

            Afspraak afspraak = new Afspraak( behandeling, 
                 DateTime.Now, new Time("08.30"), specialist, patient,kliniek);
            //kliniek.AddAfspraakToKliniek(afspraak);
            Assert.Equal(afspraak.Patiënt.FirstName, "P1");


        }

        [Fact]
        public void TestOpBerekeningBase()
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


            IBerekening berekening = new BerekeningBehandeling( behandeling);
            List<BeschikbareTijd> testList = berekening.Calculate(kliniek,null);

            Assert.Equal(testList.First().Time.GetTime(), "08.00");



        }

        [Fact]
        public void TestOpBerekeningBaseMet2VerscillendeTijdInEenDagInBehandelingAgenda()
        {
           
            Kliniek kliniek = new Kliniek("K1", "Helmond");

            LeeftijdRange leeftijdRange = new LeeftijdRange(0, 100);
            IBehandeling behandeling = new Behandeling("B1", new Time("00.30"), leeftijdRange);
            Category category = new Category("c1");
            category.AddBehandeling(behandeling);

            Specialist specialist = new Specialist(123, "Alie", "", category);

            BehandelingAgenda agenad = new BehandelingAgenda(specialist, Werkdag.Monday
                , new Time("08.00"), new Time("12.00"));

            kliniek.AddSpesialistToKliniek(specialist);
            kliniek.AddBehandelingToKliniek(behandeling);
            kliniek.AddBehandelingAgenda(agenad);
            agenad = new BehandelingAgenda(specialist, Werkdag.Monday
                , new Time("13.00"), new Time("18.00"));


            IBerekening berekening = new BerekeningBehandeling(behandeling);
            List<BeschikbareTijd> testList = berekening.Calculate(kliniek,null);

            Assert.Equal(testList.ToList().Where(x=> x.Time.GetTime()=="13.00").First().Time.GetTime(),"13.00");



        }

    }
}