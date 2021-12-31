﻿
using Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query;
using Mc2.CrudTest.Service.Catalog;
using Mc2.CrudTest.Service.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Customer
{
    public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, CustomerListItemDTO>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerListItemDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            var model = await _customerService.GetCustomerByIdAsync(request.Id);


            return model;
        }
    }
}