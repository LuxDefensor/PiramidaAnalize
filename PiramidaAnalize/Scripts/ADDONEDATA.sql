USE [Piramida2000]
GO

/****** Object:  StoredProcedure [dbo].[AddOneData]    Script Date: 05/24/2016 11:21:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-05-23
-- Description:	Обёртка для функции SP_ADD_DATA, предоставленнной производителем
-- АСКУЭ. Добавлено логирование в таблицу Data_log, который нет в стандартном комплекте 
-- =============================================
CREATE PROCEDURE [dbo].[AddOneData] 
	@PARNUMBER_ INTEGER,
	@DATA_DATE_ DATETIME,
	@OBJECT_ INTEGER,
	@ITEM_ INTEGER,
	@VALUE_ FLOAT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin tran
	execute SP_ADD_DATA
		@PARNUMBER = @PARNUMBER_,
		@DATA_DATE = @DATA_DATE_,
		@OBJECT = @OBJECT_,
		@ITEM = @ITEM_,
		@OBJTYPE = 0,
		@VALUE0 = @VALUE_,
		@VALUE1 = @VALUE_,
		@P2KSTATUS = 0,
		@P2KSTATUSH = 0,
		@RCVSTAMP = @DATA_DATE_;
	insert into Data_Log(Object,Item,Data_date,Parnumber,Value,TimeStamp,Action,[User_Name],[Host_name]) values
		(@object_,@item_,@data_date_,@parnumber_,@Value_,GETDATE(),'WRITE',SUSER_NAME(), HOST_NAME())
	commit tran

END

GO


