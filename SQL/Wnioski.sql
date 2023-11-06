CREATE TABLE Wnioski (
    IdWniosku INT IDENTITY(1,1) PRIMARY KEY,
    NrKsiêgowy NVARCHAR(50),
    Data_Wniosku DATE,
    Kwota_Dofinansowania DECIMAL(18, 2),
    IdZadania INT FOREIGN KEY REFERENCES Zadania(IdZadania)
);