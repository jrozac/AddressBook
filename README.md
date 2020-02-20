# Address Book Test Assignment

This repository represents a "phone book" assignment implementation based on .NET core and Angular. Projects organization is as follows:
* **TestAssignment.AddressBook.Service**. Backend service developed in .NET. It uses Swagger and Entity Framework.
* **TestAssignment.AddressBook.Client**. Typescript client generator. It generates the client for user interface project based on swagger definition of the service project.
* **TestAssignment.AddressBook.Ui**. User interface implementation.

Client generation is based on [Sander Aernouts blog](https://blog.sanderaernouts.com/autogenerate-typescript-api-client-with-nswag).
Sample contacts data are taken from [www.briandunning.com](https://www.briandunning.com/sample-data/us-500.zip).

~~~bat
rem Build solution
dotnet publish -c Release

rem Run backend service
cd TestAssignment.AddressBook.Service\bin\Release\netcoreapp3.1\publish\
START TestAssignment.AddressBook.Service.exe --urls "http://localhost:5050"
cd ..\..\..\..\..

rem Run user interface service
cd TestAssignment.AddressBook.Ui\bin\Release\netcoreapp3.1\publish\
START TestAssignment.AddressBook.Ui.exe --urls "http://localhost:5060"
cd ..\..\..\..\..
~~~

## TestAssignment.AddressBook.Service

Default database configuration is set to InMemory. To use Microsoft SQL server, set the appsettings.json property DatabaseType to Sql and set the appropriate connection string and create the database tables as defined in migration.sql.
This services implements a REST API to manage contacts. In configuration above swagger console is available at `http://localhost:5050/swagger`.

## TestAssignment.AddressBook.Service

This service implements user interface accessing data from REST API. In configuration above a client is available at `http://localhost:5060`.
API endpoint used is the debug one. It can be changed in index.html (tag base, attribute data-api).
