using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.Service.DTOs;

namespace Mc2.CrudTest.Service.Catalog
{
    public interface ICustomerService
    {
    
        Task<CustomerRegisterDTO> RegisterCustomerAsync(CustomerRegisterDTO categoryDTO);
        Task RemoveCustomerAsync(int id);
        Task<IEnumerable<CustomerListItemDTO>> getCustomersAsync();
        
        Task<CustomerListItemDTO> SearchCustomerByIdAsync(int id);
        Task UpdateCustomerAsync(CustomerRegisterDTO categoryDTO);
        Task<bool> IsExistsCustomerAsync(int id);
    }
}