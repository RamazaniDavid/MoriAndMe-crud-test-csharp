﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Service.DTOs
{
   

    public class CustomerRegisterDTO:BaseEntityDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual short CountryCode { get; set; }
        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

    }
}
