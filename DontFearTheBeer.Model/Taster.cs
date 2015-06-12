using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class Taster
    {
        #region variables

        private ICollection<Review> _reviews;

        #endregion


        #region constructors

        public Taster()
        {
            _reviews = new List<Review>();
        }

        #endregion


        #region properties

        public int Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        //encrpt this
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Review> Reviews 
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        #endregion
    }
}
