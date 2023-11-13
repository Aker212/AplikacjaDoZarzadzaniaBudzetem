CREATE PROCEDURE SumInvoiceAmountForTask
    @IdZadania INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SumaWydatkow DECIMAL(18, 2);

    -- Oblicz sum� kwot faktur dla danego zadania
    SELECT @SumaWydatkow = ISNULL(SUM(Kwota), 0)
    FROM Faktury
    WHERE IdZadania = @IdZadania;

    -- Aktualizuj pole w tabeli zada�
    UPDATE Zadania
    SET SumaWydatk�w = @SumaWydatkow
    WHERE IdZadania = @IdZadania;
END
