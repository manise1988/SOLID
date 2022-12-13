using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using UnitTestProject.Mock;

namespace UnitTestProject
{
    public class UnitTestAfspraak
    {
        [Fact]
        public void TestMaakAfspraakInEenKliniekAccesstrue()
        {

            KliniekSetting zoekBereik = new KliniekSetting(7);
            Kliniek kliniek =new Kliniek("Test","Helmond",zoekBereik);
            Category category = new Category("category 1");
            IBehandeling behandeling = new BehandelingTest("bahandeling1", true);
            category.AddBehandeling(behandeling);
           
            Specialist specialist =new Specialist(1234567895,"Ali","Hata",category);
            Patiënt patient = new Patiënt(1235478960,"P1","",DateTime.Parse("12-10-2020"));

            Afspraak afspraak = new Afspraak(category, behandeling, AfspraakStatus.InBehandeling,
                 DateTime.Now, new Time("08.30"), specialist, patient);
            kliniek.AddAfspraakToKliniek(afspraak);
            Assert.Equal(kliniek.Afspraken.First().Patiënt.FirstName,"P1");

            
        }
        [Fact]
        public void TestMaakAfspraakInEenKliniekAccessFalse()
        {

            KliniekSetting zoekBereik = new KliniekSetting(7);
            Kliniek kliniek = new Kliniek("Test", "Helmond", zoekBereik);
            Category category = new Category("category 1");
            IBehandeling behandeling = new BehandelingTest("bahandeling1", false);
            category.AddBehandeling(behandeling);

            Specialist specialist = new Specialist(1234567895, "Ali", "Hata", category);
            Patiënt patient = new Patiënt(1235478960, "P1", "", DateTime.Parse("12-10-2020"));

            Afspraak afspraak = new Afspraak(category, behandeling, AfspraakStatus.InBehandeling,
                 DateTime.Now, new Time("08.30"), specialist, patient);
            kliniek.AddAfspraakToKliniek(afspraak);
            Assert.Equal(kliniek.Afspraken.First().Patiënt.FirstName, "P1");


        }
    }
}