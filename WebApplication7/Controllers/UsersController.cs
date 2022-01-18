using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersContext db = new();

        [HttpPut("add_user")]
        public async Task<ActionResult<Note>> Add_User(User request)
        {
            User user1 = new User (){ name = request.name, google_id = request.google_id };
            db.users.Add(user1);
            try
            {
                db.SaveChanges();
                return Ok(user1);
            }
            catch
            {
                return BadRequest();
            }
}

        [HttpGet("get_all_users")]
        public async Task<ActionResult<Note>> All_Users(User request)
        {
            var users = db.users.OrderBy(x => x.id);
            return Ok(users);
        }

        [HttpGet("get_user")]
        public async Task<ActionResult<Note>> Get_User(User request)
        {
            var users = db.users.Where(x => x.id == request.id).ToList();
            if (users.Any())
            {
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
