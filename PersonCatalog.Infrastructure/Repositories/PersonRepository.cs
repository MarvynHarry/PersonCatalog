using PersonCatalog.Core.Entities;
using PersonCatalog.Core.Interfaces;
using PersonCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace PersonCatalog.Infrastructure.Repositories
{
    public class PersonRepository(ApplicationDbContext context) : IPersonRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            var personU = await _context.Persons.FirstOrDefaultAsync(p => p.Id == person.Id) ?? throw new KeyNotFoundException($"Person with Id {person.Id} was not found.");

            personU.Name = person.Name;
            personU.Email = person.Email;
            personU.Address = person.Address;

            var emailExists = await _context.Persons
          .AnyAsync(p => p.Email == person.Email && p.Id != person.Id);

            if (emailExists)
                throw new DbUpdateException($"The email '{person.Email}' is already taken by another person.");


            _context.Persons.Update(personU);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
