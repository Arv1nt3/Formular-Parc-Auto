Use Parc_Auto
Go

Create TABLE Records
(
ID int IDENTITY(1,1) PRIMARY KEY,
Nume varchar(255) NOT NULL,
Cod varchar(255) Not Null,
Numar varchar(9) NOT NULL,
Marca varchar(255) NOT NULL,
Serie varchar(255) NOT NULL,
Kilometraj varchar(255) NOT NULL,
Combustibil varchar(255) NOT NULL,
An varchar(255) NOT NULL,
Poluare varchar(255) NOT NULL,
Data Date not null,
Statie varchar(255) NOT NULL,
Minim float Not Null,
Maxim float Not Null,
Total float Not Null
)