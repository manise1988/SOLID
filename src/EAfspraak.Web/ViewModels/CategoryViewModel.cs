using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public  class CategoryViewModel
    {

        public string Name { get; }
        public List<BehandelingViewModel> Behandelingen { get; }
        public CategoryViewModel(string name, List<BehandelingViewModel> behandelingen )
        {
            Name = name;
            Behandelingen = behandelingen;
           

            
        }


    }
}
