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
        public static List<Category> Categories { get; set; }
        public static List<Centrum> Centrums { get; set; }
        public static List<Patiënt> patiënts { get; set; }
        

        public static void FullCategory()
        {
            Categories = new List<Category>();
            
            Category category = new Category("Orthopedie");
            List<Behandeling> Behandelings = new List<Behandeling>();
            Behandeling behandeling = new Behandeling("Nek Behandeling", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Elleboog behandelingen", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Heup behandelingen", "00.40");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Knee behandelingen", "01.00");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Voet behandelingen", "01.30");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Neurochirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Cervicale kanaalstenose", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Cervicale foramenstenose", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Zenuwbeknelling", "00.40");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Plastische chirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Onderooglidcorrectie", "02.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Liposuctie", "02.00");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Bovenooglidcorrectie", "02.00");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Radiologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("MRI", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echo", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Röntgenfoto", "00.40");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echografie", "01.00");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

           
            category = new Category("Urologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Sterilisatie", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Erectiestoornis", "00.30");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Neurologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Epilepsie", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Klapvoet", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Lumbaalpunctie", "00.40");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Nekhernia", "01.30");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);

            category = new Category("Fisyotherapie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Knee Behandeling", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Voet Behandeling", "00.30");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Hand Behandeling", "00.40");
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Rug Behandeling", "01.00");
            Behandelings.Add(behandeling);
            category.Behandelingen = Behandelings;
            Categories.Add(category);
        }

        public static void FullCentrum()
        {
            Centrums = new List<Centrum>();

            Centrum centrum = new Centrum("Medische Kliniek Helmond");
            List<Specialist> specialists = new List<Specialist>();
            Specialist specialist = new Specialist(4598602478, "Manis","", Categories[0]);
            specialists.Add(specialist);
            specialist = new Specialist(7412589630, "Alie ", "", Categories[0] );
            specialists.Add(specialist);
            specialist = new Specialist(1236549870, "Hary", "", Categories[0] );
            specialists.Add(specialist);
            specialist = new Specialist(1023564789, "Elena", "", Categories[0]);
            specialists.Add(specialist);

            centrum.AddSpesialistToCentrum( specialists);
            Centrums.Add(centrum);


            
            centrum = new Centrum("Kliniek Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4236578940, "Arina ", "", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(4879563201, "Mosh ", "", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(5636549870, "Mani", "", Categories[1] );
            specialists.Add(specialist);
            specialist = new Specialist(1073564789, "Elena", "", Categories[1] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Plastische chirurgie Utrecht");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578900, "Nima ", "", Categories[2] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Radiologie Pascalle");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Nora ", "", Categories[3] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Tamara ", "", Categories[3] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            

            
            centrum = new Centrum("Kliniek Helmond-Brouwhuis");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Sahar Nelson ", "", Categories[4] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Michael Brand ", "", Categories[4] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563401, "Marco Brand ", "", Categories[5] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

           
            centrum = new Centrum("Fysiotherapie Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4436578940, "Kim ", "", Categories[5] );
            specialists.Add(specialist);
            specialist = new Specialist(4889563201, "Louisa de Jong", "", Categories[5] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            
            centrum = new Centrum("Fysiotherapie Deltaweg");
            specialists = new List<Specialist>();
            specialist = new Specialist(4236578940, "Arina ", "", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(4879563201, "Mosh ", "", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(5636549870, "Mani", "", Categories[6] );
            specialists.Add(specialist);
            specialist = new Specialist(1073564789, "Elena", "", Categories[6] );
            specialists.Add(specialist);
            centrum.AddSpesialistToCentrum(specialists);
            Centrums.Add(centrum);

            FullBehandelingToCentrum();

        }

        private static void FullBehandelingToCentrum()
        {
            foreach (Behandeling item in Categories[0].Behandelingen)
            {
                Centrums[0].AddBehandelingToCentrum(item);
            }
            
        }

        public static void FullBehandelingMogelijkheden()
        {
           
            foreach (Centrum centrum in Centrums)
            {
                foreach(Specialist specialist in centrum.Specialists)
                {
                    BehandelingAgenda behandelingCalender = 
                        new BehandelingAgenda(
                            specialist,Werkdag.Monday,"09.00","13.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Tuesday, "09.00", "16.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Wednesday, "09.00", "16.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Thursday, "09.00", "16.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Friday, "09.00", "14.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Saturday, "09.00", "12.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);

                    behandelingCalender =
                        new BehandelingAgenda(
                            specialist, Werkdag.Saturday, "13.00", "18.00");
                    centrum.RegisterBehandelingAgenda(behandelingCalender);
                }
            }


           // List<string> test = Centrums[0].CalculateWachtLijst(7412589630, "Nek Behandeling", DateTime.Now);
        }
    }
}
