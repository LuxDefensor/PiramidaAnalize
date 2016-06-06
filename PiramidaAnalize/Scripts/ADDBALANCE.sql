-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-03
-- Description:	Добавление нового баланса
-- =============================================
CREATE PROCEDURE AddBalance
	-- Add the parameters for the stored procedure here
	@Title nvarchar(255),
	@NewID int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @temp TABLE (NewID int)
    -- Insert statements for procedure here
	INSERT INTO Balance_main(Title,[Check])
	OUTPUT INSERTED.[ID] INTO @temp
	VALUES (@Title,0)

	
	SELECT @NewID=[NEWID] FROM @temp
END
GO
