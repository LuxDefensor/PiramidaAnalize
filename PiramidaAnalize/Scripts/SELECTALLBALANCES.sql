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
-- Description:	Устанавливает или снимает все флажки в поле [Check]
-- таблицы Balance_main
-- =============================================
CREATE PROCEDURE SelectAllBalances
	-- Add the parameters for the stored procedure here
	@SetState bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Balance_main SET [Check]=@SetState
END
GO
