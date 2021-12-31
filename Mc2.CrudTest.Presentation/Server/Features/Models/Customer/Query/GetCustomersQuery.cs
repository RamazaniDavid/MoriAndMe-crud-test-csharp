
using Mc2.CrudTest.Service.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Mc2.CrudTest.Presentation.Server.Features.Models.Customer.Query
{
    public class GetCustomersQuery: IRequest<IEnumerable<CustomerListItemDTO>>
    {
        
    }
}
