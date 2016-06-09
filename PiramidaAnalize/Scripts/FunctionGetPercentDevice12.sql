USE [Piramida2000]
GO

/****** Object:  UserDefinedFunction [dbo].[GetPercentDevice12]    Script Date: 06/07/2016 07:26:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-06
-- Description:	Процент сбора данных по заданному устройству
-- за заданный период времени
-- =============================================
CREATE FUNCTION [dbo].[GetPercentDevice12]
(
	-- Add the parameters for the function here
	@Object int,
	@DateStart datetime,
	@DateEnd datetime
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Expected int
	DECLARE @Items int
	DECLARE @Fact int
	DECLARE @Result int
	
	SELECT @Items=COUNT(*) FROM DEVICES INNER JOIN SENSORS ON DEVICES.ID=SENSORS.STATIONID
	WHERE DEVICES.CODE=@Object
	
	SELECT @Expected=@Items * DATEDIFF(MINUTE,@DateStart,@DateEnd)/30
	
	IF @Expected=0
		SELECT @Result=0
	ELSE
	BEGIN
		SELECT @Fact=COUNT(*) FROM DATA
		WHERE PARNUMBER=12 and OBJECT=@Object
		and DATA_DATE >= @DateStart and DATA_DATE < @DateEnd
		
		SELECT @Result=100 * @Fact/@Expected
	END
	RETURN @Result

END




GO

