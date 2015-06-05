using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class BeerImage
    {
        public int Id { get; set; }

        public int BeerId { get; set; }
    
        public Beer Beer { get; set; }

        public string Tag { get; set; }

        public string Notes { get; set; }
        
        public string ImageLocation{get;set;}
    
    }
}
