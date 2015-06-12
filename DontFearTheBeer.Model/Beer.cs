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
        #region variables

        private ICollection<BeerImage> _images;
        private ICollection<Review> _reviews;

        #endregion


        #region constructors

        public Beer()
        {
            _images = new List<BeerImage>();
            _reviews = new List<Review>();
        }

        #endregion


        #region properties

        public int Id { get; set; }

        public int BreweryId { get; set; }
        
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        
        // make this an enum
        public string Category { get; set; }
        
        public decimal ABV { get; set; }
        
        public int IBU { get; set; }
        
        public string Description { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<BeerImage> Images
        { 
            get { return _images; }
            set { _images = value; }
        }

        public virtual ICollection<Review> Reviews 
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        #endregion

    }
}
