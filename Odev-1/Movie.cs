using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev_1
{
    public class Movie
    {
        public Movie()
        {
            Casts = new List<Cast>();
            Images = new List<string>();
            Categories = new List<Category>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Raiting { get; set; } 
        public string ImdbId { get; set; }
        public string Poster { get; set; }
        public List<Cast> Casts { get; set; }
        public List<string> Images { get; set; }
        public List<Category> Categories { get; set; }
        public override string ToString()
        {
            return this.Name;
        }


    }
}
