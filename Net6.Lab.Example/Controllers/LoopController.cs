using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6.Lab.Example.Models;

namespace Net6.Lab.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopController : ControllerBase
    {
        public IActionResult Test()
        {
            var test = new Test();

            foreach (var item in test.List)
            {
                foreach (var item2 in item.List)
                {
                    foreach(var item3 in item2.List)
                    {

                    }
                }
            }

            return Ok();

        }
    }
}
