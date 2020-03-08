CREATE TABLE [dbo].[tbSituacao]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL
)
