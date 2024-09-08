Sure! Here’s the GitHub project description in English:

---

# Contact Management API

## Description

This is a test assignment for **Bogoda Digital Pro**, implemented using **.NET 8** and principles of **clean architecture**. The project represents an API for managing contacts with support for CRUD (Create, Read, Update, Delete) operations. **PostgreSQL** is used as the database.

## Functionality

The API allows you to perform the following operations on contacts:

- **Create a contact**
- **Get a list of all contacts**
- **Get a contact by ID**
- **Update a contact by ID**
- **Delete a contact by ID**

## Endpoints

### 1. Get All Contacts
- **Method:** `GET`
- **Endpoint:** `/contact`
- **Description:** Returns a list of all contacts.

### 2. Get Contact by ID
- **Method:** `GET`
- **Endpoint:** `/contact/{id}`
- **Description:** Returns a contact by the specified ID.
- **Parameters:**
  - `id` (int): Contact ID.

### 3. Create Contact
- **Method:** `POST`
- **Endpoint:** `/contact`
- **Description:** Creates a new contact.
- **Request Body:**
  ```json
  {
      "Email": "example@example.com",
      "FirstName": "John",
      "LastName": "Doe",
      "Phone": "123-456-7890"
  }
  ```

### 4. Update Contact
- **Method:** `PUT`
- **Endpoint:** `/contact/{id}`
- **Description:** Updates an existing contact by the specified ID.
- **Parameters:**
  - `id` (int): Contact ID.
- **Request Body:**
  ```json
  {
      "Email": "updated@example.com",
      "FirstName": "Jane",
      "LastName": "Doe",
      "Phone": "098-765-4321"
  }
  ```

### 5. Delete Contact
- **Method:** `DELETE`
- **Endpoint:** `/contact/{id}`
- **Description:** Deletes a contact by the specified ID.
- **Parameters:**
  - `id` (int): Contact ID.

## Deployment

### Requirements

- .NET 8 SDK
- EF CORE
- PostgreSQL

### Steps to Deploy

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/contact-management-api.git
   cd contact-management-api
   ```

2. **Set up the database:**
   - Create a new database in PostgreSQL.
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Database=your_database;Username=your_username;Password=your_password"
     }
     ```

3. **Run migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```
