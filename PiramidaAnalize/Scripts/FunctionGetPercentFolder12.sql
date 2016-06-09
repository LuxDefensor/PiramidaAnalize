USE [Piramida2000]
GO

/****** Object:  UserDefinedFunction [dbo].[GetPercentFolder12]    Script Date: 06/07/2016 07:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-06
-- Description:	Процент сбора данных по заданной папке
-- за заданный период времени
-- =============================================
CREATE FUNCTION [dbo].[GetPercentFolder12]
(
	-- Add the parameters for the function here
	@Folder int,
	@DateStart datetime,
	@DateEnd datetime
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Expected int
	DECLARE @Items int
	DECLARE @DevCode int
	DECLARE @Fact int
	DECLARE @FactSum int
	DECLARE @Result int
	
	SELECT @Items=COUNT(*) FROM DEVICES INNER JOIN SENSORS ON DEVICES.ID=SENSORS.STATIONID
	WHERE DEVICES.FOLDERID=@Folder
	
	SELECT @Expected=@Items * DATEDIFF(MINUTE,@DateStart,@DateEnd)/30
	
	IF @Expected=0
		SELECT @Result=0
	ELSE
	BEGIN
		SELECT @FactSum = 0
		
		DECLARE DevicesList CURSOR 
			FOR SELECT DEVICES.CODE FROM DEVICES WHERE FOLDERID=@Folder
		OPEN DevicesList
		FETCH Next FROM DevicesList
		INTO @DevCode
		WHILE @@FETCH_STATUS=0
		BEGIN
			SELECT @Fact=COUNT(*) FROM DATA
			WHERE PARNUMBER=12 and OBJECT=@DevCode
			and DATA_DATE >= @DateStart and DATA_DATE < @DateEnd
			SELECT @FactSum = @FactSum + @Fact
			FETCH NEXT FROM DevicesList
			INTO @DevCode
		END
		CLOSE DevicesList
		
		SELECT @Result=100 * @FactSum/@Expected
	END
	RETURN @Result
END







GO

