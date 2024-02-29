using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Make sure to import ILogger
using System;
using System.Collections.Generic; // Add this using statement for List<string>
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly ILogger<UserDataController> _logger;

        public UserDataController(ILogger<UserDataController> logger)
        {
            _logger = logger;
        }
         
        [HttpPost]
        [Route("UserOrder")]
        public IActionResult UserOrder([FromBody] List<SelectedService> orderRequest)
        {
            try
            {
                // Your order processing logic here
                // You can access orderRequest.selectedServices and orderRequest.totalPrice

                // Assuming the order was successful
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                // Handle any errors during order processing
                return BadRequest(new { success = false, error = ex.Message });
            }
        }

    }
   
    public class SelectedService
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    
}
