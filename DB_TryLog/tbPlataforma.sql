CREATE TABLE [dbo].[tbPlataforma]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Codigo] CHAR(3) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [DataUltimaAtualizacao] DATETIME NOT NULL
)
