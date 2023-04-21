# Ceestore Web API

This repository contains the source code for CeeStore's Web API, which is built using C#, ASP.NET Core, and MS SQL. The API provides endpoints for various features of the e-commerce platform, such as user authentication, product management, and order processing.

## Table of Contents
- [Getting Started](https://github.com/IsraelChidera/CeeStore#getting-started)

- [Technologies Used](https://github.com/IsraelChidera/CeeStore#technologies-used)

- [API Endpoints](https://github.com/IsraelChidera/CeeStore#api-endpoints)

- [Authentication and Authorization](https://github.com/IsraelChidera/CeeStore#authentication-and-authorization)

- [Running the API Locally](https://github.com/IsraelChidera/CeeStore#running-the-api-locally)

- [Deployment](https://github.com/IsraelChidera/CeeStore#deployment)

- [Contributing](https://github.com/IsraelChidera/CeeStore#contributing)


## Getting Started
To use the Ceestore Web API, you must have the following prerequisites installed:

- .NET Core SDK version 3.1 or later
- MS SQL Server or SQL Server Express
- A text editor or integrated development environment (IDE) such as Visual Studio Code

To get started, follow these steps:

1. Clone the repository to your local machine. 
2. Open the solution file CeestoreWebAPI.sln in your preferred IDE or text editor.
3. Update the database connection string in the appsettings.json file with your MS SQL Server connection string.
4. Run the application using your IDE

## Technologies Used
The Ceestore Web API is built using the following technologies:

- C#
- ASP.NET Core
- MS SQL Server

## API Endpoints
The Ceestore Web API provides the following endpoints:

- GET /api/Products/all-products: Returns a list of all products in the store's inventory.
- GET /api/Products/get-seller-products: Returns a list of all products created by a specific seller in the store's inventory.
- GET /api/Products/search-products: Returns product or a list of products based on product name
- POST /api/Products/create-a-product: Creates a new product in the store's inventory.
- PUT /api/Products/{productId}: Updates an existing product by ID.
- DELETE /api/Products/{productId}: Deletes a product by ID.
- POST /api/orders/cart/checkout: Checkout a seller orders made on a product
- POST /api/Payment/verify-payment: Verify payment on orders created via Paystack payment gateway
- GET /api/Users/get-all-users: Returns a list of all users in the application


## Authentication and Authorization
The Ceestore Web API uses Identity and JWT (JSON Web Tokens) for authentication and authorization. 
To access the API endpoints, you must obtain a valid JWT token by logging in with valid credentials. When a user logs in, a token is generated and returned to the client. This token should be included in the Authorization header of subsequent requests. The API provides the following endpoints for authentication:

- /api/Authentication/register-as-a-seller - Allows users to register for a new account as a seller
- /api/Authentication/register-as-a-buyer- Allows users to register for a new account as a buyer
- /api/Authentication/register-as-an-admin- Admin registration
- /api/Authentication/login - Allows a user to log in to their account and receive a JWT token.

The API also includes authorization checks on certain endpoints, ensuring that only authenticated users with the appropriate role can perform certain actions. The available roles are:

- Admin: Has full access to all endpoints.
- Seller: Has access to all products endpoints. 
- Buyer: Has limited access to only the GET endpoints for products, orders and payment.

## Running the API Locally
To run the Ceestore Web API locally, follow these steps:
Ensure that the prerequisites are installed (see Getting Started section above).
- Clone the repository to your local machine.
- Open the solution file CeestoreWebAPI.sln in your preferred IDE or text editor.
- Update the database connection string in the appsettings.json file with your MS SQL Server connection string.
- Run the application using your IDE

## Deployment
#### Details coming soon

## Contributing
To contribute to the Ceestore Web API, please follow these guidelines:

- Create a new branch for your changes.
- Make your changes and commit them with clear commit messages.
- Push your changes to your forked repository.
- Create a pull request to the main repository's master branch.

