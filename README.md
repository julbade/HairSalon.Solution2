# Hair Salon

#### A Hair Salon Program.

#### By **Julius Bade**

## Description
  An app for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **Program Gathers Name of Stylists** | Stylist 1: "Julius" | Stylist 2: "Mark" |
| **Program Gathers Name of Clients for each Stylists** | Client 1: "Jake" | Stylists 2 : "Mark"|
| **Program Adds Client for each Specific Sylist** | Client 2: "John" | Stylist 2 : "Mark"|
| **Program Adds Client for each Specific Sylist** | Client 1: "Sam" | Stylist 1 : "Julius"|
| **Program Adds Specialties for each Specific Sylist** | Specialties: "Hair Cut" | Stylist 1 : "Julius|
| **Program Adds Specialties for each Specific Sylist** | Specialties: "Hair Color" | Stylist 2 : "Mark"|
| **Program Adds Specialties for each Specific Sylist** | Specialties: "Conditioning Treatment" | Stylist 2 : "Mark"|



## Setup/Installation Requirements

1. Clone this repository at https://github.com/julbade/HairSalon.Solutions2
2. Go to folder directory HairSalon.Solution2/HairSalon
3. Open MAMP and start servers
4. Go to MySQL from terminal
5. > CREATE DATABASE hair_salon;
6. > USE hair_salon;
7. > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
8. > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255));
9. > CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));
10. Run through local host by typing "dotnet run"
11. Open Web Browser (Chrome, Mozilla, Safari, etc.)
12. Open http://localhost:5000 in web browser.

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C-Sharp
* MS Test
* Netcoreapp 1.1
* Atom
* GitHub
* MS MVC
* MySQL
* myPhpAdmin


## Support and contact details


_Julius Bade julbade21@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2018 **_{Julius Bade}_**
