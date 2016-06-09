USE [Piramida2000]
GO

/****** Object:  UserDefinedFunction [dbo].[GetPercent12]    Script Date: 06/07/2016 07:26:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-03
-- Description:	Процент сбора данных по заданному каналу 
-- за заданный период времени
-- =============================================
CREATE FUNCTION [dbo].[GetPercent12]
(
	-- Add the parameters for the function here
	@Object int,
	@Item int,
	@DateStart datetime,
	@DateEnd datetime
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Expected int
	DECLARE @Fact int
	DECLARE @Result int
	
	SELECT @Expected=DATEDIFF(MINUTE,@DateStart,@DateEnd)/30
	
	IF @Expected=0
		SELECT @Result=0
	ELSE
	BEGIN
		SELECT @Fact=COUNT(*) FROM DATA
		WHERE PARNUMBER=12 and OBJECT=@Object and ITEM=@Item 
		and DATA_DATE >= @DateStart and DATA_DATE < @DateEnd
		
		SELECT @Result=100 * @Fact/@Expected
	END
	RETURN @Result

END



GO

