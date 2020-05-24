USE [DbPratice]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [varchar](20) NULL,
	[Name] [nvarchar](max) NULL,
	[Color] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


INSERT INTO Cars 
VALUES('MEC001','Mecsadec', 'Black')
INSERT INTO [dbo].[Cars] 
VALUES('TYT001','Toyota', 'Red')


create proc CARS_Search @CarID varchar(20)  = NULL, @Name nvarchar(max) = NULL, @Color nvarchar(max) = NULL as
begin
	select * from Cars
	where (@CarID is null or @CarID = '' or CarID like '%' + @CarID + '%')
	and (@Name is null or @Name = '' or Name like '%' + @Name + '%')
	and (@Color is null or @Color = '' or Color like '%' + @Color + '%')
end

create proc CARS_Create @CarID varchar(20) = NULL, @Name nvarchar(max) = NULL, @Color nvarchar(max) = NULL as
begin
	INSERT INTO Cars 
	VALUES(@CarID,@Name, @Color)
	select * from Cars
	where (CarID like '%' + @CarID + '%')
	and (Name like '%' + @Name + '%')
	and (Color like '%' + @Color + '%')
end

create proc CARS_Delete @Id int = NULL as
begin
	DELETE FROM Cars OUTPUT DELETED.* WHERE Id=@Id
end

create proc CARS_GetByID  @Id int = NULL as
begin
	select * from Cars
	where (Id = @Id)
end

create proc CARS_Update  @Id int = NULL, @CarID varchar(20) = NULL, @Name nvarchar(max) = NULL, @Color nvarchar(max) = NULL as
begin
	UPDATE Cars 
	SET CarID = @CarID, Name= @Name, Color = @Color OUTPUT INSERTED .*
	WHERE Id = @Id;
end
