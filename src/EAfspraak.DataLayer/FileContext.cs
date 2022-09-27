using EAfspraak.DataLayer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer
{
    public static class FileContext
    {
        public static List<Category> Categories { get; set; }  
        

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
            category.Behandelings = Behandelings;
            Categories.Add(category);

            category = new Category("Neurochirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Cervicale kanaalstenose", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Cervicale foramenstenose", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Zenuwbeknelling", 40);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);

            category = new Category("Plastische chirurgie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Onderooglidcorrectie", 120);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Liposuctie", 120);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Bovenooglidcorrectie", 120);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);

            category = new Category("Radiologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("MRI", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echo", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Röntgenfoto", 40);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Echografie", 60);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);

           
            category = new Category("Urologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Sterilisatie", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Erectiestoornis", 30);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);

            category = new Category("Neurologie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Epilepsie", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Klapvoet", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Lumbaalpunctie", 40);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Nekhernia", 60);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);

            category = new Category("Fisyotherapie");
            Behandelings = new List<Behandeling>();
            behandeling = new Behandeling("Knee Behandeling", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Voet Behandeling", 30);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Hand Behandeling", 40);
            Behandelings.Add(behandeling);
            behandeling = new Behandeling("Rug Behandeling", 60);
            Behandelings.Add(behandeling);
            category.Behandelings = Behandelings;
            Categories.Add(category);
        }

        
    }
}
