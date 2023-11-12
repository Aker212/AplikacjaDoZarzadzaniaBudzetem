CREATE TABLE Faktury (
    IdFaktury INT IDENTITY(1,1) PRIMARY KEY,
    Nr_faktury NVARCHAR(50),
    Kwota DECIMAL(18, 2),
    Opis NVARCHAR(255),
    Data_Faktury DATE,
    Jednostka NVARCHAR(50),
    Budynek NVARCHAR(50),
    Pokój NVARCHAR(20),
    IdZadania INT FOREIGN KEY REFERENCES Zadania(IdZadania)
);