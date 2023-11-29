CREATE PROCEDURE PozostaleSrodkiDlaZadnia
    @IdZadania INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SumaDofinansowan DECIMAL(18, 2);
	DECLARE @Dofinansowanie DECIMAL(18,2);
	DECLARE @SumaWydakow DECIMAL(18,2);

    -- Oblicz sumê kwot wniosków dla danego zadania
    SELECT @SumaDofinansowan = ISNULL(SUM(Kwota_Dofinansowania), 0)
    FROM Wnioski
    WHERE IdZadania = @IdZadania;

	SELECT @Dofinansowanie = ISNULL(Dofinansowanie,0)
	FROM Zadania 
	WHERE IdZadania = @IdZadania;

	SELECT @SumaWydakow = ISNULL(Suma_Wydatków,0)
	FROM Zadania 
	WHERE IdZadania = @IdZadania;




    -- Aktualizuj pole w tabeli zadañ
    UPDATE Zadania
    SET Pozosta³e_Œrodki = @SumaDofinansowan + @Dofinansowanie - @SumaWydakow
    WHERE IdZadania = @IdZadania;
END
