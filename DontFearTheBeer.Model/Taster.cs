using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class Taster
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        //encrpt this
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
