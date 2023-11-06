CREATE TABLE Zadania (
    IdZadania INT IDENTITY(1,1) PRIMARY KEY,
    Lp INT,
    Nazwa_Kosztu NVARCHAR(100),
    Warto��_Og�em DECIMAL(18, 2),
    Wydatki_Kwalifikowane DECIMAL(18, 2),
    Dofinansowanie DECIMAL(18, 2),
    Kategoria_Koszt�w NVARCHAR(50),
    Ilo��_Personelu INT,
    Zako�czone BIT,
    IdProjektu INT FOREIGN KEY REFERENCES Projekty(IdProjektu)
);