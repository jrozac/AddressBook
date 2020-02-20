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