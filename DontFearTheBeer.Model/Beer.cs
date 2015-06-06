using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class Beer
    {
        public int Id { get; set; }

        public int BreweryId { get; set; }
        
        public Brewery Brewery { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        
        // make this an enum
        public string Category { get; set; }
        
        public decimal ABV { get; set; }
        
        public int IBU { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<BeerImage> Images { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
