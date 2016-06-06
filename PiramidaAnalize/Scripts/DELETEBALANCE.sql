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
-- Description:	Удаляет запись из таблицы Balance_main и все 
-- подчинённые записи в таблицы Balance
-- =============================================
CREATE PROCEDURE DeleteBalance
	-- Add the parameters for the stored procedure here
	@BalanceNo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	begin tran
	delete from Balance where Balance.No=@BalanceNo
	delete from Balance_main where Balance_main.ID=@BalanceNo
	commit tran
END
GO
