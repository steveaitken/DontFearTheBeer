using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class Brewery
    {
        #region variables

        private ICollection<Beer> _beers;

        #endregion


        #region constructors

        public Brewery()
        {
            _beers = new List<Beer>();
        }

        #endregion


        #region properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Country Country { get; set; }

        public ProvinceState ProvinceState { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        #endregion
    }
}
