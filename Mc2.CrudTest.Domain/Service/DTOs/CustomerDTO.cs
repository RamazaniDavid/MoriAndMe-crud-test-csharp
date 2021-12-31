using Mc2.CrudTest.Service.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mc2.CrudTest.Service.DTOs
{


    public class CustomerDTO : BaseEntityDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string CountryCode { get; set; }
        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

        [MobileNumberValidation]
        [NotMapped]
        public PhoneNumberDTO PhoneNumberDto
        {
            get
            {
                return new PhoneNumberDTO
                {
                    CountryCode = CountryCode,
                    PhoneNumber = PhoneNumber,
                };
            }
        }

    }
}
