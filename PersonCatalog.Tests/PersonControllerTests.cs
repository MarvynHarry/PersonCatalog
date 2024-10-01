using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonCatalog.API.Controllers;
using PersonCatalog.Application.Commands;
using PersonCatalog.Core.Entities;
using PersonCatalog.Core.Interfaces;

namespace PersonCatalog.Tests
{
    public class PersonControllerTests
    {
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PersonController _controller;

        public PersonControllerTests()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _mediatorMock = new Mock<IMediator>();
            _controller = new PersonController(_mediatorMock.Object, _personRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllPersons()
        {
            // Arrange
            var persons = new List<Person>
            {
                new() { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30, Address = "123 Street" },
                new() { Id = 2, Name = "Jane Doe", Email = "jane@example.com", Age = 25, Address = "456 Avenue" }
            };
            _personRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(persons);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.Equal(persons, result);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var command = new CreatePersonCommand("John Doe", "john@example.com", 30, "123 Street");
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(1);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(1, actionResult.Value);
        }
    }
}
