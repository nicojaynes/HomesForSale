using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibraryCS
{
    /// <summary>
    /// Warehouse class which, in addition to the fields inherited, contains a land size field
    /// </summary>
    [Serializable]
    public class Warehouse : CommercialObject
    {
        private int landSizeInSquareMeters;

        public int LandSizeInSquareMeters
        {
            get
            {
                return landSizeInSquareMeters;
            }
            set
            {
                if(value > 0)
                {
                    landSizeInSquareMeters = value;
                }
            }
        }
    }
}
