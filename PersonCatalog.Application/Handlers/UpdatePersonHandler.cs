using MediatR;
using PersonCatalog.Application.Commands;
using PersonCatalog.Core.Entities;
using PersonCatalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCatalog.Application.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Age = request.Age,
                Address = request.Address
            };

            await _personRepository.UpdateAsync(person);
            return person;
        }
    }
}
