﻿
using Mc2.CrudTest.Service.DTOs;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query
{
    public class GetCustomerByIdQuery: IRequest<CustomerListItemDTO>
    {
        public int Id { get; set; }
    }
}
