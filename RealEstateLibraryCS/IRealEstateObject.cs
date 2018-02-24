using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibraryCS
{
    /// <summary>
    /// Interface of a real estate object with methods to reach it's fields
    /// </summary>
    interface IRealEstateObject
    {
        Address Address{ get; set; }
        int Price { get; set;}
        string NumberOfRooms { get; set; }
        void SetLegalForm(LegalForm value);
        LegalForm GetLegalForm();
        string TypeOfEstate { get; set; }
        String ToString();
    }
}
