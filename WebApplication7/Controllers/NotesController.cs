using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        UsersContext db = new();

        [HttpGet("get_notes")]
        public async Task<ActionResult<Note>> Get_Notes(Note request)
        {
            var notes = db.notes.Where(x => x.user_id == request.user_id).ToList();
            if (notes.Any())
            {
                return Ok(notes);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("add_note")]
        public async Task<ActionResult<Note>> Add_Note(Note request)
        {
            Note new_note = new Note() { note = request.note, notification_time = request.notification_time.ToUniversalTime(), user_id = request.user_id};
            try
            {
                db.notes.Add(new_note);
                db.SaveChanges();
                return Ok(new_note);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
