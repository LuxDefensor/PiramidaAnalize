USE [Piramida2000]
GO

/****** Object:  UserDefinedFunction [dbo].[GetProfile]    Script Date: 02.11.2016 15:15:02 ******/
DROP FUNCTION [dbo].[GetProfile]
GO

/****** Object:  UserDefinedFunction [dbo].[GetProfile]    Script Date: 02.11.2016 15:15:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Г.Г. Михайленко
-- Create date: 2016-06-07
-- Description:	Возвращает набор получасовок за заданный день.
-- В возвращаемой таблице ВСЕГДА 48 строк, если получасовок не хватает,
-- в столбце значения будет NULL, остальные столбцы заполнены
-- =============================================
CREATE FUNCTION [dbo].[GetProfile]
(
	@Object int,
	@Item int,
	@SelectedDate datetime
)
RETURNS 
@Result TABLE 
(
	RowNumber int,
	FullDate datetime,
	Timecode nvarchar(5),
	Value float
)
AS
BEGIN
declare @input_date datetime
declare @halfhours table(fulldate datetime, timecode nvarchar(5), number int)
declare @h datetime
declare @tc nvarchar(5)
declare @number int
set @h=DATEADD(MI,30,@SelectedDate)
set @number=1
set	@tc=left(convert(nvarchar,@h, 108),5)
while @h<=DATEADD(Y,1,@SelectedDate)
begin
	insert into @halfhours(fulldate,timecode,number)
	values(@h,@tc,@number)
	set @h=DATEADD(MI,30,@h)
	set @number=@number+1
	set @tc=left(convert(nvarchar,@h, 108),5)
end

insert into @Result(RowNumber,FullDate,Timecode,Value)
	SELECT number, fulldate,timecode,
	t2.VALUE0
	FROM @halfhours t1 
	cross apply (select value0 from data
			 where object=@Object and item=@Item and parnumber=12
			 and data_date=t1.fulldate) t2
RETURN
END


GO

