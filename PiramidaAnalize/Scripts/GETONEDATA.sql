USE [Piramida2000]
GO

/****** Object:  UserDefinedFunction [dbo].[GetOneData]    Script Date: 06/07/2016 15:37:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-07
-- Description:	Возвращает одно значение из талицы DATA
-- =============================================
CREATE FUNCTION [dbo].[GetOneData]
(
	@Object int,
	@Item int,
	@Parnumber int,
	@Data_date datetime
)
RETURNS float
AS
BEGIN
	DECLARE @Result float
	SELECT @Result=data.VALUE0 FROM DATA
	WHERE PARNUMBER=@Parnumber AND @Object=OBJECT AND ITEM=@Item
	AND DATA_DATE=@Data_date
	RETURN @Result
END

GO

