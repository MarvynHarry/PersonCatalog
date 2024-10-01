using MediatR;
using PersonCatalog.Core.Entities;

namespace PersonCatalog.Application.Commands
{
    public class UpdatePersonCommand : IRequest<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public UpdatePersonCommand(int id, string name, string email, int age, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            Address = address;
        }
    }
}
