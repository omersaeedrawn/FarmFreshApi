# FarmFreshApi
This is a FarmFresh Project to demonstrate few core structures and patterns implementations.

## Description
Welcome, This is where you will find a project with implementations of N-tier architecture, Entity Framework (Code First) with Generic Repository pattern, Authentication, Server-side-Pagination, swagger documentation and api endpoints testable by Posyman.

## Instructions
- Clone this Repository.
- Add your connection string in appsetting.json
- Run migrations.
- Update Database.
- Run the Project to see all the documentation in Swagger UI.

## Authentication
- Register yourself by giving first name, last name, email and password in Register Api.
- Login giving email and password in Login Api.
- You will get JWT token inreturn to use to authenticate your user to use most of the endpoints.

## Pagination
- You need to give page number and page size to get Paginated data result.
- GetAll Catgories Api use pagination filters as model (form body).
- GetAll Products Api use pagination filters as query parameters.
