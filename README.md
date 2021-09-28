Big Shoe Company
==============
Upload custom orders with XML files for Big Shoe Company

Tested on Windows 10 OS, Google Chrome Version 93.0.4577.82

## Requirements ##
1. .NET Core API 3.1
2. Node.js
3. npm

## Easy Steps ##
1. Go into the BigShoeCompany\big-shoe-company-ui directory and type  `npm start`
2. After complete, you can browse to  http://localhost:3000, and you can see the UI for the application
3. In another command window, go into BigShoeCompany\src\Big.Shoe.Company and type `dotnet run --launch-profile dev-test`

## Usage ##

• Drag 'n' drop the XML file or press the box select the file.

• Validation is done with XSD 1.0 but also additional logic in C#.

• Validation against XSD file will have box message with background: ![#ff4a4a](https://via.placeholder.com/15/ff4a4a/000000?text=+) 

• All the orders succesfully validated will be displayed with background: ![#57bf81](https://via.placeholder.com/15/57bf81/000000?text=+)

• All the orders unsuccesfully validated will be displayed with background: ![#ff4a4a](https://via.placeholder.com/15/ff4a4a/000000?text=+) 

• Validated orders will have the Print Option available

• Orders with validation against XSD file but with date not in the next 10 future days will have also the Print Option available.
