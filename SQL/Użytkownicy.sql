CREATE TABLE U�ytkownicy (
    IdU�ytkownika INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(50) NOT NULL,
    Has�o NVARCHAR(100) NOT NULL,
    S�l NVARCHAR(50) NOT NULL,
    Rola NVARCHAR(50) NOT NULL
);
