CREATE TABLE Projekty (
    IdProjektu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Data_Utworzenia DATE NOT NULL,
	Ostatnie_Użycie DATETIME NOT NULL,
	LpColumn INT NOT NULL,
	NazwaKosztuColumn INT NOT NULL,
	WartoscOgolnaColumn INT NOT NULL,
	WydatkiKwalifikowaneColumn INT NOT NULL,
	DofinansowanieColumn INT NOT NULL,
	KategoriaKosztowColumn INT NOT NULL,
    IdUżytkownika INT FOREIGN KEY REFERENCES Użytkownicy(IdUżytkownika)
);
