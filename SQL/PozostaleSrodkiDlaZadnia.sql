CREATE PROCEDURE PozostaleSrodkiDlaZadnia
    @IdZadania INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SumaDofinansowan DECIMAL(18, 2);
	DECLARE @Dofinansowanie DECIMAL(18,2);
	DECLARE @SumaWydakow DECIMAL(18,2);

    -- Oblicz sum� kwot wniosk�w dla danego zadania
    SELECT @SumaDofinansowan = ISNULL(SUM(Kwota_Dofinansowania), 0)
    FROM Wnioski
    WHERE IdZadania = @IdZadania;

	SELECT @Dofinansowanie = ISNULL(Dofinansowanie,0)
	FROM Zadania 
	WHERE IdZadania = @IdZadania;

	SELECT @SumaWydakow = ISNULL(Suma_Wydatk�w,0)
	FROM Zadania 
	WHERE IdZadania = @IdZadania;




    -- Aktualizuj pole w tabeli zada�
    UPDATE Zadania
    SET Pozosta�e_�rodki = @SumaDofinansowan + @Dofinansowanie - @SumaWydakow
    WHERE IdZadania = @IdZadania;
END
