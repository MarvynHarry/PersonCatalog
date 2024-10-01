using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCatalog.Application.Commands;
using PersonCatalog.Core.Entities;
using PersonCatalog.Core.Interfaces;

namespace PersonCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController(IMediator mediator, IPersonRepository personRepository) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPersonRepository _personRepository = personRepository;

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null) return NotFound();
            return person;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePersonCommand command)
        {
            var personId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = personId }, personId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdatePersonCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
