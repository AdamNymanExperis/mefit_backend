# Mefit backend
This is the web api for the backend of the mefit aplication using ASP.Net Core Web Api framework connected to a SQL Server database. The database was seeded with realistic information related to the fitness application.
The Api endpoints were typical CRUD HTTP requests for each of the tables in the database used by the frontend.

This application is also deployed to Azure cloud services. It is set up to be used by a frontend deployed on vercel. The frontend project can be found at https://github.com/AdamNymanExperis/mefit_frontend

## Technologies 
Technologies used for the assignment is [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (.Net 6.0), [SQL server management studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16), ASP.Net Web Api.

# Installation
Firstly, to run this project you need to setup SQL Server Management System to handle the database. 
## install database
An example of how this is done is using Sql Server Management System. 
- download and install SSMS, [SQL server management studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16). 
- start the program, it will ask you for a "server name" what was used in this project was "(LocalDb)\MSSQLLocalDB"
Now the database is ready. 

## install Visual studio and open project
We also needs to be able to run the project itself. 
An example on how to run this project is through visual studio. 
- download and install a prefered version of [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).
- Clone this repository to your device.
- In Visual Studio navigate to "File" -> "Open" -> "Project/Solution" 
- Visual Studio will then open a file explorer, navigate to the project and select the file "Mefit_backend"
- To open the Package manager console navigate to "view" -> "Other Windows" -> "Package Manager Console" 
The package manager console should now be accessable in the lower left corner of Visual Studio. 
- Open the package manager console and type the following command: "update-database". This will seed the data in the database. 
Once the project is imported and the database is seeded, we can run the Program.cs file to get a Swagger page containing the different endpoints of the API.  

### authors
Made by Jonas Duong, Adam Nyman and Robin Stempa.
