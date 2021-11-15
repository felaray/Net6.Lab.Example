using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6.Lab.Example.Data;
using Net6.Lab.Example.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Net6.Lab.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly Net6LabExampleContext _context;

        public TodoController(Net6LabExampleContext context)
        {
            _context = context;
        }


        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _context.Todo.OrderBy(c => c.Id).ToListAsync();
            return Ok(result);
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Todo
                .TemporalAll()
                .Where(c => c.Id == id)
                .ToListAsync();
  
            return Ok(result);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string title)
        {
            await _context.Todo.AddAsync(new Todo { Title = title });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromQuery] int id, string title)
        {
            var result = await _context.Todo.SingleOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                result.Title = title;
                result.CreatedDate = DateTime.Now;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }


        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Todo.SingleOrDefaultAsync(c => c.Id == id);
            if (result != null)
                _context.Todo.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
