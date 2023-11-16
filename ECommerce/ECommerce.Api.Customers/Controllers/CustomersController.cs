 using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    /*
     * Course:      Web Programming 3
     * Assessment:  Milestone 3
     * Created by:  Jose David Torres
     * Date:        16/11/2023
     * Class Name:  CustomersController.cs
     * Description: Controller that handles the retrieval of the Customer data in the in-memory database.
     */

    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if(result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if(result.IsSuccess) 
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
