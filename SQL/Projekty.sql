CREATE TABLE Projekty (
    IdProjektu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Data_Utworzenia DATE NOT NULL,
    IdUżytkownika INT FOREIGN KEY REFERENCES Użytkownicy(IdUżytkownia)
);
