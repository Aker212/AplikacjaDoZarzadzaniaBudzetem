CREATE TABLE Projekty (
    IdProjektu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Data_Utworzenia DATE NOT NULL,
    IdU¿ytkownika INT FOREIGN KEY REFERENCES U¿ytkownicy(IdU¿ytkownia)
);
