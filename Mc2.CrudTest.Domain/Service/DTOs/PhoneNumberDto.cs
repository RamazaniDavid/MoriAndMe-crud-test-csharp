using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Service.DTOs
{
   

    public class PhoneNumberDTO:BaseEntityDTO
    {

        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }

    }
}
