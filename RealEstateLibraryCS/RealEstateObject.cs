using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibraryCS
{
    /// <summary>
    /// Abstract Real Estate Object class
    /// </summary>
    [Serializable]
    public class RealEstateObject : IRealEstateObject
    {
        private int id;
        private LegalForm legalForm;
        private string typeOfEstate;
        private Address address;
        private int price;
        private string numberOfRooms;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Address Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public int Price { get => price; set => price = value; }
        public string NumberOfRooms
        {
            get
            {
                return numberOfRooms;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    numberOfRooms = value;
                }
            }
        }
        public void SetLegalForm(LegalForm value)
        {
            legalForm = value;
        }
        public LegalForm GetLegalForm()
        {
            return legalForm;
        }
        public string TypeOfEstate
        {
            get
            {
                return typeOfEstate;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    typeOfEstate = value;
                }
            }
        }
   
        public override String ToString()
        {
            return  "\nLegal Form: " + GetLegalForm() +
                    "\nCountry: " + this.Address.Country +
                    "\nStreet: " + this.Address.Street +
                    "\nType of estate: " + this.typeOfEstate +
                    "\nPrice: " + this.Price +
                    "\nNumber of Rooms: " + this.NumberOfRooms +
                    "\nCity: " + this.Address.City +
                    "\nZip Code: " + this.Address.ZipCode;      
        }
    }
}
