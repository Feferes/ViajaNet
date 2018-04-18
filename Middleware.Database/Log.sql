CREATE TABLE [dbo].[Log]
(
	[Key] INT NOT NULL PRIMARY KEY,
	Message varchar(max) not null,
	DataCriacao datetime not null
)
