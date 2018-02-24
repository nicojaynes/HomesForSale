using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibraryCS
{
    /// <summary>
    /// Class which contains an address
    /// </summary>
    
    [Serializable]
    public class Address
    {
        private string country;
        private string city;
        private string zipCode;
        private string street;

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    country = value;
                }
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    city = value;
                }
            }
        }
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    zipCode = value;
                }
            }
        }
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    street = value;
                }
            }
        }

    }
}
