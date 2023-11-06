CREATE TABLE Zadania (
    IdZadania INT IDENTITY(1,1) PRIMARY KEY,
    Lp INT,
    Nazwa_Kosztu NVARCHAR(100),
    Wartoœæ_Ogó³em DECIMAL(18, 2),
    Wydatki_Kwalifikowane DECIMAL(18, 2),
    Dofinansowanie DECIMAL(18, 2),
    Kategoria_Kosztów NVARCHAR(50),
    Iloœæ_Personelu INT,
    Zakoñczone BIT,
    IdProjektu INT FOREIGN KEY REFERENCES Projekty(IdProjektu)
);