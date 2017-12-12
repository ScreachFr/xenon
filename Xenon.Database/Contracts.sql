CREATE TABLE [dbo].[Contracts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [start] DATETIME NULL, 
    [end] DATETIME NULL, 
    [cover] FLOAT NULL, 
    [negociable] TINYINT NULL, 
    [prime] INT NULL, 
    [rompu] TINYINT NULL, 
    [company] NCHAR(32) NULL, 
    [wallet] INT NULL, 
    [value] INT NULL, 
    CONSTRAINT [FK_Contracts_Wallets_wallet] FOREIGN KEY ([wallet]) REFERENCES [Wallets]([id])
)
