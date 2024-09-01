# Reliable Reservations API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0.8-blue)](https://learn.microsoft.com/en-us/ef/core/)
[![Swashbuckle](https://img.shields.io/badge/Swashbuckle-6.4.0-green)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)


### A robust backend system designed to streamline restaurant management operations.

## Table of Contents
- [🔭 Overview](#-overview)
- [✨ Features](#-features)
- [🔗 ER Diagram](#-er-diagram)
- [🚀 Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [📚 API Documentation](#-api-documentation)
- [🦾 Technologies and Packages](#-technologies-and-packages)
- [🌐 Endpoints](#-endpoints)
  - [CustomerController](#customercontroller)
  - [TableController](#tablecontroller)
  - [OpeningHoursController](#openinghourscontroller)
  - [MenuItemController](#menuitemcontroller)
  - [ReservationController](#reservationcontroller)


---

## 🔭 Overview

Reliable Reservations API is a comprehensive solution for managing various aspects of restaurant operations.

I built the system using a layered architecture with controllers, services, and repositories, leveraging dependency injection to enhance modularity, testability, and scalability. 
The database is built using a code-first approach with Entity Framework Core, allowing the schema to be generated and managed directly from the application's data models.

Developed with ASP.NET Core 8 and Entity Framework Core 8, it provides a powerful and flexible foundation for handling restaurant data and processes.

---

## ✨ Features

- 👥 Customer Management
- 🪑 Table Management
- 🕒 Opening Hours Management
- 🍽️ Menu Item Management
- 📅 Reservation System

---

## 🔗 ER Diagram

Here is the ER diagram illustrating the relationships between the entities in the system.

![ER Diagram](/Media/erdiagram.webp "ER Diagram")

---

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/reliable-reservations-api.git
   ```
2. Navigate to the project directory:
   ```
   cd reliable-reservations-api
   ```
3. Restore dependencies:
   ```
   dotnet restore
   ```
4. Create a `.env` file in the root directory and add your database connection string:
   ```
   DATABASE_CONNECTION_STRING=your_connection_string_here
   ```
5. Apply database migrations:
   ```
   dotnet ef database update
   ```
6. Run the application:
   ```
   dotnet run
   ```

---

## 📚 API Documentation

The API is organized into several controllers, each managing a specific aspect of the restaurant system:

- **CustomerController**: 
    - Manages customer data
- **TableController**: 
    - Handles table information and availability
- **OpeningHoursController**: 
    - Manages restaurant opening hours
- **MenuItemController**: 
    - Deals with menu items and their details
- **ReservationController**: 
    - Manages the reservation system

---

API documentation is automatically generated using Swashbuckle. Once the application is running, you can access the Swagger UI at `/swagger`.

## 🦾 Technologies and Packages

- **Framework**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core 8.0.8
- **Database**: SQL Server
- **Mapping**: AutoMapper 13.0.1
- **Environment Variables**: DotNetEnv 3.1.1
- **API Documentation**: Swashbuckle.AspNetCore 6.4.0

---

## 🌐 Endpoints

- [CustomerController](#customercontroller)
- [OpeningHoursController](#openinghourscontroller)
- [MenuItemController](#menuitemcontroller)
- [ReservationController](#reservationcontroller)
- [TableController](#tablecontroller)

## CustomerController

### 1. **Get All Customers**
- **Endpoint**: `GET /api/Customer/all`
- **Description**: Retrieve a list of all customers.
- **Responses**:
  - `200 OK`: Returns a list of `CustomerDto` objects.
  - `404 Not Found`: "No customers in database." (when no customers are found)
- **Example Response**:
  ```json
  [
    {
      "customerId": 1,
      "firstName": "Bruce",
      "lastName": "Wayne",
      "phoneNumber": "123-456-7890"
      "email": "bruce@wayne.com",
    },
    {
      "customerId": 2,
      "firstName": "Ace",
      "lastName": "Ventura",
      "phoneNumber": "987-654-3210",
      "email": "ace@ventura.com"     
    }
  ]
  ```

### 2. **Get Customer by ID**
- **Endpoint**: `GET /api/Customer/{id}`
- **Description**: Retrieve a specific customer by their ID.
- **Parameters**:
  - `id` (path parameter): The ID of the customer to retrieve.
- **Responses**:
  - `200 OK`: Returns a `CustomerDto` object.
  - `404 Not Found`: When the customer with the specified ID is not found.
- **Example Response**:
  ```json
   {
     "customerId": 2,
     "firstName": "Walter",
     "lastName": "White",
     "phoneNumber": "987654321",
     "email": "walter@white.com"
   }
  ```

### 3. **Create Customer**
- **Endpoint**: `POST /api/Customer/create`
- **Description**: Create a new customer.
- **Request Body**: `CustomerCreateDto` object
- **Responses**:
  - `201 Created`: Returns the created `CustomerDto` object.
- **Example Request**:
  ```json
    {
      "firstName": "Tom",
      "lastName": "Cruise",
      "phoneNumber": "555-123-4567",
      "email": "tom@cruise.com"
    }
  ```
- **Example Response**:
  ```json
  {
    "customerId": 3,
      "firstName": "Tom",
      "lastName": "Cruise",
      "phoneNumber": "555-123-4567",
      "email": "tom@cruise.com"
  }
  ```

### 4. **Update Customer**
- **Endpoint**: `PUT /api/Customer/{id}`
- **Description**: Update an existing customer.
- **Parameters**:
  - `id` (path parameter): The ID of the customer to update.
- **Request Body**: `CustomerDto` object
- **Responses**:
  - `201 Created`: Returns the updated `CustomerDto` object.
  - `400 Bad Request`: When there's an ID mismatch between the URL and request body.
  - `404 Not Found`: When the customer with the specified ID is not found.
- **Example Request**:
  ```json
  {
    "customerId": 1,
    "firstName": "Matthew",
    "lastName": "McConaughey",
    "phoneNumber": "123-456-7899",
    "email": "matthew@example.com"
  }
  ```
- **Example Response**:
  ```json
  {
    "customerId": 1,
    "firstName": "Matthew",
    "lastName": "McConaughey",
    "phoneNumber": "123-456-7899",
    "email": "matthew@example.com"
  }
  ```

### 5. **Delete Customer**
- **Endpoint**: `DELETE /api/Customer/{id}`
- **Description**: Delete a customer.
- **Parameters**:
  - `id` (path parameter): The ID of the customer to delete.
- **Responses**:
  - `200 OK`: Returns a success message.
  - `404 Not Found`: When the customer with the specified ID is not found.
- **Example Response**:
  ```json
  {
    "message": "Customer with ID 1 has been successfully deleted."
  }
  ```

## OpeningHoursController

### 1. **Get All Opening Hours**
- **Endpoint**: `GET /api/OpeningHours/all`
- **Description**: Retrieve a list of all opening hours.
- **Responses**:
  - `200 OK`: Returns a list of `OpeningHoursDto` objects
  - `404 Not Found`: "No opening hours found."
- **Example Response**:
  ```json
  [
    {
      "openingHoursId": 5,
      "dayOfWeek": "Thursday",
      "openTime": "10:00:00",
      "closeTime": "23:00:00",
      "isClosed": false
    },
    {
      "openingHoursId": 6,
      "dayOfWeek": "Friday",
      "openTime": "10:00:00",
      "closeTime": "23:00:00",
      "isClosed": false
    }
  ]
  ```

### 2. **Get Opening Hours by ID**
- **Endpoint**: `GET /api/OpeningHours/{id}`
- **Description**: Retrieve specific opening hours by ID.
- **Parameters**:
  - `id` (path parameter): The ID of the opening hours to retrieve.
- **Responses**:
  - `200 OK`: Returns an `OpeningHoursDto` object.
  - `404 Not Found`: When the opening hours with the specified ID are not found.
- **Example Response**:
  ```json
  {
    "openingHoursId": 4,
    "dayOfWeek": "Wednesday",
    "openTime": "10:00:00",
    "closeTime": "23:00:00",
    "isClosed": false
  }
  ```

### 3. **Create Opening Hours**
- **Endpoint**: `POST /api/OpeningHours/create`
- **Description**: Create new opening hours.
- **Request Body**: `OpeningHoursCreateDto` object
- **Responses**:
  - `201 Created`: Returns the created `OpeningHoursDto` object.
- **Example Request**:
  ```json
  {
    "dayOfWeek": "Sunday",
    "openTime": {
      "hour": 10,
      "minute": 00
    },
    "closeTime": {
      "hour": 23,
      "minute": 00
    },
    "isClosed": false
  }
  ```
- **Example Response**:
  ```json
  {
    "openingHoursId": 1,
    "dayOfWeek": "Sunday",
    "openTime": "10:00",
    "closeTime": "23:00"
  }
  ```

### 4. **Update Opening Hours**
- **Endpoint**: `PUT /api/OpeningHours/{id}`
- **Description**: Update existing opening hours.
- **Parameters**:
  - `id` (path parameter): The ID of the opening hours to update.
- **Request Body**: `OpeningHoursDto` object
- **Responses**:
  - `200 OK`: Returns the updated `OpeningHoursDto` object.
  - `400 Bad Request`: When there's an ID mismatch.
  - `404 Not Found`: When the opening hours with the specified ID are not found.
- **Example Request**:
  ```json
  {
    "openingHoursId": 2,
    "dayOfWeek": "Monday",
    "openTime": {
      "hour": 0,
      "minute": 0
    },
    "closeTime": {
      "hour": 0,
      "minute": 0
    },
    "isClosed": true
  }
  ```
- **Example Response**:
  ```json
  {
    "openingHoursId": 2,
    "dayOfWeek": "Monday",
    "openTime": "00:00:00",
    "closeTime": "00:00:00"
    },
    "isClosed": true
  }
  ```

### 5. **Delete Opening Hours**
- **Endpoint**: `DELETE /api/OpeningHours/{id}`
- **Description**: Delete opening hours.
- **Parameters**:
  - `id` (path parameter): The ID of the opening hours to delete.
- **Responses**:
  - `204 No Content`: When successfully deleted.
  - `404 Not Found`: When the opening hours with the specified ID are not found.

## MenuItemController

### 1. **Get All Menu Items**
- **Endpoint**: `GET /api/MenuItem/all`
- **Description**: Retrieve a list of all menu items.
- **Responses**:
  - `200 OK`: Returns a list of `MenuItemDto` objects.
  - `404 Not Found`: "No menu items in database."
- **Example Response**:
  ```json
  [
    {
      "menuItemId": 1,
      "name": "Margherita Pizza",
      "description": "Classic pizza with tomato sauce and mozzarella",
      "price": 12.99,
      "category": "MainCourse",
      "availabilityStatus": true,
      "lastUpdated": "2024-08-31T17:07:57"
    },
    {
      "menuItemId": 2,
      "name": "Caesar Salad",
      "description": "Romaine lettuce with Caesar dressing and croutons",
      "price": 8.99,
      "availabilityStatus": true,
      "lastUpdated": "2024-08-27T17:07:57"
    }
  ]
  ```

### 2. **Get Menu Item by ID**
- **Endpoint**: `GET /api/MenuItem/{id}`
- **Description**: Retrieve a specific menu item by ID.
- **Parameters**:
  - `id` (path parameter): The ID of the menu item to retrieve.
- **Responses**:
  - `200 OK`: Returns a `MenuItemDto` object.
  - `404 Not Found`: When the menu item with the specified ID is not found.
- **Example Response**:
  ```json
  {
    "menuItemId": 1,
    "name": "Margherita Pizza",
    "description": "Classic pizza with tomato sauce and mozzarella",
    "price": 12.99,
    "category": "MainCourse",
    "availabilityStatus": true,
    "lastUpdated": "2024-08-31T17:07:57"
  }
  ```

### 3. **Create Menu Item**
- **Endpoint**: `POST /api/MenuItem/create`
- **Description**: Create a new menu item.
- **Request Body**: `MenuItemCreateDto` object
- **Responses**:
  - `201 Created`: Returns the created `MenuItemDto` object.
- **Example Request**:
  ```json
  {
    "name": "Spaghetti Carbonara",
    "description": "Pasta with eggs, cheese, and pancetta",
    "price": 14.99,
    "category": "MainCourse",
    "availabilityStatus": true,
    "lastUpdated": "2024-08-31T22:47:16.990Z"
  }
  ```
- **Example Response**:
  ```json
  {
    "menuItemId": 3,
    "name": "Spaghetti Carbonara",
    "description": "Pasta with eggs, cheese, and pancetta",
    "price": 14.99,
    "category": "MainCourse",
    "availabilityStatus": true,
    "lastUpdated": "2024-08-31T22:47:16.990Z"
  }
  ```

### 4. **Update Menu Item**
- **Endpoint**: `PUT /api/MenuItem/{id}`
- **Description**: Update an existing menu item.
- **Parameters**:
  - `id` (path parameter): The ID of the menu item to update.
- **Request Body**: `MenuItemDto` object
- **Responses**:
  - `200 OK`: Returns the updated `MenuItemDto` object.
- **Example Request**:
  ```json
  {
    "menuItemId": 3,
    "name": "Spaghetti Carbonara",
    "description": "Pasta with eggs, cheese, and pancetta",
    "price": 14.99,
    "category": "MainCourse",
    "availabilityStatus": true,
    "lastUpdated": "2024-08-31T22:47:16.990Z"
  }
  ```
- **Example Response**:
  ```json
  {
    "menuItemId": 3,
    "name": "Spaghetti Carbonara",
    "description": "Pasta with eggs, cheese, and pancetta",
    "price": 14.99,
    "category": "MainCourse",
    "availabilityStatus": true,
    "lastUpdated": "2024-08-31T22:47:16.990Z"
  }
  ```

### 5. **Delete Menu Item**
- **Endpoint**: `DELETE /api/MenuItem/{id}`
- **Description**: Delete a menu item.
- **Parameters**:
  - `id` (path parameter): The ID of the menu item to delete.
- **Responses**:
  - `200 OK`: Returns a success message.
  - `404 Not Found`: When the menu item with the specified ID is not found.
- **Example Response**:
  ```json
  {
    "message": "Menu item with ID 1 was successfully deleted."
  }
  ```

## ReservationController

### 1. **Get All Reservations**
- **Endpoint**: `GET /api/Reservation/all`
- **Description**: Retrieve a list of all reservations.
- **Responses**:
  - `200 OK`: Returns a list of `ReservationDto` objects or "No reservations in the database."
- **Example Response**:
  ```json
  [
    {
      "reservationId": 1,
      "customerId": 1,
      "customer": {
        "customerId": 1,
        "firstName": "Arnold",
        "lastName": "Schwarzenegger",
        "phoneNumber": "123456789",
        "email": "user@example.com"
      },
      "timeSlotId": 11,
      "timeSlot": {
        "timeSlotId": 11,
        "startTime": "2024-08-31T14:20:01",
        "endTime": "2024-08-31T15:20:01",
        "slotDuration": 60
      },
      "reservationDate": "2024-08-31T14:20:01",
      "numberOfGuests": 15,
      "specialRequests": "Cuban cigars",
      "status": "Pending",
      "tables": [
        {
          "tableId": 1,
          "tableNumber": 1,
          "seatingCapacity": 5,
          "location": "Inside"
        }
      ]
    },
    {
      "reservationId": 2,
      "customerId": 1,
      "customer": {
        "customerId": 1,
        "firstName": "Tony",
        "lastName": "Stark",
        "phoneNumber": "123456789",
        "email": "user@example.com"
      },
      "timeSlotId": 12,
      "timeSlot": {
        "timeSlotId": 12,
        "startTime": "2024-09-01T14:20:01",
        "endTime": "2024-09-01T15:20:01",
        "slotDuration": 60
      },
      "reservationDate": "2024-09-01T14:20:01",
      "numberOfGuests": 15,
      "specialRequests": "Iron",
      "status": "Confirmed",
      "tables": [
        {
          "tableId": 3,
          "tableNumber": 3,
          "seatingCapacity": 4,
          "location": "Outside"
        }
      ]
    }
  ]
  ```

### 2. **Get Reservation by ID**
- **Endpoint**: `GET /api/Reservation/{id}`
- **Description**: Retrieve a specific reservation by ID.
- **Parameters**:
  - `id` (path parameter): The ID of the reservation to retrieve.
- **Responses**:
  - `200 OK`: Returns a `ReservationDto` object.
  - `404 Not Found`: When the reservation with the specified ID is not found.
- **Example Response**:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "customer": {
      "customerId": 1,
      "firstName": "Arnold",
      "lastName": "Schwarzenegger",
      "phoneNumber": "123456789",
      "email": "user@example.com"
    },
    "timeSlotId": 11,
    "timeSlot": {
      "timeSlotId": 11,
      "startTime": "2024-08-31T14:20:01",
      "endTime": "2024-08-31T15:20:01",
      "slotDuration": 60
    },
    "reservationDate": "2024-08-31T14:20:01",
    "numberOfGuests": 15,
    "specialRequests": "Cuban cigars",
    "status": "Pending",
    "tables": [
      {
        "tableId": 1,
        "tableNumber": 1,
        "seatingCapacity": 5,
        "location": "Inside"
      }
    ]
  }
  ```

### 3. **Create Reservation**
- **Endpoint**: `POST /api/Reservation/create`
- **Description**: Create a new reservation.
- **Request Body**: `ReservationCreateDto` object
- **Responses**:
  - `201 Created`: Returns the created `ReservationDto` object.
- **Example Request**:
  ```json
  {
    "customerId": 1,
    "reservationDate": "2024-08-31T23:05:30.938Z",
    "numberOfGuests": 5,
    "tableNumbers": [
      1
    ],
    "seatingDuration": 60,
    "specialRequests": "Cuban cigars"
  }
  ```
- **Example Response**:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "customer": {
      "customerId": 1,
      "firstName": "Arnold",
      "lastName": "Schwarzenegger",
      "phoneNumber": "123456789",
      "email": "user@example.com"
    },
    "timeSlotId": 11,
    "timeSlot": {
      "timeSlotId": 11,
      "startTime": "2024-08-31T14:20:01",
      "endTime": "2024-08-31T15:20:01",
      "slotDuration": 60
    },
    "reservationDate": "2024-08-31T14:20:01",
    "numberOfGuests": 15,
    "specialRequests": "Cuban cigars",
    "status": "Pending",
    "tables": [
      {
        "tableId": 1,
        "tableNumber": 1,
        "seatingCapacity": 5,
        "location": "Inside"
      }
    ]
  }
  ```

### 4. **Update Reservation**
- **Endpoint**: `PUT /api/Reservation/{id}`
- **Description**: Update an existing reservation.
- **Parameters**:
  - `id` (path parameter): The ID of the reservation to update.
- **Request Body**: `ReservationDto` object
- **Responses**:
  - `201 Created`: Returns the updated `ReservationDto` object.
  - `400 Bad Request`: When there's an ID mismatch between the URL and request body.
  - `404 Not Found`: When the reservation with the specified ID is not found.
- **Example Request**:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "customer": {
      "customerId": 1,
      "firstName": "Arnold",
      "lastName": "Schwarzenegger",
      "phoneNumber": "123456789",
      "email": "user@example.com"
    },
    "timeSlotId": 11,
    "timeSlot": {
      "timeSlotId": 11,
      "startTime": "2024-08-31T14:20:01",
      "endTime": "2024-08-31T15:20:01",
      "slotDuration": 60
    },
    "reservationDate": "2024-08-31T14:20:01",
    "numberOfGuests": 15,
    "specialRequests": "Cuban cigars",
    "status": "Pending",
    "tables": [
      {
        "tableId": 1,
        "tableNumber": 1,
        "seatingCapacity": 5,
        "location": "Inside"
      }
    ]
  }
  ```
- **Example Response**:
  ```json
  {
    "reservationId": 1,
    "customerId": 1,
    "customer": {
      "customerId": 1,
      "firstName": "Arnold",
      "lastName": "Schwarzenegger",
      "phoneNumber": "123456789",
      "email": "user@example.com"
    },
    "timeSlotId": 11,
    "timeSlot": {
      "timeSlotId": 11,
      "startTime": "2024-08-31T14:20:01",
      "endTime": "2024-08-31T15:20:01",
      "slotDuration": 60
    },
    "reservationDate": "2024-08-31T14:20:01",
    "numberOfGuests": 15,
    "specialRequests": "Cuban cigars",
    "status": "Pending",
    "tables": [
      {
        "tableId": 1,
        "tableNumber": 1,
        "seatingCapacity": 5,
        "location": "Inside"
      }
    ]
  }
  ```
- ### 5. **Delete Reservation**
- **Endpoint**: `DELETE /api/Reservation/{id}`
- **Description**: Delete a reservation.
- **Parameters**:
  - `id` (path parameter): The ID of the reservation to delete.
- **Responses**:
  - `200 OK`: Returns a success message.
  - `404 Not Found`: When the reservation with the specified ID is not found.
- **Example Response**:
  ```json
  {
    "message": "Reservation with ID 1 has been successfully deleted."
  }
  ```

## TableController

### 1. **Get All Tables**
- **Endpoint**: `GET /api/Table/all`
- **Description**: Retrieve all tables from the database.
- **Parameters**: None
- **Responses**:
  - `200 OK`: Returns an array of `TableDto` objects or a message if no tables are found.
  - `500 Internal Server Error`: When an unexpected error occurs.
- **Example Response**:
  ```json
  [
    {
      "tableId": 1,
      "tableNumber": 1,
      "seatingCapacity": 5,
      "location": "MainFloor"
    },
    {
      "tableId": 2,
      "tableNumber": 2,
      "seatingCapacity": 8,
      "location": "Patio"
    },
    {
      "tableId": 3,
      "tableNumber": 3,
      "seatingCapacity": 5,
      "location": "MainFloor"
    },
    {
      "tableId": 4,
      "tableNumber": 4,
      "seatingCapacity": 3,
      "location": "Outside"
    },
    {
      "tableId": 5,
      "tableNumber": 5,
      "seatingCapacity": 5,
      "location": "Outside"
    }
  ]
  ```

### 2. **Get Table by ID**
- **Endpoint**: `GET /api/Table/{id}`
- **Description**: Retrieve a specific table by its ID.
- **Parameters**:
  - `id` (path parameter): The ID of the table to retrieve.
- **Responses**:
  - `200 OK`: Returns a `TableDto` object.
  - `404 Not Found`: When the table with the specified ID is not found.
  - `500 Internal Server Error`: When an unexpected error occurs.
- **Example Response**:
  ```json
  {
    "tableId": 1,
    "tableNumber": 1,
    "seatingCapacity": 5,
    "location": "Inside"
  }
  ```

### 3. **Create Table**
- **Endpoint**: `POST /api/Table/create`
- **Description**: Create a new table.
- **Request Body**: `TableCreateDto` object
- **Responses**:
  - `201 Created`: Returns the created `TableDto` object.
  - `500 Internal Server Error`: When an unexpected error occurs.
- **Example Request Body**:
  ```json
  {
    "tableNumber": 7,
    "seatingCapacity": 10,
    "location": "Terrace"
  }
  ```
- **Example Response**:
  ```json
  {
    "tableId": 7,
    "tableNumber": 7,
    "seatingCapacity": 10,
    "location": "Terrace"
  }
  ```

### 4. **Update Table**
- **Endpoint**: `PUT /api/Table/{id}`
- **Description**: Update an existing table.
- **Parameters**:
  - `id` (path parameter): The ID of the table to update.
- **Request Body**: `TableCreateDto` object
- **Responses**:
  - `201 Created`: Returns the updated `TableDto` object.
  - `404 Not Found`: When the table with the specified ID is not found.
  - `500 Internal Server Error`: When an unexpected error occurs.
- **Example Request Body**:
  ```json
  {
    "tableNumber": 7,
    "seatingCapacity": 10,
    "location": "VIP"
  }
  ```
- **Example Response**:
  ```json
  {
    "tableId": 7,
    "tableNumber": 7,
    "seatingCapacity": 10,
    "location": "VIP"
  }
  ```

### 5. **Delete Table**
- **Endpoint**: `DELETE /api/Table/{id}`
- **Description**: Delete a specific table by its ID.
- **Parameters**:
  - `id` (path parameter): The ID of the table to delete.
- **Responses**:
  - `200 OK`: Returns a success message.
  - `404 Not Found`: When the table with the specified ID is not found.
  - `500 Internal Server Error`: When an unexpected error occurs.
- **Example Response**:
  ```
  Table with ID 1 was successfully deleted.
  ```

---

## 🚀 Start optimizing your restaurant management!

Thank you for exploring the Reliable Reservations API documentation! I hope you find it valuable and easy to use.

⭐ **Star the project** on GitHub if you want to support! Your feedback and contributions are always welcome.

I wish you success in optimizing your restaurant management operations.
