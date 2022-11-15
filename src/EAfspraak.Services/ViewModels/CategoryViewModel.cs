using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.ViewModels
{
    public  class CategoryViewModel
    {

        private string name;
        public string Name { get { return this.name; } }

        private List<BehandelingViewModel> behandelingen;
        public List<BehandelingViewModel> Behandelingen { get { return this.behandelingen; } }
        public CategoryViewModel(string name, List<BehandelingViewModel> behandelingen )
        {
            this.name = name;
            this.behandelingen = behandelingen;
           

            
        }


    }
}
