
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Mc2.CrudTest.Service.Catalog;
using Mc2.CrudTest.Service.DTOs;
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;

namespace Mc2.CrudTest.Presentation.Server.Customer
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerListItemDTO>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IEnumerable<CustomerListItemDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {

            var customers = await _customerService.getCustomersAsync();
            return customers;
        }
    }
}
