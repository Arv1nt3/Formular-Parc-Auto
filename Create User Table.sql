Use Parc_Auto
Go

Create TABLE Users
(
ID int IDENTITY(1,1) PRIMARY KEY,
Username varchar(255) NOT NULL,
Password varchar(255) NOT NULL
)

INSERT INTO Users (Username, Password)
   VALUES
   ('admin', 'Pricop');