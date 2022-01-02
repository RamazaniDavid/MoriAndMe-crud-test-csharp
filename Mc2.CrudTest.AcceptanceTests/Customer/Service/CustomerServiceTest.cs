using Mc2.CrudTest.Data;
using Mc2.CrudTest.Service.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Customer.Service
{
    [TestClass()]
    public class CategoryServiceTests
    {
        private CustomerService _customerService;
        private Mock<IRepository<Mc2.CrudTest.Core.Domian.Customer>> _customerRepositoryMock;

        [TestInitialize()]
        public void Init()
        {
            _customerRepositoryMock = new Mock<IRepository<Mc2.CrudTest.Core.Domian.Customer>>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);

            _customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(() =>
            {
                return Task.FromResult(GetMockCustomerList().FirstOrDefault(p => p.ID == -1));
            });

        }

        [TestMethod()]
        public void RegisterCustomer_NullArgument_ThrowException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _customerService.RegisterCustomerAsync(null),"customer");
        }
        [TestMethod()]
        public void UpdateCustomer_NullArgument_ThrowException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _customerService.UpdateCustomerAsync(null), "customer");
        }


        [TestMethod()]
        public  void GetCustomerById_ShouldReturnNull()
        {
            var result =  _customerService.GetCustomerByIdAsync(-1).Result;
            Assert.IsTrue(result == null);
        }
        [TestMethod()]
        public async Task InsertCustomer_ValidArgumentst()
        {
            await _customerService.RegisterCustomerAsync(new Common.DTOs.CustomerDTO());
            _customerRepositoryMock.Verify(c=>c.InsertAsync(It.IsAny<Core.Domian.Customer>()), Times.Once());
           
        }
        private IList<Core.Domian.Customer> GetMockCustomerList()
        {
            return new List<Core.Domian.Customer>()
            {
                new Core.Domian.Customer{ID=1,BankAccountNumber="101-230100-2210",FirstName="morteza",LastName="ghasemi",Email="mortezaghasemi12@gmail.com",CountryCode="1010",PhoneNumber="101320100",DateOfBirth=DateTime.Now},
                new Core.Domian.Customer{ID=2,BankAccountNumber="101-230100-2211",FirstName="ali",LastName="karimi",Email="alikarimi6500@gmail.com",CountryCode="1010",PhoneNumber="101320130",DateOfBirth=DateTime.Now},
                new Core.Domian.Customer{ID=3,BankAccountNumber="101-230100-2212",FirstName="reza",LastName="ghaderi",Email="rezaghaderi400@gmail.com",CountryCode="1010",PhoneNumber="101320120",DateOfBirth=DateTime.Now},
                new Core.Domian.Customer{ID=4,BankAccountNumber="101-230100-2213",FirstName="morid",LastName="haghkhah",Email="moridhaghkhah20@gmail.com",CountryCode="1010",PhoneNumber="101320133",DateOfBirth=DateTime.Now},
                new Core.Domian.Customer{ID=5,BankAccountNumber="101-230100-2214",FirstName="david",LastName="ramezani",Email="davidramezani9800@gmail.com",CountryCode="1010",PhoneNumber="101320198",DateOfBirth=DateTime.Now},
            };
        }
    }
}
