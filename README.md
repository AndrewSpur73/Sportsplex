<h1 align="center" style="font-weight: bold;">Sportsplex 💻</h1>

<p align="center">
 <a href="#tech">Technologies</a> • 
 <a href="#started">Getting Started</a> • 
  <a href="#routes">API Endpoints</a> •
 <a href="#colab">Collaborators</a> •
</p>

<p align="center">
    <b>The SportsplexAPI allows users to retrieve, create, update, and delete bookings, locations, Comments, and categories. It is designed to facilitate interactions with users, their RSVP'd bookings, and the categories of the bookingss in an organized and user-friendly way.</b>
</p>

<h2 id="technologies">💻 Technologies</h2>

- C#
- .NET
- SQL
- EFcore
- PgAdmin
- Postman/Swagger - testing/documentation

<h2 id="started">🚀 Getting started</h2>

1.) Clone a repository option in Visual Studio 2.) Enter or type the repository location, and then select the Clone button 3.) To start building the program, press the green Start button on the Visual Studio toolbar, or press F5 or Ctrl+F5. Using the Start button or F5 runs the program under the debugger.

<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project. For example:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
 
<h4>Packages</h4>

- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0

<h3>Postman Documentation</h3>

- [API Documentation](https://documenter.getpostman.com/view/31982709/2sAYBVgWX2)

<h3>Cloning</h3>

How to clone your project

```bash
git clone git@github.com:AndrewSpur73/Sportsplex.git
```

<h3>Starting</h3>

```bash
cd Sportsplex
dotnet watch run
```

<h2 id="routes">📍 API Endpoints</h2>

Here you can list the main routes of your API, and what are their expected request bodies.
​
| user          | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET Login</kbd> |	Retrieves login information
| <kbd>POST Register</kbd> |	Registers a new user
| <kbd>GET User by Id</kbd> |	Retrieves a user by their id
| <kbd>GET User by UID</kbd> |	Retrieves a user by their unique UID
|<kbd>PATCH Update user</kbd> |	Updates a user's information
| <kbd>DELETE Delete user</kbd> |	Deletes a user account

| comment         | description                                          
|----------------------|-----------------------------------------------------
|<kbd>GET Comments</kbd> |	Retrieves all comments
|<kbd>POST Create comment</kbd> |	Creates a new comment
|<kbd>PATCH Update comment</kbd> |	Updates an existing comment
|<kbd>DELETE Delete comment</kbd> |	Deletes a comment

| location          | description                                          
|----------------------|-----------------------------------------------------
|<kbd>GET locations</kbd> |	Retrieves all locations
|<kbd>POST Create location</kbd> |	Creates a new location
|<kbd>PATCH Update location</kbd> |	Updates an existing location
|<kbd>DELETE Delete location</kbd> |	Deletes a location

| category          | description                                          
|----------------------|-----------------------------------------------------
|<kbd>GET Categories</kbd> |	Retrieves all categories
|<kbd>POST Create category</kbd> |	Creates a new category
|<kbd>PATCH Update category</kbd> |	Updates an existing category
|<kbd>DELETE Delete category</kbd> |	Deletes a category

| bookings          | description                                          
|----------------------|-----------------------------------------------------
|<kbd>GET All bookings</kbd> |	Retrieves all bookings
|<kbd>POST Create booking</kbd> |	Creates a new booking
|<kbd>GET User bookings</kbd>	| Retrieves bookings associated with a user
|<kbd>GET Single booking</kbd> |	Retrieves a single booking's data
|<kbd>PUT Edit booking</kbd> |	Edits an existing booking
|<kbd>DELETE Delete booking</kbd> |	Deletes a booking
|<kbd>POST Create booking RSVP</kbd> |	RSVPs a booking

<h2 id="colab">🤝 Collaborators</h2>

Special thank you for all people that contributed for this project.

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/153697028?v=4" width="100px;" alt="Andrew Spurlock Profile Picture"/><br>
        <sub>
          <b>Andrew Spurlock</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
