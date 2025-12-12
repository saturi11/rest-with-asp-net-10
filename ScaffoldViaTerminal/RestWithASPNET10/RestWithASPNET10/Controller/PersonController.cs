using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Service;

namespace RestWithASPNET10.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPerasonService _perasonService;
        public PersonController(IPerasonService perasonService)
        {
            _perasonService = perasonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_perasonService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _perasonService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_perasonService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            var updatedPerson = _perasonService.Update(person);
            if (updatedPerson == null)
            {
                return NotFound();
            }
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _perasonService.Delete(id);
            return NoContent();
        }

    }

}
