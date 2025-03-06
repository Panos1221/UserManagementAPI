# UserManagementAPI

UserManagementAPI is a simple and functional API built with ASP.NET Core, enabling CRUD operations (Create, Read, Update, Delete) for managing user records. This API comes with robust middleware implementations for logging, error handling, and authentication. This was made as a capstone project for the course:  [Back-End Development with .NET](https://www.coursera.org/learn/back-end-development-with-dotnet).

## Features

- Retrieve a list of all users or a specific user by his ID.
- Add a new user.
- Update an existing user's details using his ID.
- Remove a specific user by ID.
- Validation of user inputs.
- Middleware Logging, Error Handling and Authentication. 


## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- A development environment like Visual Studio or VS Code
  

## API Endpoints
1. GET /api/users
  -> Retrieve a list of users.

2. GET /api/users/{id}
  -> Retrieve a specific user by ID.

3. POST /api/users
  -> Add a new user (Information on the Request Body below).

4. PUT /api/users/{id}
  -> Update an existing user's details.

5. DELETE /api/users/{id}
  -> Delete a user by his ID.

Request Body
```bash
    {
        "FirstName": "Jack",
        "LastName": "Daniels",
        "Email": "jackdaniels@gmail.com",
        "PhoneNumber": "2972827827",
        "Department": "IT"
    }
```

## Authentication
In order to be able to use the API Endpoints you need to authenticate yourself. You can do so by putting a Header called Authentication with a value of "validTokenYay" without the quotes.


