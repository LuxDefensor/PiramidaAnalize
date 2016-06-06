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
-- Create date: 2016-05-31
-- Description:	Переключает флажок в таблице Balance_main
-- =============================================
CREATE PROCEDURE ToggleBalanceSelected
	-- Add the parameters for the stored procedure here
	@No int,
	@NewState bit OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @count int
	select @count=COUNT(*) from Balance_main
	where ID=@No
	if @count>0
	begin
		update Balance_main set [Check]=1 - [Check]
		where ID=@No
		select @NewState=[check] from Balance_main
		where ID=@No
	end
END
GO
