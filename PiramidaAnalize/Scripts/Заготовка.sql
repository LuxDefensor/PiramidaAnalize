-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
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
CREATE FUNCTION GetPercent
(
	-- Add the parameters for the function here
	@Object int,
	@item int,
	@Parnumber int,
	@Base_date datetime,
	@interval int
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE <@ResultVar, sysname, @Result> <Function_Data_Type, ,int>

	-- Add the T-SQL statements to compute the return value here
	SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>

	-- Return the result of the function
	RETURN <@ResultVar, sysname, @Result>

END
GO

