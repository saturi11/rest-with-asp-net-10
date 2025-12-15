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
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPerasonService perasonService, ILogger<PersonController> logger)
        {
            _perasonService = perasonService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            return Ok(_perasonService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting persons with ID {id}", id);
            var person = _perasonService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID {id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("creating new person: {FirstName}", person.FirstName);
            if (person == null)
            {
                _logger.LogWarning("Received null person object in POST request");
                return BadRequest();
            }
            return Ok(_perasonService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("updating person with ID {Id}", person.Id);
            if (person == null)
            {
                _logger.LogWarning("Received null person object in PUT request");
                return BadRequest();
            }
            var updatedPerson = _perasonService.Update(person);
            if (updatedPerson == null)
            {
                _logger.LogWarning("Person with ID {Id} not found for update", person.Id);
                return NotFound();
            }
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("deleting person with ID {id}", id);
            _perasonService.Delete(id);
            return NoContent();
        }

    }

}
