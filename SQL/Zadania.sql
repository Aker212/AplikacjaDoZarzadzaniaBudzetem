CREATE TABLE Zadania (
    IdZadania INT IDENTITY(1,1) PRIMARY KEY,
    Lp INT,
    Nazwa_Kosztu NVARCHAR(250),
    Warto��_Og�em DECIMAL(18, 2),
    Wydatki_Kwalifikowane DECIMAL(18, 2),
    Dofinansowanie DECIMAL(18, 2),
    Kategoria_Koszt�w NVARCHAR(50),
    Ilo��_Personelu INT,
    Zako�czone BIT,
	Pozosta�e_�rodki DECIMAL(18, 2),
    Suma_Wydatk�w DECIMAL(18, 2),
	IdProjektu INT FOREIGN KEY REFERENCES Projekty(IdProjektu)
	
);