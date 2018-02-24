using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibraryCS
{
    /// <summary>
    /// Apartment class which, in addition to the fields inherited, contains a floor field
    /// </summary>
    [Serializable]
    public class Apartment : PrivateObject
    {
        private string floor;

        public string Floor
        {
            get
            {
                return floor;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    floor = value;
                }
            }
        }
    }
}
