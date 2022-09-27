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
            Categories.Add(category);

            category = new Category("Neurochirurgie");
            Categories.Add(category);

            category = new Category("Plastische chirurgie");
            Categories.Add(category);

            category = new Category("Radiologie");
            Categories.Add(category);

            category = new Category("Transgenderzorg");
            Categories.Add(category);

            category = new Category("Gynaecologie");
            Categories.Add(category);

            category = new Category("Urologie");
            Categories.Add(category);

            category = new Category("Neurologie");
            Categories.Add(category);

        }

        
    }
}
