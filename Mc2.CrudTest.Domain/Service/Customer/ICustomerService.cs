using System.Collections.Generic;
using System.Threading.Tasks;
using Devsharp.Service.DTOs;

namespace Devsharp.Service.Catalog
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