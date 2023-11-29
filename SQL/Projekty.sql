CREATE TABLE Projekty (
    IdProjektu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Data_Utworzenia DATE NOT NULL,
	Ostatnie_U퓓cie DATETIME NOT NULL,
    IdU퓓tkownika INT FOREIGN KEY REFERENCES U퓓tkownicy(IdU퓓tkownika)
);
