CREATE TRIGGER Sklyar_A.CheckDate ON Sklyar_A.actions
	AFTER INSERT
AS
	DECLARE @startDate DATE;
	DECLARE @endDate DATE;
	DECLARE @percent FLOAT;
	SELECT @startDate = i.day_start FROM inserted i;
	SELECT @endDate = i.day_stop FROM inserted i;
	SELECT @percent = i.percents FROM inserted i;
	IF ((@startDate > @endDate) OR (@endDate < GETDATE()) OR (@percent < 0) OR (@percent > 100))
	BEGIN
		RAISERROR('The data is incorrect - change it and try again', -1, -1)
		ROLLBACK TRANSACTION;
		RETURN;
	END;
GO