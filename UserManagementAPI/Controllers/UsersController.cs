using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Static list of users used as a base.
        private static List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "254822555", Department = "HR" },
            new User { Id = 2, FirstName = "Panagiotis", LastName = "Stav", Email = "panstavgr@gmail.com", PhoneNumber = "254822555", Department = "IT" },
        };

        // GET endpoint to retrieve a list of all users.
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Copilot suggested adding error handling to manage exceptions.
                return StatusCode(500, new { Message = "An error occurred while retrieving users", Details = ex.Message });
            }
        }

        // GET endpoint to retrieve a specific user by ID.
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Copilot suggested adding error handling for non-existent users.
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }

        // Copilot generated the POST endpoint to add a new user.
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] User user)
        {
            try
            {
                // Validation for user input fields.
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                user.Id = users.Max(u => u.Id) + 1;
                users.Add(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                // Error handling to manage exceptions
                return StatusCode(500, new { Message = "An error occurred while adding the user", Details = ex.Message });
            }
        }

        // Copilot generated the PUT endpoint to update an existing user's details.
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                // Validadion for user input
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    //  Error handling for non-existent users
                    return NotFound(new { Message = "User not found" });
                }
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.PhoneNumber = updatedUser.PhoneNumber;
                user.Department = updatedUser.Department;
                return NoContent();
            }
            catch (Exception ex)
            {
                // Error handling to manage exceptions
                return StatusCode(500, new { Message = "An error occurred while updating the user", Details = ex.Message });
            }
        }

        //  DELETE Endpoint to remove a user by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Error handling for non-existent users
                return NotFound(new { Message = "User not found" });
            }
            users.Remove(user);
            return NoContent();
        }
    }
}