using EAfspraak.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.IO;

namespace EAfspraak.Infrastructure
{
    public class CategoryRepotisory
    {
        
        public Category[] GetCategories()
        {
            Category[] categories;
             categories = JsonSerializer.Deserialize<Category[]>(File.ReadAllText(@"Data/Category.json"));

            return categories;
            

        }
    }
}
