CREATE PROCEDURE SumaWydatkowDlaZadania
    @IdZadania INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SumaWydatkow DECIMAL(18, 2);

    -- Oblicz sumê kwot faktur dla danego zadania
    SELECT @SumaWydatkow = ISNULL(SUM(Kwota), 0)
    FROM Faktury
    WHERE IdZadania = @IdZadania;

    -- Aktualizuj pole w tabeli zadañ
    UPDATE Zadania
    SET Suma_Wydatków = @SumaWydatkow
    WHERE IdZadania = @IdZadania;
END
