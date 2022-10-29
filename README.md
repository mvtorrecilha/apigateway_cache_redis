# API Gateway - Redis Cache (Backend)

A small simple api gateway with cache redis .net core

![](img/apigateway_redis_architecture.png)
## Technologies:

- ASP.NET Core 6.0
- Gateway pattern
- Swagger

## Features available for access:
- Books:
    - Get All Books
        - Url: https://localhost:4001/api/v1/books
        - Url from gateway: https://localhost:5101/book-api/v1/books

- Students:
    - Get All Students
        - Url: https://localhost:3001/api/v1/students
        - Url from gateway: https://localhost:5101/student-api/v1/students

Note: You can download the postman file configuration to import. The file is located in the Postman files folder
