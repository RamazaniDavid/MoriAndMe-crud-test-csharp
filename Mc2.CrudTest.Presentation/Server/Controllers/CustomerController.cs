using System.Threading.Tasks;
using Mc2.CrudTest.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mc2.CrudTest.Core.Caching;
using Mc2.CrudTest.Framework.Infrastructure.Filters;
using Mc2.CrudTest.Framwork.Infrastructure.Filters;
using Mc2.CrudTest.Service.Catalog;
using Mc2.CrudTest.Service.DTOs;

namespace ShopWeb.Controllers
{

    public class CustomerController : Mc2CrudTestController
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
      
       
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _customerService.getCustomersAsync());
        }
      
        [HttpGet("find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Find(int id)
        {

         
            var customerDTO =await _customerService.SearchCustomerByIdAsync(id);
            if (customerDTO == null)
            {
                return NotFound();
            }
            return Ok(customerDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RegisterAsync([FromForm]CustomerRegisterDTO customerRegisterDTO)
        {
            if (customerRegisterDTO.ID != 0)
                return BadRequest();

            await _customerService.RegisterCustomerAsync(customerRegisterDTO);

            return CreatedAtAction("find", new { id = customerRegisterDTO.ID }, customerRegisterDTO);

        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromForm]CustomerRegisterDTO customerRegisterDTO)
        {
            if (!await _customerService.IsExistsCustomerAsync(customerRegisterDTO.ID))
            {
                return NotFound();
            }
            await _customerService.UpdateCustomerAsync(customerRegisterDTO);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveAsync(int id)
        {
          
            if (!await _customerService.IsExistsCustomerAsync(id))
            {
                return NotFound();
            }

            await _customerService.RemoveCustomerAsync(id);

            return Ok();
        }
    }
}