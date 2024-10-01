using MediatR;
using PersonCatalog.Application.Commands;
using PersonCatalog.Core.Entities;
using PersonCatalog.Core.Interfaces;

namespace PersonCatalog.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                Email = request.Email,
                Age = request.Age,
                Address = request.Address
            };

            await _personRepository.AddAsync(person);
            return person.Id;
        }
    }
}
