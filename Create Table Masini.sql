Use Parc_Auto
Go

Create TABLE Masini
(
ID int IDENTITY(1,1) PRIMARY KEY,
Numar varchar(255) NOT NULL,
Marca varchar(255) NOT NULL,
Serie varchar(255) NOT NULL,
Combustibil varchar(255) NOT NULL,
Poluare varchar(255) NOT NULL,
An varchar(255) NOT NULL
)

INSERT INTO Masini (Numar, Marca, Serie, Combustibil, Poluare, An)
   VALUES
   ('IS10LWY', 'Volkswagen', '2FMZA50463BA61002', 'Benzina', 'Euro 4', '2003');

INSERT INTO Masini (Numar, Marca, Serie, Combustibil, Poluare, An)
   VALUES
   ('IS11LWY', 'BMW', '1FAHP3GN7AW128385', 'Diesel', 'Euro 5', '2005');