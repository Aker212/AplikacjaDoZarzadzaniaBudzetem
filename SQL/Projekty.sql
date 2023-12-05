CREATE TABLE Projekty (
    IdProjektu INT IDENTITY(1,1) PRIMARY KEY,
    Nazwa NVARCHAR(50) NOT NULL,
    Data_Utworzenia DATE NOT NULL,
	Ostatnie_U�ycie DATETIME NOT NULL,
	LpColumn INT NOT NULL,
	NazwaKosztuColumn INT NOT NULL,
	WartoscOgolnaColumn INT NOT NULL,
	WydatkiKwalifikowaneColumn INT NOT NULL,
	DofinansowanieColumn INT NOT NULL,
	KategoriaKosztowColumn INT NOT NULL,
    IdU�ytkownika INT FOREIGN KEY REFERENCES U�ytkownicy(IdU�ytkownika)
);
