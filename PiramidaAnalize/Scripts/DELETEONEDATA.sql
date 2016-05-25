USE [Piramida2000]
GO

/****** Object:  StoredProcedure [dbo].[DeleteOneData]    Script Date: 05/24/2016 11:22:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-05-20
-- Description:	Удаляет одну строку из таблицы DATA и записывает в лог
-- (таблица Data_log) кто и когда это сделал
-- =============================================
CREATE PROCEDURE [dbo].[DeleteOneData]
	-- Add the parameters for the stored procedure here
	@parnumber int,
	@object int,
	@item int,
	@data_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @OldValue float;
	
	select @OldValue=Value0 FROM DATA WHERE PARNUMBER=@parnumber AND OBJECT=@object AND ITEM=@item AND DATA_DATE=@data_date
	begin transaction
	DELETE FROM Data WHERE PARNUMBER=@parnumber AND OBJECT=@object AND ITEM=@item AND DATA_DATE=@data_date;
	if @@ROWCOUNT>0
	begin
		insert into Data_Log(Object,Item,Data_date,Parnumber,Value,TimeStamp,Action,[User_Name],[Host_name]) values
		(@object,@item,@data_date,@parnumber,@OldValue,GETDATE(),'DELETE',SUSER_NAME(), HOST_NAME())
	end
	commit transaction
	
END

GO

