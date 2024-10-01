# Person Management System

This project is a person management system built with **.NET** and **Entity Framework Core**, utilizing **MediatR** for a CQRS pattern. It allows creating, updating, deleting, and listing persons while ensuring data integrity (e.g., unique email validation). The architecture is clean, scalable, and designed for easy maintenance and extension.

## Features

- **CRUD Operations**: Create, read, update, and delete person records.
- **Unique Email Validation**: Ensures no duplicate email entries in the database.
- **CQRS with MediatR**: Separation of commands and queries for clean and modular code.
- **EF Core Integration**: Seamless interaction with a MySQL database using **Entity Framework Core**.
- **API-First Design**: Built to expose RESTful endpoints for person management.

## Technologies Used

- **.NET 8.0**: Latest framework version for building the API.
- **Entity Framework Core**: ORM for database access and migration.
- **MediatR**: Implements CQRS pattern to handle commands and queries.
- **MySQL**: Relational database for data persistence.
- **Docker**: Containerization for easy setup and deployment.

## Getting Started

### Prerequisites

- **.NET SDK 8.0**: [Download Here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Docker**: [Download Here](https://www.docker.com/products/docker-desktop)

### Running the Project

1. **Clone the Repository**
    ```bash
    git clone https://github.com/MarvynHarry/PersonCatalog.git
    ```

2. **Navigate to the Project Directory**
    ```bash
    cd PersonCatalog
    ```

3. **Build and Run the Containers**
    Make sure Docker is running, then execute:
    ```bash
    docker compose up --build
    ```

4. **Access the API**
   The API will be running on [http://localhost:5000](http://localhost:5000).


## Usage

You can interact with the API via tools like **Postman** or directly through a browser. The following endpoints are available:

- `GET /api/persons` - List all persons.
- `POST /api/persons` - Create a new person.
- `PUT /api/persons/{id}` - Update an existing person.
- `DELETE /api/persons/{id}` - Delete a person.

## Project Structure

- **PersonCatalog.API**: The main API project exposing RESTful endpoints.
- **PersonCatalog.Application**: Contains application logic, including commands and queries for MediatR.
- **PersonCatalog.Infrastructure**: Data access layer using **Entity Framework Core**.
- **PersonCatalog.Core**: Core entities and business logic.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or feedback, please contact [marvynharry@gmail.com](mailto:marvynharry@gmail.com).
