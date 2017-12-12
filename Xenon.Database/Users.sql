CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] NCHAR(32) NOT NULL, 
    [password] NCHAR(64) NOT NULL, 
    [type] NCHAR(32) NOT NULL, 
    [mail] NCHAR(32) NULL
)
