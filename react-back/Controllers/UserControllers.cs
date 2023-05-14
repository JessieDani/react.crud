using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using react_back.Models;

namespace react_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetUsers()
        {
            // Implement the logic to get all users from the database
            return Ok(); // Replace this with your actual implementation
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<Customer> CreateUser([FromBody] Customer customer)
        {
            // Implement the logic to create a new user in the database
            return Ok(); // Replace this with your actual implementation
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Customer customer)
        {
            // Implement the logic to update a user in the database
            return Ok(); // Replace this with your actual implementation
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Implement the logic to delete a user from the database
            return Ok(); // Replace this with your actual implementation
        }
    }
}
