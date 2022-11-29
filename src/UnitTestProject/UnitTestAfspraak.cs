using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;

namespace UnitTestProject
{
    public class UnitTestAfspraak
    {
        [Fact]
        public void TestMaakAfspraakInEenKliniek()
        {

            ZoekBereik zoekBereik = new ZoekBereik(7);
            Kliniek kliniek =new Kliniek("Test","Helmond",zoekBereik);
            Category category = new Category("category 1");
            Behandeling behandeling = new Behandeling("bahandeling1", new Time("30.00"), true);
            category.AddBehandeling(behandeling);
           
            Specialist specialist =new Specialist(1234567895,"Ali","Hata",category);
            Patiënt patient = new Patiënt(1235478960,"P1","","12-10-2020","","");

            Afspraak afspraak = new Afspraak(category, behandeling, "", AfspraakStatus.InBehandeling,
                DateTime.Now, DateTime.Now, new Time("08.30"), specialist, patient);
            kliniek.AddAfspraakToKliniek(afspraak);
            Assert.Equal(kliniek.GetAfspraken().First().Patiënt.FirstName,"P1");

            
        }
    }
}