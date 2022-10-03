using EAfspraak.DataLayer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer
{
    public static class DataContext
    {
        public static int CurrentId = 0;
        public static List<Category> Categories { get; set; }
        public static List<Centrum> Centrums { get; set; }
        public static List<Patiënt> patiënts { get; set; }
        

        public static void FullCategory()
        {
            Categories = new List<Category>();
            
            Category category = new Category("Orthopedie");
            List<Behandeling> Behandelings = new List<Behandeling>();
            Behandeling behandeling = new Behandeling("Nek Behandeling", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Elleboog behandelingen", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Heup behandelingen", 40);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Knee behandelingen", 60);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Voet behandelingen", 60);
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Neurochirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Cervicale kanaalstenose", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Cervicale foramenstenose", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Zenuwbeknelling", 40);
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Plastische chirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Onderooglidcorrectie", 120);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Liposuctie", 120);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Bovenooglidcorrectie", 120);
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Radiologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("MRI", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echo", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Röntgenfoto", 40 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echografie", 60 );
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

           
            category = new Category("Urologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Sterilisatie", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Erectiestoornis", 30 );
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Neurologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Epilepsie", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Klapvoet", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Lumbaalpunctie", 40 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Nekhernia", 60 );
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Fisyotherapie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Knee Behandeling", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Voet Behandeling", 30 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Hand Behandeling", 40 );
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Rug Behandeling", 60 );
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);
        }

        public static void FullCentrum()
        {
            Centrums = new List<Centrum>();

            Centrum centrum = new Centrum("Medische Kliniek Helmond");
            List<Specialist> specialists = new List<Specialist>();
            Specialist specialist = new Specialist(4598602478, "Manis", Categories[0]);
            specialists.Add(specialist);
            specialist = new Specialist(7412589630, "Alie ", Categories[0] );
            specialists.Add(specialist);
            specialist = new Specialist(1236549870, "Hary", Categories[0] );
            specialists.Add(specialist);
            specialist = new Specialist(1023564789, "Elena", Categories[0]);
            specialists.Add(specialist);

            centrum.AddSpesialistToCentrum( specialists);
            Centrums.Add(centrum);


            
            centrum = new Centrum("Kliniek Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4236578940, "Arina ", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(4879563201, "Mosh ", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(5636549870, "Mani", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(1073564789, "Elena", Categories[1] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Plastische chirurgie Utrecht");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578900, "Nima ", Categories[2] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Radiologie Pascalle");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Nora ", Categories[3] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Tamara ", Categories[3] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            

            
            centrum = new Centrum("Kliniek Helmond-Brouwhuis");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Sahar Nelson ", Categories[4] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Michael Brand ", Categories[4] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563401, "Marco Brand ", Categories[5] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

           
            centrum = new Centrum("Fysiotherapie Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Kim ", Categories[5] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Louisa de Jong", Categories[5] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Fysiotherapie Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4236578940, "Arina ", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(4879563201, "Mosh ", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(5636549870, "Mani", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(1073564789, "Elena", Categories[6] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);



        }

        public static void FullBehandelingMogelijkheden()
        {
           
            foreach (Centrum centrum in Centrums)
            {
                foreach(Specialist specialist in centrum.Specialists)
                {
                    BehandelingCalender behandelingCalender = 
                        new BehandelingCalender(
                            specialist,Werkdag.maandag,"09.00","13.00");
                    centrum.RegisterBehandelingCalenders(behandelingCalender);

                    behandelingCalender =
                        new BehandelingCalender(
                            specialist, Werkdag.dinsdag, "09.00", "16.00");
                    centrum.RegisterBehandelingCalenders(behandelingCalender);

                    behandelingCalender =
                        new BehandelingCalender(
                            specialist, Werkdag.woensdag, "09.00", "16.00");
                    centrum.RegisterBehandelingCalenders(behandelingCalender);

                    behandelingCalender =
                        new BehandelingCalender(
                            specialist, Werkdag.donderdag, "09.00", "16.00");
                    centrum.RegisterBehandelingCalenders(behandelingCalender);

                    behandelingCalender =
                        new BehandelingCalender(
                            specialist, Werkdag.vrijdag, "09.00", "14.00");
                    centrum.RegisterBehandelingCalenders(behandelingCalender);

                }
            }
        }
    }
}
