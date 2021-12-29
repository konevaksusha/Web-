using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Ls.Models;
using System.Threading.Tasks;

namespace Ls.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        BoxesContext db;
        public BoxesController(BoxesContext context)
        {
            db = context;
            if (!db.Boxes.Any())
            {
                db.Boxes.Add(new Box { Name = "Гарри Поттер", Price = 2600 });
                db.Boxes.Add(new Box { Name = "Властелин колец", Price = 31000 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Box>>> Get()
        {
            return await db.Boxes.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> Get(int id)
        {
            Box box = await db.Boxes.FirstOrDefaultAsync(x => x.Id == id);
            if (box == null)
                return NotFound();
            return new ObjectResult(box);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Box>> Post(Box box)
        {
            if (box == null)
            {
                return BadRequest();
            }

            db.Boxes.Add(box);
            await db.SaveChangesAsync();
            return Ok(box);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Box>> Put(Box box)
        {
            if (box == null)
            {
                return BadRequest();
            }
            if (!db.Boxes.Any(x => x.Id == box.Id))
            {
                return NotFound();
            }

            db.Update(box);
            await db.SaveChangesAsync();
            return Ok(box);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Box>> Delete(int id)
        {
            Box box = db.Boxes.FirstOrDefault(x => x.Id == id);
            if (box == null)
            {
                return NotFound();
            }
            db.Boxes.Remove(box);
            await db.SaveChangesAsync();
            return Ok(box);
        }
    }
}