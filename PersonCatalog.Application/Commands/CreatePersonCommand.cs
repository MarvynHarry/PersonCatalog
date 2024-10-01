using MediatR;

namespace PersonCatalog.Application.Commands
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public CreatePersonCommand(string name, string email, int age, string address)
        {
            Name = name;
            Email = email;
            Age = age;
            Address = address;
        }
    }
}
