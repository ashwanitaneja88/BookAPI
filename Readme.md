# BookApi

A .NET 8 REST API for managing a collection of books, implemented using ASP.NET Core Web API with controllers. The API supports basic CRUD operations and follows RESTful principles.

## Features

The BookApi provides a simple and efficient way to manage a collection of books through RESTful web services. Below are the core features of the API:


- **GET /api/books**: Returns all books.
- **GET /api/books/{id}**: Returns a book by ID.
- **POST /api/books**: Adds a new book.
- **PUT /api/books/{id}**: Updates an existing book.
- **DELETE /api/books/{id}**: Deletes a book.

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Dependency Injection
- Logging
- Unit Testing with xUnit and Moq

## Project Structure

```
BookApi/
├── BookApi.sln
├── BookApi/
│   ├── Controllers/
│   │   └── BooksController.cs
│   ├── Models/
│   │   └── Book.cs
│   ├── Services/
│   │   ├── IBookService.cs
│   │   └── BookService.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── appsettings.Development.json
├── BookApi.Tests/
│   ├── BooksControllerTests.cs
│   ├── BookApi.Tests.csproj
```

## Getting Started

This section will guide you through setting up and running the BookApi project. By following these steps, you will have a fully functional API that can handle book-related operations such as retrieval, addition, modification, and deletion.

### Prerequisites

Before you begin, ensure you have the following installed:

- .NET 8 SDK
- Visual Studio 2022

### Installation

Follow these steps to set up and run the project:

1. **Open the project in Visual Studio 2022:**

   - Open Visual Studio 2022.
   - Select **File > Open > Project/Solution**.
   - Navigate to the project folder and select the `.csproj` file.

2. **Build the project:**

   - In the Solution Explorer, right-click on the project and select **Build**.

3. **Run the project:**

   - In the Solution Explorer, right-click on the project and select **Set as Startup Project**.
   - Click the **Start** button (or press `F5`) to run the project.

### Testing

Run the unit tests using Visual Studio 2022:

- In the Test Explorer, click **Run All** to execute all unit tests.

## API Endpoints

### GET /api/books

Returns all books.

**Response:**

```json
[
    {
        "id": 1,
        "title": "1984",
        "author": "George Orwell",
        "year": 1949
    },
    {
        "id": 2,
        "title": "To Kill a Mockingbird",
        "author": "Harper Lee",
        "year": 1960
    }
]
```

### GET /api/books/{id}

Returns a book by ID.

**Response:**

```json
{
    "id": 1,
    "title": "1984",
    "author": "George Orwell",
    "year": 1949
}
```

### POST /api/books

Adds a new book.

**Request:**

```json
{
    "title": "Brave New World",
    "author": "Aldous Huxley",
    "year": 1932
}
```

**Response:**

```json
{
    "id": 3,
    "title": "Brave New World",
    "author": "Aldous Huxley",
    "year": 1932
}
```

### PUT /api/books/{id}

Updates an existing book. The full book object must be provided in the request. Partial updates are not supported.

**Request:**

```json
{
    "title": "Brave New World",
    "author": "Aldous Huxley",
    "year": 1932
}
```

**Response:**

```http
204 No Content
```

### DELETE /api/books/{id}

Deletes a book. If the book does not exist, the API returns a 404 Not Found error.

**Response:**

```http
204 No Content
```



Function | API | Type | Url
------------ | ------------ | ------------- | ------------
Get all the book records | api/books | GET |https://localhost:44394/api/books
Save the new book record |api/books | POST |https://localhost:44394/api/books
Get book record by id | api/books/id | GET |https://localhost:44394/api/books/1
Update book record | api/books/id | PUT |https://localhost:44394/api/books/1
delete book record | api/books/id | DELETE |https://localhost:44394/api/books/1

